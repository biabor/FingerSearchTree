using System.Collections.Generic;
using System.Linq;
using Nodes;

namespace Blocks
{
    public class Block2
    {
        public bool IsFull
        {
            get
            {
                Node childNode = Blocks1[0].Nodes[0];
                return Degree == Node.BiP + childNode.RiP;
            }
        }

        public bool IsInvariant3Maintained
        {
            get
            {
                Node childNode = Blocks1[0].Nodes[0];
                return Node.Ai <= Degree && Degree <= Node.BiP + childNode.RiP;
            }
        }

        public int Degree { get => Blocks1.Sum(x => x.Degree); }

        public List<Block1> Blocks1 = new List<Block1>();

        public Node Node { get; set; } = null;

        public Block2 Mate { get; set; } = null;

        public Block2 Left { get; set; } = null;

        public Block2 Right { get; set; } = null;

        /// <summary>
        /// Creates an empty Block2
        /// </summary>
        public Block2() { }

        /// <summary>
        /// Creates the block2 containing the block1 in the initial tree.
        /// </summary>
        /// <param name="block1"></param>
        public Block2(Block1 block1)
        {
            Blocks1.Add(block1);
            block1.Father = this;

            Blocks1.Add(block1.Mate);
            block1.Mate.Father = this;

            Mate = new Block2
            {
                Mate = this,
                Left = this
            };

            Right = Mate;
        }

        /// <summary>
        /// Adds the block1 right to the right of the block1 left.
        /// </summary>
        /// <param name="left">The block1 next to which it needs to be inserted.</param>
        /// <param name="right">The block1 that needs to be inserted.</param>
        internal void Add(Block1 left, Block1 right)
        {
            if (IsFull && Mate != null && Mate.IsFull)
            {
                //if (Invariant5Holds()) // TODO
                //{
                Block2 oldMate = Mate;

                Mate = new Block2
                {
                    Mate = this
                };
                Node.Add(this, Mate);

                oldMate.Mate = new Block2
                {
                    Mate = oldMate
                };
                oldMate.Node.Add(oldMate, oldMate.Mate);
                //}
            }

            // find position to insert.
            int position = Blocks1.FindIndex(x => x == left);
            position++;

            // actually insert in the list.
            Blocks1.Insert(position, right);
            right.Father = this;

            // Make sure the left/right pointers are set correctly.
            Block1 aux = left.Right;
            left.Right = right;
            right.Left = left;

            if (aux != null)
            {
                right.Right = aux;
                aux.Left = right;
            }

            if (IsInvariant3Maintained == false)
            {
                int transferredPosition = -1;
                if (Mate == Right)
                    transferredPosition = Blocks1.Count - 1;
                else
                    transferredPosition = 0;

                Mate.Transfer(Blocks1[transferredPosition], transferredPosition != 0);
                Blocks1.RemoveAt(transferredPosition);
            }
        }

        /// <summary>
        /// Mades the transfer by adding the node in this block1.
        /// </summary>
        /// <param name="block1">Node to be added</param>
        /// <param name="atStart">bool saying if the node should be inserted in the beginning or at the end of the list.</param>
        internal void Transfer(Block1 block1, bool atStart)
        {
            if (atStart)
                Blocks1.Insert(0, block1);
            else
                Blocks1.Insert(Blocks1.Count, block1);
            block1.Father = this;
        }
    }
}
