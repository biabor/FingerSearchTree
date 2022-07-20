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

        /// <summary>
        /// Creates an empty Block1
        /// </summary>
        public Block1() { }

        /// <summary>
        /// Creates the block1 containing the leaf for the initial tree.
        /// </summary>
        /// <param name="node">The leaf.</param>
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

                int transferredPosition = 0;
                if (Mate == Right)
                    transferredPosition = Nodes.Count - 1;
                Node transferredNode = Nodes[transferredPosition];
                Mate.Remove(transferredNode);
                Mate.Transfer(transferredNode, transferredPosition != 0);
            }

            // if there is no place to insert, break the pair.
            if (IsFull && Mate != null && Mate.IsFull)
            {
                Block1 oldMate = Mate;
                Mate = null;
                oldMate.Mate = null;
            }
        }

        /// <summary>
        /// Mades the transfer by adding the node in this block1.
        /// </summary>
        /// <param name="node">Node to be added</param>
        /// <param name="atStart">bool saying if the node should be inserted in the beginning or at the end of the list.</param>
        internal void Transfer(Node node, bool atStart)
        {
            if (atStart)
                Nodes.Insert(0, node);
            else
                Nodes.Insert(Nodes.Count, node);
            node.Father = this;
            //Todo set left right pointers of node.
        }

        internal void Remove(Node e)
        {
            bool wasFull = IsFull;
            Nodes.Remove(e);

            if (e.Left != null)
                e.Left.Right = e.Right;
            if (e.Right != null)
                e.Right.Left = e.Left;

            if (Degree == 0)
            {
                Father.Remove(this);
                if (Mate != null) 
                    Mate.Mate = null;
                return;
            }

            if (wasFull == false)
                return;

            if (Mate != null)
            {
                int transferredPosition = 0;
                if (Mate == Left)
                    transferredPosition = Mate.Nodes.Count - 1;

                Node transferedNode = Mate.Nodes[transferredPosition];
                Mate.Remove(transferedNode);
                Transfer(transferedNode, transferredPosition != 0);
            }
            else if (Right != null && Right.Mate != null)
            {
                Node leftmostNodeFromRight = Right.Nodes[0];
                Right.Remove(leftmostNodeFromRight);
                Transfer(leftmostNodeFromRight, false);
            }
            else if (Right != null)
            {
                Mate = Right;
                Right.Mate = this;

                Node transferedNode = Mate.Nodes[0];
                Mate.Remove(transferedNode);
                Transfer(transferedNode, false);
            }
            else if (Left != null && Left.Mate != null)
            {
                Node rightmostNodeFromLeft = Left.Nodes[Left.Nodes.Count - 1];
                Left.Remove(rightmostNodeFromLeft);
                Transfer(rightmostNodeFromLeft, true);
            }
            else if(Left != null)
            {
                Mate = Left;
                Left.Mate = this;

                Node transferedNode = Mate.Nodes[Mate.Nodes.Count - 1];
                Mate.Remove(transferedNode);
                Transfer(transferedNode, Mate.Nodes.Count - 1 != 0);
            }
        }
    }
}
