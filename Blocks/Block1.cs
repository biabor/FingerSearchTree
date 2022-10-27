using System.Collections.Generic;
using FingerSearchTree;
using Nodes;

namespace Blocks
{
    public class Block1
    {
        public bool IsFull { get => Degree >= Helpers.Ai(Father.Node.Level); }

        public int Degree { get => Nodes.Count; }

        public List<Node> Nodes = new List<Node>();

        public Block2 Father { get; set; } = null;

        public Block1 Left { get; set; } = null;

        public Block1 Right { get; set; } = null;

        public Block1 Mate { get; set; } = null;

        public Block1() { }

        public Block1(Node node)
        {
            Nodes.Add(node);
            node.Father = this;
        }

        internal bool ContainsValue(int value)
        {
            return Nodes[0].Min <= value && value <= Nodes[Nodes.Count - 1].Max;
        }

        internal Node FindChildContaining(int value)
        {
            int minpos = 0;
            int maxpos = Nodes.Count - 1;
            int midpos = (minpos + maxpos) / 2;
            while (Nodes[midpos].ContainsValue(value) == false && minpos < maxpos)
            {
                if (Nodes[midpos].Min > value)
                    maxpos = midpos - 1;
                else
                    minpos = midpos + 1;
                midpos = (maxpos + minpos) / 2;
            }

            if (Nodes[midpos].ContainsValue(value))
                return Nodes[midpos];
            else if (Nodes[midpos].Max < value)
                return Nodes[midpos];
            else
                return Nodes[midpos].Left;
        }

        internal void Add(Node left, Node middle)
        {
            bool wasFull = IsFull;

            // find position to insert.
            int position = Nodes.FindIndex(x => x == left) + 1;
            Nodes.Insert(position, middle);
            middle.Father = this;

            // Make sure the left/right pointers are set correctly.
            Node right = left.Right;
            left.Right = middle;
            middle.Left = left;
            middle.Right = right;
            if (right != null)
            {
                right.Left = middle;
            }
        }

        internal void Add(int position, Node middle)
        {
            // find position to insert.
            Nodes.Insert(position, middle);
            middle.Father = this;

            // Make sure the left/right pointers are set correctly.
            Node left = null;
            if (position > 0)
            {
                left = Nodes[position - 1];
            }
            else
            {
                Block1 leftBlock1 = Left;
                if (leftBlock1 != null)
                {
                    left = leftBlock1.Nodes[leftBlock1.Nodes.Count - 1];
                }
                else
                {
                    Block2 leftBlock2 = Father.Left;
                    if (leftBlock2 != null)
                    {
                        leftBlock1 = leftBlock2.Blocks1[leftBlock2.Blocks1.Count - 1];
                        left = leftBlock1.Nodes[leftBlock1.Nodes.Count - 1];
                    }
                    else
                    {
                        Node leftNode = Father.Node.Left;
                        if (leftNode != null)
                        {
                            leftBlock2 = leftNode.Blocks2[leftNode.Blocks2.Count - 1];
                            leftBlock1 = leftBlock2.Blocks1[leftBlock2.Blocks1.Count - 1];
                            left = leftBlock1.Nodes[leftBlock1.Nodes.Count - 1];
                        }
                    }
                }
            }
            Node right = null;
            if (left != null)
            {
                right = left.Right;
                left.Right = middle;
            }
            else
            {
                if (position < Nodes.Count - 1)
                {
                    right = Nodes[position + 1];
                }
                else
                {
                    Block1 rightBlock1 = Right;
                    if (rightBlock1 != null)
                    {
                        right = rightBlock1.Nodes[0];
                    }
                    else
                    {
                        Block2 rightBlock2 = Father.Right;
                        if (rightBlock2 != null)
                        {
                            rightBlock1 = rightBlock2.Blocks1[0];
                            right = rightBlock1.Nodes[0];
                        }
                        else
                        {
                            Node rightNode = Father.Node.Right;
                            if (rightNode != null)
                            {
                                rightBlock2 = rightNode.Blocks2[0];
                                rightBlock1 = rightBlock2.Blocks1[0];
                                right = rightBlock1.Nodes[0];
                            }
                        }
                    }
                }
            }
            middle.Left = left;

            if (right != null)
            {
                right.Left = middle;
            }
            middle.Right = right;
        }

        internal void TransferToMate()
        {
            //Just remove the node from this block1 and add it into the mate. 
            // The father pointer is updates, but the rest of them are not needed, since the transfer is made between mates, and since the nodes keep the left-right pointers even through the block1 bounds. 
            if (Mate == Right)
            {
                Node transferredNode = Nodes[Nodes.Count - 1]; // if the mate is on the right, then we transfer the last node to its mate, so that we can keep the order of the nodes unchanged.
                Remove(transferredNode); 
                Mate.Add(0, transferredNode);
            }
            else if (Mate == Left)
            {
                Node transferredNode = Nodes[0]; //if the mate is on the left, then we transfer the first node to its mate, so that we can keep the order of the nodes unchanged.
                Remove(transferredNode);
                Mate.Add(Mate.Nodes.Count, transferredNode);
            }
        }

        internal void Remove(Node e)
        {
            // Remove it from the list of nodes.
            Nodes.Remove(e);

            // Sort the left right pointers. (in order for them not to point to e)
            Node left = e.Left;
            Node right = e.Right;

            if (left != null)
                left.Right = right;
            if (right != null)
                right.Left = left;

            // If it becomes empty, remove this block1 from its father, and also make sure that the Mate is announced. 
            if (Degree == 0)
            {
                Father.Remove(this);
                if (Mate != null)
                    Mate.Mate = null;
            }
        }
    }
}
