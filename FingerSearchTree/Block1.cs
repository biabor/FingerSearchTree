using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FingerSearchTree
{
    public class Block1
    {
        public Block1? Left { get; set; }

        public Block1? Right { get; set; }

        public Block1? Mate { get; set; }

        public Block2 Father { get; set; }

        public List<Node> Nodes { get; }

        public int Degree { get => Nodes.Count; }

        public bool IsFull { get => Bounds.Ai(Father.Node.Level) <= Degree; }

        public int Min
        {
            get => Nodes.Count == 0 ? int.MaxValue : Nodes.First().Min;
        }

        public int Max
        {
            get => Nodes.Count == 0 ? int.MinValue : Nodes.Last().Max;
        }

        public Block1(Block2 father)
        {
            Father = father;
            Nodes = new List<Node>();
        }

        internal bool ContainsValue(int value)
        {
            return Min <= value && value <= Max;
        }

        internal Node FindChildContaining(int value)
        {
            if (value > Max)
                return Nodes.Last();

            int minpos = 0;
            int maxpos = Nodes.Count - 1;
            int midpos = (maxpos + minpos) / 2;
            while (Nodes[midpos].ContainsValue(value) == false && maxpos > minpos)
            {
                if (Nodes[midpos].Min > value)
                    maxpos = midpos - 1;
                else
                    minpos = midpos + 1;
                midpos = (maxpos + minpos) / 2;
            }

            if (Nodes[midpos].ContainsValue(value) || Nodes[midpos].Max < value)
                return Nodes[midpos];
            else
            {
                Node first = Nodes[midpos];
                if (first.Left != null)
                    return first.Left;
                else
                    return first;
            }
        }

        internal void Add(Node left, Node middle)
        {
            int position = Nodes.IndexOf(left);
            Nodes.Insert(position + 1, middle);
            middle.Father = this;

            Node? right = left.Right;
            left.Right = middle;
            middle.Left = left;
            middle.Right = right;
            if (right != null)
                right.Left = middle;
        }

        internal void Add(int position, Node middle)
        {
            Nodes.Insert(position, middle);
            middle.Father = this;

            Node? left = null;
            Node? right = null;

            if (position > 0)
            {
                left = Nodes[position - 1];
            }
            else
            {
                Block1? leftBlock1 = Left;
                if (leftBlock1 != null)
                {
                    left = leftBlock1.Nodes.Last();
                }
                else
                {
                    Block2? leftBlock2 = Father.Left;
                    if (leftBlock2 != null)
                    {
                        leftBlock1 = leftBlock2.Blocks1.Last();
                        left = leftBlock1.Nodes.Last();
                    }
                    else
                    {
                        Node? leftNode = Father.Node.Left;
                        if (leftNode != null)
                        {
                            leftBlock2 = leftNode.Blocks2.Last();
                            leftBlock1 = leftBlock2.Blocks1.Last();
                            left = leftBlock1.Nodes.Last();
                        }
                    }
                }
            }
            
            if(left != null)
            {
                right = left.Right;
            }
            else
            {
                if (position < Nodes.Count - 1)
                {
                    right = Nodes[position + 1];
                }
                else
                {
                    Block1? rightBlock1 = Right;
                    if (rightBlock1 != null)
                    {
                        right = rightBlock1.Nodes.First();
                    }
                    else
                    {
                        Block2? rightBlock2 = Father.Right;
                        if (rightBlock2 != null)
                        {
                            rightBlock1 = rightBlock2.Blocks1.First();
                            right = rightBlock1.Nodes.First();
                        }
                        else
                        {
                            Node? rightNode = Father.Node.Right;
                            if (rightNode != null)
                            {
                                rightBlock2 = rightNode.Blocks2.First();
                                rightBlock1 = rightBlock2.Blocks1.First();
                                right = rightBlock1.Nodes.First();
                            }
                        }
                    }
                }
            }

            if (left != null)
                left.Right = middle;
            middle.Left = left;
            middle.Right = right;
            if(right != null)
                right.Left = middle;
        }

        internal void Remove(Node middle)
        {
            Nodes.Remove(middle);

            Node? left = middle.Left;
            Node? right = middle.Right;

            if (left != null)
                left.Right = right;
            if (right != null)
                right.Left = left;

            if(Nodes.Count == 0)
            {
                Father.Remove(this);
                if (Mate != null)
                    Mate.Mate = null;
            }
        }

        internal void TransferToMate()
        {
            if (Mate == Right)
            {
                Node transferredNode = Nodes.Last();
                Remove(transferredNode);
                Mate.Add(0, transferredNode);
            }
            else
            {
                Node transferredNode = Nodes.First();
                Remove(transferredNode);
                Mate.Add(Mate.Nodes.Count, transferredNode);
            }
        }
    }
}
