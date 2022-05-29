using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerSearchTree;
using Nodes;

namespace Blocks
{
    public class Block1
    {
        public Block2 Father { get; set; }

        public Block1 Mate { get; set; }

        public Node OldNode { get; set; }

        public Node NewNode { get; set; }

        public Block1 Left { get; set; }

        public Block2 Right { get; set; }

        public int Degree { get => nodes_.Count; }

        private List<Node> nodes_ = new List<Node>();

        public Block1(Node node)
        {
            nodes_.Add(node);
        }

        public Node FistNode()
        {
            if (nodes_.Count == 0)
                return null;
            return nodes_[0];
        }

        public Node LastNode()
        {
            if (nodes_.Count == 0)
                return null;
            return nodes_[nodes_.Count - 1];
        }

        internal Node GetNodeContaining(int searchValue, out bool isBigger)
        {
            // go through all the elements. 
            for (int index = 0; index < nodes_.Count; index++)
            {
                Node node = nodes_[index];

                // ig we found one, just return it.
                if (node.ContainsElement(searchValue))
                {
                    isBigger = false;
                    return node;
                }
                if (node.GetMin() > searchValue)
                {
                    // if we found a bigger one, then all the next ones are bigger, and we return the previous one that is smaller. 
                    isBigger = true;
                    if (index == 0)
                        return null;
                    else
                        return nodes_[index - 1];
                }
            }

            isBigger = false;
            return null;
        }
    }
}
