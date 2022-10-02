using System;
using System.Collections.Generic;
using GroupAndComponent;
using Blocks;
using System.Linq;
using FingerSearchTree;

namespace Nodes
{
    public class Node
    {
        public bool IsUnderContruction { get; set; } = false;

        public int Level { get; set; } = 0;

        public int Degree { get => Blocks2.Sum(x => x.Degree); }

        public virtual int Min
        {
            get
            {
                if (Blocks2.Count == 0)
                    return int.MaxValue;

                if (Blocks2[0].Blocks1.Count == 0)
                    return int.MaxValue;

                if (Blocks2[0].Blocks1[0].Nodes.Count == 0)
                    return int.MaxValue;

                return Blocks2[0].Blocks1[0].Nodes[0].Min;
            }
        }

        public virtual int Max
        {
            get
            {
                if (Blocks2.Count == 0)
                    return int.MinValue;

                if (Blocks2[Blocks2.Count - 1].Blocks1.Count == 0)
                    return int.MinValue;

                if (Blocks2[Blocks2.Count - 1].Blocks1[Blocks2[Blocks2.Count - 1].Blocks1.Count - 1].Nodes.Count == 0)
                    return int.MaxValue;

                List<Node> nodes = Blocks2[Blocks2.Count - 1].Blocks1[Blocks2[Blocks2.Count - 1].Blocks1.Count - 1].Nodes;

                return nodes[nodes.Count - 1].Max;
            }
        }

        public Node Left { get; set; } = null;

        public Node Right { get; set; } = null;

        public Node FatherNode { get => Father?.Father?.Node; }

        public List<Block2> Blocks2 = new List<Block2>();

        public Block1 Father { get; set; } = null;

        public Group Group { get; set; } = null;

        private Component component_ = null;

        public Component Component
        {
            get
            {
                if (Group.IsSplitGroup) return Group.Component;
                else return component_;
            }
            set 
            {
                component_ = value;
                Group.Component = value;
            }
        }

        public Node() { }

        public Node(Block2 block2)
        {
            Blocks2.Add(block2);
            block2.Node = this;
            Level = Blocks2[0].Blocks1[0].Nodes[0].Level + 1;

            Group = new Group(this);
            Component = new Component(this);
        }

        internal virtual bool ContainsValue(int value)
        {
            if (FatherNode == null)
                return true;

            if (Blocks2.Count == 0)
                return false;

            if (value < Min)
                return false;

            if (value > Max)
                return false;

            return true;
        }

        internal Node FindChildContaining(int value)
        {
            foreach (Block2 block2 in Blocks2)
            {
                if (block2.Blocks1.Count == 0)
                    continue;

                Block1 block1Last = block2.Blocks1[block2.Blocks1.Count - 1];
                if (block1Last.Nodes.Count == 0)
                    continue;

                Node nodeLast = block1Last.Nodes[block1Last.Nodes.Count - 1];
                if (nodeLast.Max < value)
                    continue;

                foreach (Block1 bl1 in block2.Blocks1)
                {
                    if (bl1.Nodes.Count == 0)
                        continue;

                    nodeLast = bl1.Nodes[bl1.Nodes.Count - 1];
                    if (nodeLast.Max < value)
                        continue;

                    foreach (Node no in bl1.Nodes)
                    {
                        if (no.ContainsValue(value))
                            return no;
                        else // Make sure this is correctly followed. --- TODO
                            if(no.Max > value)
                                return no.Left;
                    }
                }
            }

            return Blocks2[Blocks2.Count - 1].Blocks1[Blocks2[Blocks2.Count - 1].Blocks1.Count - 1].Nodes[Blocks2[Blocks2.Count - 1].Blocks1[Blocks2[Blocks2.Count - 1].Blocks1.Count - 1].Nodes.Count - 1];
        }

        internal void Add(Block2 left, Block2 middle)
        {
            // find position to insert.
            int position = Blocks2.FindIndex(x => x == left);
            position++;

            // actually insert in the list.
            Blocks2.Insert(position, middle);
            middle.Node = this;

            // Make sure the left/right pointers are set correctly.
            Block2 right = left.Right;
            left.Right = middle;
            middle.Left = left;

            if (right != null)
            {
                middle.Right = right;
                right.Left = middle;
            }

            middle.Group = left.Group;
        }

        internal void Add(int position, Block2 middle)
        {
            // actually insert in the list.
            Blocks2.Insert(position, middle);
            middle.Node = this;

            if (position == 0)
            {
                if (Blocks2.Count > 1)
                {
                    Block2 right = Blocks2[position + 1];
                    middle.Right = right;
                    right.Left = middle;
                }
            }
            else if (position == Blocks2.Count)
            {
                Block2 left = Blocks2[position - 1];
                left.Right = middle;
                middle.Left = left;
            }
            else
            {
                Block2 left = Blocks2[position - 1];
                Block2 right = Blocks2[position + 1];
                left.Right = middle;
                middle.Right = right;
                right.Left = middle;
                middle.Left = left;
            }
        }

        internal void Remove(Block2 e)
        {
            Blocks2.Remove(e);

            if (e.Left != null)
                e.Left.Right = e.Right;
            if (e.Right != null)
                e.Right.Left = e.Left;
            e.Left = null;
            e.Right = null;

        }
    }
}
