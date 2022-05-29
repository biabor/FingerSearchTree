﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerSearchTree;
using GroupAndComponent;
using Nodes;

namespace Blocks
{
    public class Block2
    {
        public Group Group { get; set; }

        public Block2 Mate { get; set; }

        public bool Pending { get; set; }

        public Node Node { get; set; }

        public Block2 Left { get; set; }

        public Block2 Right { get; set; }

        public int Degree { get => children_.Sum(element => element.Degree); }

        private List<Block1> children_ = new List<Block1>();

        public Block2(Block1 child)
        {
            children_.Add(child);
            Pending = false;
        }

        public Block1 FirstBlock1()
        {
            if (children_.Count == 0)
                return null;
            return children_[0];
        }

        public Block1 LastBlock1()
        {
            if (children_.Count == 0)
                return null;
            return children_[children_.Count - 1];
        }

        internal Node GetNodeContaining(int searchValue, out bool biggerFound)
        {
            // goes through all blocks1
            for (int index = 0; index < children_.Count; index++)
            {
                Block1 block1 = children_[index];
                // we skip the ones that contain only smaller elements.
                if (block1.LastNode().GetMax() < searchValue)
                    continue;

                // search for the node.
                Node node = block1.GetNodeContaining(searchValue, out bool isBigger);

                // if the node is found, or if the biggest node smaller is found, just return it.
                if (node != null)
                {
                    biggerFound = isBigger;
                    return node;
                }
                else if (isBigger)
                {
                    // if all nodes are bigger, then return the biggest node from the previous blick1.
                    biggerFound = true;
                    if (index == 0)
                        return null;
                    else
                        return children_[index - 1].LastNode();
                }
            }

            biggerFound = false;
            return null;
        }
    }
}
