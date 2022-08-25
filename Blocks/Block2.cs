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

        public Block2() { }

        public Block2(Block1 block1)
        {
            Blocks1.Add(block1);
            block1.Father = this;
        }

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

            // if it is a pending object there is no transfer needed. But if it became full then break it from the pair.
            if (Pending)
            {
                if (IsFull)
                {
                    Pending = false;
                    Mate = null;
                }
                
                return;
            }

            // if the block2 was already full before the insert, the treansfer one block1 to the mate. 
            if (wasFull)
            {
                // if there is no mate, then find one. 
                if (Mate == null)
                {
                    // if we can pair it with a pending block, we make the pair.
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
                    else
                    {
                        Mate = new Block2()
                        {
                            Mate = this
                        };

                        Node.Add(this, Mate);
                    }
                }

                TransferToMate();
            }

            // if both of them are full, and the break would not spoil invariant 5, then break the pair;
            if (IsFull && Mate != null && Mate.IsFull && IsBreakPossible())
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
                        Mate = null;
                    }

                    if (oldMate.Right.Pending && oldMate.Right.Mate == oldMate)
                    {
                        oldMate.Mate = oldMate.Right;
                        oldMate.Mate.Pending = false;
                    }
                    else
                    {
                        oldMate.Mate = null;
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
                        Mate = null;
                    }

                    if (oldMate.Left.Pending && oldMate.Left.Mate == oldMate)
                    {
                        oldMate.Mate = oldMate.Left;
                        oldMate.Mate.Pending = false;
                    }
                    else
                    {
                        oldMate.Mate = null;
                    }
                }
            }
        }

        internal void TransferToMate()
        {
            if(Mate == Right)
            {
                Block1 transferredBlock = Blocks1[Blocks1.Count - 1];
                Blocks1.Remove(transferredBlock);
                Mate.Blocks1.Insert(0, transferredBlock);

                transferredBlock.Father = Mate;
            }
            else
            {
                Block1 transferredBlock1 = Blocks1[0];
                Blocks1.Remove(transferredBlock1);
                Mate.Blocks1.Add(transferredBlock1);

                transferredBlock1.Father = Mate;
            }
        }

        internal void Remove(Block1 e)
        {
            bool wasFull = IsFull;

            // Remove it from the list of nodes.
            Blocks1.Remove(e);

            // Sort the left right pointers.
            if (e.Left != null)
                e.Left.Right = e.Right;
            if (e.Right != null)
                e.Right.Left = e.Left;

            // If it becomes empty, remove this block2 from its node, and also make sure that the Mate is announced. 
            if (Degree == 0)
            {
                Node.Remove(this);
                if (Pending == false && Mate != null)
                    Mate.Mate = null;
                return;
            }

            // If it is a pending block, then there is nothing else to do.
            if (Pending)
                return;

            // If it is not the full mate in the pair of blocks2, then there is no need to perform the transfers.
            if (wasFull == false)
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
            else if (Right != null &&  Right.Pending) // if there is a pending block to the right, then form a pair with this pending block.
            {
                Right.Pending = false;
                Right.Mate = this;
                Mate = Right;
                Mate.TransferToMate();
            }
            else if (Left != null && Left.Pending) // If there is a pending block to the left, then form a pair with this pending block.
            {
                Left.Pending = false;
                Left.Mate = this;
                Mate = Left;
                Mate.TransferToMate();
            }
            else if(Right != null) // If there is a right block1, but is not pending, then set this as the pending block.
            {
                Mate = Right;
                Pending = true;
            }
            else if (Left != null) // If there is a left block1, but is not pending, then set this as the pending block.
            {
                Mate = Left;
                Pending = true;
            }
        }

        private bool IsBreakPossible()
        {
            if (Mate == Right)
            {
                Block1 lastBlock1 = Blocks1[Blocks1.Count - 1];
                Node lastNode = lastBlock1.Nodes[lastBlock1.Nodes.Count - 1];

                return lastNode.Group != Mate.Blocks1[0].Nodes[0].Group;
            }
            else
            {
                Block1 lastBlock1 = Mate.Blocks1[Mate.Blocks1.Count - 1];
                Node lastNode = lastBlock1.Nodes[lastBlock1.Nodes.Count - 1];

                return lastNode.Group != Blocks1[0].Nodes[0].Group;
            }
        }
    }
}
