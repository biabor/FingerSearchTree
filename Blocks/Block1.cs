using System.Collections.Generic;
using FingerSearchTree;
using Nodes;

namespace Blocks
{
    public class Block1
    {
        public bool IsFull { get => Degree == Helpers.Ai(Father.Node.Level); }

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

        internal void Add(Node left, Node right)
        {
            bool wasFull = IsFull;

            // find position to insert.
            Nodes.Insert(Nodes.FindIndex(x => x == left) + 1, right);
            right.Father = this;

            // Make sure the left/right pointers are set correctly.
            Node aux = left.Right;
            left.Right = right;
            right.Left = left;

            if (aux != null)
            {
                right.Right = aux;
                aux.Left = right;
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

        internal void TransferToMate()
        {
            //Just remove the node from this block1 and add it into the mate. 
            // The father pointer is updates, but the rest of them are not needed, since the transfer is made between mates, and since the nodes keep the left-right pointers even through the block1 bounds. 
            if(Mate == Right)
            {
                Node transferredNode = Nodes[Nodes.Count - 1]; // if the mate is on the right, then we transfer the last node to its mate, so that we can keep the order of the nodes unchanged.
                Nodes.Remove(transferredNode);
                Mate.Nodes.Insert(0, transferredNode);

                transferredNode.Father = Mate;                
            }
            else
            {
                Node transferredNode = Nodes[0]; //if the mate is on the left, then we transfer the first node to its mate, so that we can keep the order of the nodes unchanged.
                Nodes.Remove(transferredNode);
                Mate.Nodes.Add(transferredNode);

                transferredNode.Father = Mate;
            }
        }

        internal void Remove(Node e)
        {
            bool wasFull = IsFull;

            // Remove it from the list of nodes.
            Nodes.Remove(e);

            // Sort the left right pointers. (in order for them not to point to e)
            if (e.Left != null)
                e.Left.Right = e.Right;
            if (e.Right != null)
                e.Right.Left = e.Left;

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

            //If it was the full mate, then we try to transfer a node from its mate, as long as it has one.
            if (Mate != null)
            {
                Mate.TransferToMate();
            }
            else if(Right != null && Right.Mate == null) // If there is no mate but there is a right block1 that also has no mate, we make the pair and then transfer.
            {
                Mate = Right;
                Right.Mate = this;
                Mate.TransferToMate();
            }
            else if(Left != null && Left.Mate == null) // If there is no mate but there is a left block1 that also has no mate, we make a pair and transfer.
            {
                Mate = Left;
                Left.Mate = this;
                Mate.TransferToMate();
            }
            else if(Right != null) //If we still cannot make a pair, then we remove the first node from right, and add it to this block1
            {
                Node sharedNode = Right.Nodes[0];
                Right.Remove(sharedNode);
                Node lastNode = Nodes[Nodes.Count - 1];
                Add(lastNode, sharedNode);
            }
            else if(Left != null) // If there is no right then we try the same thing with left.
            {
                Node sharedNode = Left.Nodes[Left.Nodes.Count - 1];
                Left.Remove(sharedNode);
                Node lastNodeInLeft = Left.Nodes[Left.Nodes.Count - 1]; //Because this node is in the left block1 it will not be found, and while adding the node, it will be added on position 0. Also since it is the last node in left, the left,right pointers are sill the ones that we need for adding.
                Add(lastNodeInLeft, sharedNode);
            }
        }
    }
}
