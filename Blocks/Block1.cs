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

        public Node OldNode { get; set; } = null;

        public Node NewNode { get; set; } = null;

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
            Node rightTest = left.Right;
            left.Right = middle;
            middle.Left = left;

            Node right = null;
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

            if (right != null)
            {
                right.Left = middle;
                middle.Right = right;
            }
        }

        internal void Add(int position, Node middle)
        {
            // find position to insert.
            Nodes.Insert(position, middle);
            middle.Father = this;

            // Make sure the left/right pointers are set correctly.
            Node rightTest = null;
            Node leftTest = null;

            Node left = null;
            if (position != 0)
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
                        leftBlock2 = leftNode.Blocks2[leftNode.Blocks2.Count - 1];
                        leftBlock1 = leftBlock2.Blocks1[leftBlock2.Blocks1.Count - 1];
                        left = leftBlock1.Nodes[leftBlock1.Nodes.Count - 1];
                    }
                }
            }

            rightTest = left.Right;
            left.Right = middle;
            middle.Left = left;

            Node right = null;
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
                    else if (Father.Node.Father != null)
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
            if (right != null)
            { leftTest = right.Left; }
            if (right != rightTest)
            { int ok; }
            if (right != null && left != leftTest)
            { int ok; }
            if (right != null)
            {
                right.Left = middle;
                middle.Right = right;
            }
        }

        internal void TransferToMate()
        {
            //Just remove the node from this block1 and add it into the mate. 
            // The father pointer is updates, but the rest of them are not needed, since the transfer is made between mates, and since the nodes keep the left-right pointers even through the block1 bounds. 
            if (Mate == Right)
            {
                Node transferredNode = Nodes[Nodes.Count - 1]; // if the mate is on the right, then we transfer the last node to its mate, so that we can keep the order of the nodes unchanged.
                Remove(transferredNode,true);
                Mate.Add(0, transferredNode);
            }
            else if(Mate == Left)
            {
                Node transferredNode = Nodes[0]; //if the mate is on the left, then we transfer the first node to its mate, so that we can keep the order of the nodes unchanged.
                Remove(transferredNode,true);
                Mate.Add(Mate.Nodes.Count, transferredNode);
            }
            else
            {
                int eu = Father.Blocks1.FindIndex(x => x == this);
                int el = Father.Blocks1.FindIndex(x => x == Mate);
                int ou = Father.Blocks1.FindIndex(x => x == Right);
                int ol = Father.Blocks1.FindIndex(x => x == Mate.Left);
                bool ok = Father.Blocks1[eu].Right == Father.Blocks1[el];
            }
        }

        internal void Remove(Node e, bool justForTransfer = false)
        {
            bool wasFull = IsFull;

            int position = Nodes.FindIndex(x => x == e);

            // Remove it from the list of nodes.
            Nodes.Remove(e);

            // Sort the left right pointers. (in order for them not to point to e)

            Node left = e.Left;
            Node right = e.Right;

            left.Right = right;
            if (right != null)
                right.Left = left;

            // If it becomes empty, remove this block1 from its father, and also make sure that the Mate is announced. 
            if (Degree == 0)
            {
                Father.Remove(this);
                if (Mate != null)
                    Mate.Mate = null;
                return;
            }

            // If it is not the full mate in the pair of blocks1, then there is no need to perform the transfers.
            if (wasFull == false)
                return;

            if (justForTransfer)
                return;

            //If it was the full mate, then we try to transfer a node from its mate, as long as it has one.
            if (Mate != null)
            {
                Mate.TransferToMate();
            }
            else if (Right != null && Right.Mate == null) // If there is no mate but there is a right block1 that also has no mate, we make the pair and then transfer.
            {
                Mate = Right;
                Right.Mate = this;
                Mate.TransferToMate();
            }
            else if (Left != null && Left.Mate == null) // If there is no mate but there is a left block1 that also has no mate, we make a pair and transfer.
            {
                Mate = Left;
                Left.Mate = this;
                Mate.TransferToMate();
            }
            else if (Right != null) //If we still cannot make a pair, then we remove the first node from right, and add it to this block1
            {
                Node sharedNode = Right.Nodes[0];
                Right.Remove(sharedNode);
                Add(Nodes.Count, sharedNode);
            }
            else if (Left != null) // If there is no right then we try the same thing with left.
            {
                Node sharedNode = Left.Nodes[Left.Nodes.Count - 1];
                Left.Remove(sharedNode);
                Add(0, sharedNode);
            }
        }
    }
}
