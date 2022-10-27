using System;
using System.Collections.Generic;
using GroupAndComponent;
using Blocks;
using System.Linq;
using FingerSearchTree;
using System.Xml.Linq;

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

            return Min <= value && value <= Max;
        }

        internal Node FindChildContaining(int value)
        {
            int minpos = 0;
            int maxpos = Blocks2.Count - 1;
            int midpos = (maxpos + minpos) / 2;
            while (Blocks2[midpos].ContainsValue(value) == false && maxpos > minpos)
            {
                if (Blocks2[midpos].Blocks1[0].Nodes[0].Min > value)
                    maxpos = midpos - 1;
                else
                    minpos = midpos + 1;
                midpos = (maxpos + minpos) / 2;
            }

            if (Blocks2[midpos].ContainsValue(value))
                return Blocks2[midpos].FindChildContaining(value);
            else if (Blocks2[midpos].Blocks1[Blocks2[midpos].Blocks1.Count - 1].Nodes[Blocks2[midpos].Blocks1[Blocks2[midpos].Blocks1.Count - 1].Nodes.Count - 1].Max < value)
                return Blocks2[midpos].Blocks1[Blocks2[midpos].Blocks1.Count - 1].Nodes[Blocks2[midpos].Blocks1[Blocks2[midpos].Blocks1.Count - 1].Nodes.Count - 1];
            else
                return Blocks2[midpos].Blocks1[0].Nodes[0].Left;
        }

        internal void Add(Block2 left, Block2 middle)
        {
            // find position to insert.
            int position = Blocks2.FindIndex(x => x == left) + 1;

            // actually insert in the list.
            Blocks2.Insert(position, middle);
            middle.Node = this;

            // Make sure the left/right pointers are set correctly.
            Block2 right = left.Right;
            left.Right = middle;
            middle.Left = left;
            middle.Right = right;

            if (right!= null)
            {
                right.Left = middle;
            }

            middle.Group = left.Group;
        }

        internal void Add(int position, Block2 middle)
        {
            // actually insert in the list.
            Blocks2.Insert(position, middle);
            middle.Node = this;

            // Make sure the left/right pointers are set correctly.
            Block2 left = null;
            Block2 right = null;

            if (position != 0)
            {
                left = Blocks2[position - 1];
                left.Right = middle;
            }

            if (position < Blocks2.Count - 1)
            {
                right = Blocks2[position + 1];
                right.Left = middle;
            }

            middle.Left = left;
            middle.Right = right;
        }

        internal void Remove(Block2 e)
        {
            Blocks2.Remove(e);

            Block2 right = e.Right;
            Block2 left = e.Left;

            if (left != null)
                left.Right = right;
            if (right != null)
                right.Left = left;
        }
    }
}
