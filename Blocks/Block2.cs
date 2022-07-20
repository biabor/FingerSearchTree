using System;
using System.Collections.Generic;
using System.Linq;
using FingerSearchTree;
using GroupAndComponent;
using Nodes;

namespace Blocks
{
    public class Block2
    {
        public bool IsFull => Helpers.Ai(Node.Level) <= Degree && Degree <= Helpers.BiP(Node.Level) + Helpers.RiP(Node.Level - 1);

        public bool Pending { get; set; } = false;

        public int Degree { get => Blocks1.Sum(x => x.Degree); }

        public List<Block1> Blocks1 = new List<Block1>();

        public Node Node { get; set; } = null;

        public Block2 Mate { get; set; } = null;

        public Block2 Left { get; set; } = null;

        public Block2 Right { get; set; } = null;

        public Group Group { get; set; } = null;

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
        }

        /// <summary>
        /// Adds the block1 right to the right of the block1 left.
        /// </summary>
        /// <param name="left">The block1 next to which it needs to be inserted.</param>
        /// <param name="right">The block1 that needs to be inserted.</param>
        internal void Add(Block1 left, Block1 right)
        {
            bool wasFull = IsFull;
            // find position to insert.
            Blocks1.Insert(Blocks1.FindIndex(x => x == left) + 1, right);
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

            if (Pending)
            {
                if (IsFull)
                {
                    Pending = false;
                    Mate = null;
                }
                else return;
            }

            if (wasFull)
            {
                if (Mate == null)
                {
                    if (Right != null && Right.Pending && Right.Mate == this)
                    {
                        Right.Pending = false;
                        Mate = Right;
                    }
                    else if (Left != null && Left.Pending && Left.Mate == this)
                    {
                        Left.Pending = false;
                        Mate = Left;
                    }
                }

                int transferredPosition = 0;
                if (Mate != Left)
                    transferredPosition = Blocks1.Count - 1;

                if (Invariant5Holds(Blocks1[transferredPosition]))
                {
                    if(Mate == null)
                    {
                        Mate = new Block2()
                        {
                            Mate = this
                        };
                        Node.Add(this, Mate);
                    }

                    Block1 transferredNode = Blocks1[transferredPosition];
                    Remove(transferredNode);
                    Mate.Transfer(transferredNode, transferredPosition != 0);
                }
            }

            if (IsFull && Mate != null && Mate.IsFull)
            {
                Block2 oldMate = Mate;

                if (Mate == Right)
                {
                    if (Left.Pending && Left.Mate == this)
                    {
                        Mate = Left;
                        Mate.Pending = false;
                    }
                    else
                    {
                        Mate = new Block2
                        {
                            Mate = this
                        };
                        Node.Add(this, Mate);
                    }

                    if (oldMate.Right.Pending && oldMate.Right.Mate == oldMate)
                    {
                        oldMate.Mate = oldMate.Right;
                        oldMate.Mate.Pending = false;
                    }
                    else
                    {
                        oldMate.Mate = new Block2
                        {
                            Mate = oldMate
                        };
                        oldMate.Node.Add(oldMate, oldMate.Mate);
                    }
                }
                else
                {
                    if (Right.Pending && Right.Mate == this)
                    {
                        Mate = Right;
                        Mate.Pending = false;
                    }
                    else
                    {
                        Mate = new Block2()
                        {
                            Mate = this
                        };
                        Node.Add(this, Mate);
                    }

                    if (oldMate.Left.Pending && oldMate.Left.Mate == oldMate)
                    {
                        oldMate.Mate = oldMate.Left;
                        oldMate.Mate.Pending = false;
                    }
                    else
                    {
                        oldMate.Mate = new Block2
                        {
                            Mate = oldMate
                        };
                        oldMate.Node.Add(oldMate, oldMate.Mate);
                    }
                }
            }
        }

        private bool Invariant5Holds(Block1 blockToBeTransferred)
        {
            Node firstNode = blockToBeTransferred.Nodes[0];
            Node lastNode = blockToBeTransferred.Nodes[blockToBeTransferred.Nodes.Count - 1];

            Group firstGroup = firstNode.Group;
            Group lastGroup = lastNode.Group;

            if (firstGroup.Nodes[0] != firstNode)
                return false;

            if (lastGroup.Nodes[0] != lastNode)
                return false;

            return true;
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
            // add pointers to left right of this block1.
        }

        internal void Remove(Block1 e)
        {
            bool wasFull = IsFull;

            Blocks1.Remove(e);

            if (e.Left != null)
                e.Left.Right = e.Right;
            if (e.Right != null)
                e.Right.Left = e.Left;

            if (Degree == 0)
            {
                Node.Remove(this);
                if (Pending == false && Mate != null)
                    Mate.Mate = null;
                return;
            }

            if (wasFull == false)
                return;

            if (Pending)
                return;

            if (Mate != null)
                return;

            if (Left.Pending && Left.Mate.Mate == this)
            {
                Left.Pending = false;
                Mate = Left;
            }
            else if (Right.Pending && Right.Mate.Mate == this)
            {
                Right.Pending = false;
                Mate = Right;
            }
        }
    }
}
