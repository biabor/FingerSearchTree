﻿using System;
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

        public Component Component { get; set; } = null;

        public Node() { }

        /// <summary>
        /// Creates the father node/root of the initial tree.
        /// </summary>
        /// <param name="block2">block2 it contains</param>
        public Node(Block2 block2)
        {
            Blocks2.Add(block2);
            block2.Node = this;

            Component = new Component(this);
            Group = new Group(this);
            Level = Blocks2[0].Blocks1[0].Nodes[0].Level + 1;
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

                Block1 block1 = block2.Blocks1[block2.Blocks1.Count - 1];
                if (block1.Nodes.Count == 0)
                    continue;

                Node node = block1.Nodes[block1.Nodes.Count - 1];
                if (node.Max < value)
                    continue;

                foreach (Block1 bl1 in block2.Blocks1)
                {
                    if (bl1.Nodes.Count == 0)
                        continue;

                    node = bl1.Nodes[bl1.Nodes.Count - 1];
                    if (node.Max < value)
                        continue;

                    foreach (Node no in bl1.Nodes)
                    {
                        if (no.ContainsValue(value))
                            return no;
                        else
                            return no.Left;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Adds the block2 right to the right of the block2 left.
        /// </summary>
        /// <param name="left">The block2 next to which it needs to be inserted.</param>
        /// <param name="right">The block2 that needs to be inserted.</param>
        internal void Add(Block2 left, Block2 right)
        {
            // find position to insert.
            int position = Blocks2.FindIndex(x => x == left);
            position++;

            // actually insert in the list.
            Blocks2.Insert(position, right);
            right.Node = this;

            // Make sure the left/right pointers are set correctly.
            Block2 aux = left.Right;
            left.Right = right;
            right.Left = left;

            if (aux != null)
            {
                right.Right = aux;
                aux.Left = right;
            }
        }

        internal void Remove(Block2 e)
        {
            Blocks2.Remove(e);

            if (e.Left != null)
                e.Left.Right = e.Right;
            if (e.Right != null)
                e.Right.Left = e.Left;

        }
    }
}
