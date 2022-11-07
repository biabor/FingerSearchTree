using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FingerSearchTree
{
    public class Node
    {
        public Node? Left { get; set; }

        public Node? Right { get; set; }

        public Block1? Father { get; set; }

        public Node? FatherNode { get => Father?.Father.Node; }

        public List<Block2> Blocks2 { get; }

        private Group group_;

        public Group Group
        {
            get
            {
                if (group_.Valid == false)
                    group_ = new Group(this, group_.Component);
                return group_;
            }
            set => group_ = value;
        }

        public Component Component
        {
            get => Group.Component;
        }

        public int Level { get; internal set; }

        public int Degree { get => Blocks2.Sum(bl => bl.Degree); }

        public virtual int Min
        {
            get => Blocks2.Count == 0 ? int.MaxValue : Blocks2.First().Min;
        }

        public virtual int Max
        {
            get => Blocks2.Count == 0 ? int.MinValue : Blocks2.Last().Max;
        }

        public bool ContainsAtLeastTwoBlock2Pairs
        {
            get
            {
                switch (Blocks2.Count)
                {
                    case 0: return false;
                    case 1: return false;
                    case 2: return Blocks2[0].Mate != Blocks2[1] && Blocks2[0] != Blocks2[1].Mate;
                    case 3:
                        if (Blocks2[1].Pending) return true;
                        return Blocks2[0].Pending == false && Blocks2[2].Pending == false;
                    case 4: return Blocks2[0].Pending && Blocks2[1].Pending == false && Blocks2[2].Pending == false && Blocks2[3].Pending;
                    default: return true;
                }
            }
        }

        public bool Fused { get; set; } = false;

        public Node(int level)
        {
            Blocks2 = new List<Block2>();
            group_ = new Group(this);
            Level = level;
        }

        internal bool ContainsValue(int value)
        {
            if (Father == null)
                return true;
            return Min <= value && value <= Max;
        }

        internal Node FindChildContaining(int value)
        {
            if (value > Max)
                return Blocks2.Last().FindChildContaining(value);

            int minpos = 0;
            int maxpos = Blocks2.Count - 1;
            int midpos = (maxpos + minpos) / 2;
            while (Blocks2[midpos].ContainsValue(value) == false && maxpos > minpos)
            {
                if (Blocks2[midpos].Min > value)
                    maxpos = midpos - 1;
                else
                    minpos = midpos + 1;
                midpos = (maxpos + minpos) / 2;
            }

            if (Blocks2[midpos].ContainsValue(value) || Blocks2[midpos].Max < value)
                return Blocks2[midpos].FindChildContaining(value);
            else
            {
                Node first = Blocks2[midpos].Blocks1.First().Nodes.First();
                if (first.Left != null)
                    return first.Left;
                else
                    return first;
            }    
        }

        internal void Add(Block2 left, Block2 middle)
        {
            int position = Blocks2.IndexOf(left);
            Blocks2.Insert(position + 1, middle);
            middle.Node = this;

            Block2? right = left.Right;
            left.Right = middle;
            middle.Left = left;
            middle.Right = right;
            if (right != null)
                right.Left = middle;
        }

        internal void Add(int position, Block2 middle)
        {
            Blocks2.Insert(position, middle);
            middle.Node = this;

            Block2? left = null;
            Block2? right = null;

            if (position > 0)
                left = Blocks2[position - 1];
            if (position < Blocks2.Count - 1)
                right = Blocks2[position + 1];

            if (left != null)
                left.Right = middle;
            middle.Left = left;
            middle.Right = right;
            if (right != null)
                right.Left = middle;
        }

        internal void Remove(Block2 middle)
        {
            Blocks2.Remove(middle);

            Block2? left = middle.Left;
            Block2? right = middle.Right;

            if (left != null)
                left.Right = right;
            if (right != null)
                right.Left = left;

            if(Blocks2.Count == 0)
            {
                if (Fused)
                {
                    Fused = false;
                }
                else 
                {
                    Tree.DeleteNode(this);
                }
            }
        }

        internal Node Split()
        {
            Node newNode = new Node(Level);

            if (Father == null)
            {
                Node root = new Node(Level + 1);
                Block2 block2 = new Block2(root);
                Block1 block1 = new Block1(block2);

                block1.Nodes.Add(this);
                block2.Blocks1.Add(block1);
                root.Blocks2.Add(block2);
                Father = block1;
            } 

            Block2 lastBlock2 = Blocks2.Last();
            if(lastBlock2.Pending)
            {
                Remove(lastBlock2);
                newNode.Add(0,lastBlock2);
                lastBlock2 = Blocks2.Last();
            }

            Remove(lastBlock2);
            newNode.Add(0, lastBlock2);
            lastBlock2 = Blocks2.Last();

            if(lastBlock2.Pending == false && lastBlock2.Mate != null && lastBlock2.Mate == newNode.Blocks2.First() && lastBlock2.Mate.Mate == lastBlock2)
            {
                Remove(lastBlock2);
                newNode.Add(0, lastBlock2);
                lastBlock2 = Blocks2.Last();
            }

            if (lastBlock2.Pending && lastBlock2.Mate != null && lastBlock2.Mate == newNode.Blocks2.First())
            {
                Remove(lastBlock2);
                newNode.Add(0, lastBlock2);
            }

            AddToGroup(newNode);

            return newNode;
        }

        private void AddToGroup(Node newNode)
        {
            newNode.Group = Group;
            int position = Group.Nodes.IndexOf(this);
            Group.Nodes.Insert(position + 1, newNode);
        }
    }
}
