using System.Collections.Generic;
using FingerSearchTree;
using Nodes;

namespace Blocks
{
    public class Block1
    {
        public bool IsFull { get => Degree == Helpers.Ai(Father.Node.Level); }

        public bool IsInvariant2Maintained { get => Degree <= Helpers.Ai(Father.Node.Level); }

        public int Degree { get => Nodes.Count; }

        public List<Node> Nodes = new List<Node>();

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

            Mate = new Block1
            {
                Mate = this,
                Left = this
            };

            Right = Mate;
        }

        /// <summary>
        /// Adds the node right to the right of the node left.
        /// </summary>
        /// <param name="left">The node next to which it needs to be inserted.</param>
        /// <param name="right">The node that needs to be inserted.</param>
        internal void Add(Node left, Node right)
        {
            // find position to insert.
            int position = Nodes.FindIndex(x => x == left);
            position++;

            // actually insert in the list.
            Nodes.Insert(position, right);
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

            // If this block1 is overfull then transfer to one node to the mate.
            if (IsInvariant2Maintained == false)
            {
                int transferredPosition = -1;
                if (Mate == Right)
                    transferredPosition = Nodes.Count - 1;
                else
                    transferredPosition = 0;

                Mate.Transfer(Nodes[transferredPosition], transferredPosition != 0);
                Nodes.RemoveAt(transferredPosition);
            }

            // if there is no place to insert, break the pair.
            if (IsFull && Mate != null && Mate.IsFull)
            {
                Block1 oldMate = Mate;

                Mate = new Block1
                {
                    Mate = this
                };
                Father.Add(this, Mate);

                oldMate.Mate = new Block1
                {
                    Mate = oldMate
                };
                oldMate.Father.Add(oldMate, oldMate.Mate);
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
        }
    }
}
