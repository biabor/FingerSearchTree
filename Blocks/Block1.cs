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

        internal void Add(Node left, Node middle)
        {
            bool wasFull = IsFull;

            // find position to insert.
            Nodes.Insert(Nodes.FindIndex(x => x == left) + 1, middle);
            middle.Father = this;

            // Make sure the left/right pointers are set correctly.
            Node right = left.Right;
            left.Right = middle;
            middle.Left = left;

            if (right != null)
            {
                middle.Right = right;
                right.Left = middle;
            }

            // If this block1 was already full before the insert, then transfer to one node to the mate.
            if (wasFull)
            {
                if (Mate == null)
                {
                    Mate = new Block1()
                    {
                        Mate = this
                    };
                    Father.Add(this, Mate);
                }
                TransferToMate();
            }

            // if both become full, break the pair.
            if (IsFull && Mate != null && Mate.IsFull)
            {
                Mate.Mate = null;
                Mate = null;
            }
        }

        internal void Add(int position, Node middle)
        {
            // find position to insert.
            Nodes.Insert(position, middle);
            middle.Father = this;

            // Make sure the left/right pointers are set correctly.
            if (position == 0)
            {
                if (Nodes.Count > 1)
                {
                    Node right = Nodes[position + 1];
                    middle.Right = right;
                    right.Left = middle;
                }
                else if (Right != null)
                {
                    Node right = Right.Nodes[0];
                    middle.Right = right;
                    right.Left = middle;
                }
                else if(Father.Right?.Blocks1[0] != null)
                {
                    Node right = Father.Right.Blocks1[0].Nodes[0];
                    middle.Right = right;
                    right.Left = middle;
                }
                else if(Father.Node.Right?.Blocks2[0].Blocks1[0] != null)
                {
                    Node right = Father.Node.Right.Blocks2[0].Blocks1[0].Nodes[0];
                    middle.Right = right;
                    right.Left = middle;
                }
                if (Left != null)
                {
                    Node left = Left.Nodes[Left.Nodes.Count - 1];
                    middle.Left = left;
                    left.Right = middle;
                }
                else if (Father.Left?.Blocks1[Father.Left.Blocks1.Count - 1] != null)
                {
                    Block1 l = Father.Left.Blocks1[Father.Left.Blocks1.Count - 1];
                    Node left = l.Nodes[l.Nodes.Count - 1];
                    middle.Left = left;
                    left.Right = middle;
                }
                else if (Father.Node.Left?.Blocks2[Father.Node.Blocks2.Count - 1] != null)
                {
                    Block2 fb = Father.Node.Left.Blocks2[Father.Node.Blocks2.Count - 1];
                    Block1 f = fb.Blocks1[fb.Blocks1.Count - 1];
                    Node left = f.Nodes[f.Nodes.Count - 1];
                    middle.Left = left;
                    left.Right = middle;
                }
            }
            else if (position == Nodes.Count)
            {
                if (Nodes.Count > 1)
                {
                    Node left = Nodes[position - 1];
                    left.Right = middle;
                    middle.Left = left;
                }
            }
            else
            {
                Node left = Nodes[position - 1];
                Node right = Nodes[position + 1];
                left.Right = middle;
                middle.Right = right;
                right.Left = middle;
                middle.Left = left;
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
            else if (Mate == Left)
            {
                Node transferredNode = Nodes[0]; //if the mate is on the left, then we transfer the first node to its mate, so that we can keep the order of the nodes unchanged.
                Remove(transferredNode,true);
                Mate.Add(Mate.Nodes.Count, transferredNode);
            }
            else if (Mate == Father?.Right?.Blocks1[0])
            {
                Node transferredNode = Nodes[Nodes.Count - 1];
                Remove(transferredNode,true);
                Mate.Add(0, transferredNode);

                if (Father.Right != Father.Mate)
                {
                    Mate.Mate = null;
                    Mate = null;
                }
            }
            else if (Mate == Father?.Left?.Blocks1[Father.Left.Blocks1.Count - 1])
            {
                Node transferredNode = Nodes[0];
                Remove(transferredNode, true);
                Mate.Add(Mate.Nodes.Count, transferredNode);

                if (Father.Left != Father.Mate)
                {
                    Mate.Mate = null;
                    Mate = null;
                }
            }
        }

        internal void Remove(Node e, bool justForTransfer = false)
        {
            bool wasFull = IsFull;

            // Remove it from the list of nodes.
            Nodes.Remove(e);

            // Sort the left right pointers. (in order for them not to point to e)
            if (e.Left != null)
            {
                e.Left.Right = e.Right;
            }
            if (e.Right != null)
            {
                e.Right.Left = e.Left;
            }
            e.Left = null;
            e.Right = null;

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
