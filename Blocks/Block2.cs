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
        public bool IsFull =>
            Group.IsSplitGroup ?
            Helpers.BiP(Node.Level) <= Degree :// && Degree <= Helpers.BiP(Node.Level) + Helpers.RiP(Node.Level - 1) :
            Helpers.Fi(Node.Level) <= Degree; //&& Degree <= Helpers.Fi(Node.Level) + 2 * Helpers.Ri(Node.Level - 1);

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

        internal bool ContainsValue(int value)
        {
            return Blocks1[0].Nodes[0].Min <= value && value <= Blocks1[Blocks1.Count - 1].Nodes[Blocks1[Blocks1.Count - 1].Nodes.Count - 1].Max;
        }

        internal Node FindChildContaining(int value)
        {
            int minpos = 0;
            int maxpos = Blocks1.Count - 1;
            int midpos = (minpos + maxpos) / 2;
            while (Blocks1[midpos].ContainsValue(value) == false && minpos < maxpos)
            {
                if (Blocks1[midpos].Nodes[0].Min > value)
                    maxpos = midpos - 1;
                else
                    minpos = midpos + 1;
                midpos = (maxpos + minpos) / 2;
            }

            if (Blocks1[midpos].ContainsValue(value))
                return Blocks1[midpos].FindChildContaining(value);
            else if (Blocks1[midpos].Nodes[Blocks1[midpos].Nodes.Count - 1].Max < value)
                return Blocks1[midpos].Nodes[Blocks1[midpos].Nodes.Count - 1];
            else
                return Blocks1[midpos].Nodes[0].Left;
        }

        internal void Add(Block1 left, Block1 middle)
        {
            // find position to insert.
            int pos = Blocks1.FindIndex(x => x == left) + 1;
            Blocks1.Insert(pos, middle);
            middle.Father = this;

            // Make sure the left/right pointers are set correctly.
            Block1 right = left.Right;
            left.Right = middle;
            middle.Left = left;
            middle.Right = right;

            if (right != null)
            {
                right.Left = middle;
            }

            middle.NewNode = left.NewNode;
        }

        internal void Add(int position, Block1 middle)
        {
            // find position to insert.
            Blocks1.Insert(position, middle);
            middle.Father = this;

            // Make sure the left/right pointers are set correctly.
            Block1 left = null;
            Block1 right = null;

            if (position != 0)
            {
                left = Blocks1[position - 1];
                left.Right = middle;
                middle.NewNode = left.NewNode;
            }

            if (position != Blocks1.Count - 1)
            {
                right = Blocks1[position + 1];
                right.Left = middle;
                middle.NewNode = right.NewNode;
            }

            middle.Right = right;
            middle.Left = left;
        }

        internal void TransferToMate()
        {
            if (Mate == Right)
            {
                Block1 transferredBlockFrom = Blocks1[Blocks1.Count - 1];
                if (Mate.Blocks1.Count == 0)
                {
                    Mate.Blocks1.Add(new Block1() { NewNode = Mate.Node, Father = Mate });
                }
                Block1 transferredBlockTo = Mate.Blocks1[0];
                Node transferredNode = transferredBlockFrom.Nodes[transferredBlockFrom.Nodes.Count - 1];

                bool wasFullBlockTo = transferredBlockTo.IsFull;
                bool wasFullBlockFrom = transferredBlockFrom.IsFull;

                transferredBlockFrom.Remove(transferredNode);

                if (wasFullBlockFrom)
                {
                    if(transferredBlockFrom.Mate != null)
                    {
                        transferredBlockFrom.Mate.TransferToMate();
                    }
                    else if(transferredBlockFrom.Right != null && transferredBlockFrom.Right.Mate == null)
                    {
                        transferredBlockFrom.Mate = transferredBlockFrom.Right;
                        transferredBlockFrom.Right.Mate = transferredBlockFrom;
                        transferredBlockFrom.Mate.TransferToMate();
                    }
                    else if(transferredBlockFrom.Left != null && transferredBlockFrom.Left.Mate == null)
                    {
                        transferredBlockFrom.Mate = transferredBlockFrom.Left;
                        transferredBlockFrom.Left.Mate = transferredBlockFrom;
                        transferredBlockFrom.Mate.TransferToMate();
                    }
                    else if(transferredBlockFrom.Right != null)
                    {
                        Node sharedNode = transferredBlockFrom.Right.Nodes[0];
                        bool wasFullRight = transferredBlockFrom.Right.IsFull;
                        transferredBlockFrom.Right.Remove(sharedNode);
                        if (wasFullRight)
                        {
                            transferredBlockFrom.Right.Mate.TransferToMate();
                        }
                        transferredBlockFrom.Add(transferredBlockFrom.Nodes.Count, sharedNode);
                    }
                    else if(transferredBlockFrom.Left != null)
                    {
                        Node sharedNode = transferredBlockFrom.Left.Nodes[transferredBlockFrom.Left.Nodes.Count - 1];
                        bool wasFullLeft = transferredBlockFrom.Left.IsFull;
                        transferredBlockFrom.Left.Remove(sharedNode);
                        if(wasFullLeft)
                        {
                            transferredBlockFrom.Left.Mate.TransferToMate();
                        }
                        transferredBlockFrom.Add(0, sharedNode);
                    }
                }

                transferredBlockTo.Add(0, transferredNode);

                if (wasFullBlockTo)
                {
                    if (transferredBlockTo.Mate == null)
                    {
                        transferredBlockTo.Mate = new Block1()
                        {
                            Mate = transferredBlockTo
                        };
                        transferredBlockTo.Father.Add(transferredBlockTo, transferredBlockTo.Mate);
                    }
                    transferredBlockTo.TransferToMate();
                }

                if(transferredBlockTo.IsFull && transferredBlockTo.Mate != null && transferredBlockTo.Mate.IsFull)
                {
                    transferredBlockTo.Mate.Mate = null;
                    transferredBlockTo.Mate = null;
                }
            }
            else if (Mate == Left)
            {
                Block1 transferredBlockFrom = Blocks1[0];
                if (Mate.Blocks1.Count == 0)
                {
                    Mate.Blocks1.Add(new Block1() { NewNode = Mate.Node, Father = Mate });
                }
                Block1 transferredBlockTo = Mate.Blocks1[Mate.Blocks1.Count - 1];
                Node transferredNode = transferredBlockFrom.Nodes[0];

                bool wasFullBlockTo = transferredBlockTo.IsFull;
                bool wasFullBlockFrom = transferredBlockFrom.IsFull;

                transferredBlockFrom.Remove(transferredNode);

                if (wasFullBlockFrom)
                {
                    if (transferredBlockFrom.Mate != null)
                    {
                        transferredBlockFrom.Mate.TransferToMate();
                    }
                    else if (transferredBlockFrom.Right != null && transferredBlockFrom.Right.Mate == null)
                    {
                        transferredBlockFrom.Mate = transferredBlockFrom.Right;
                        transferredBlockFrom.Right.Mate = transferredBlockFrom;
                        transferredBlockFrom.Mate.TransferToMate();
                    }
                    else if (transferredBlockFrom.Left != null && transferredBlockFrom.Left.Mate == null)
                    {
                        transferredBlockFrom.Mate = transferredBlockFrom.Left;
                        transferredBlockFrom.Left.Mate = transferredBlockFrom;
                        transferredBlockFrom.Mate.TransferToMate();
                    }
                    else if (transferredBlockFrom.Right != null)
                    {
                        Node sharedNode = transferredBlockFrom.Right.Nodes[0];
                        bool wasFullRight = transferredBlockFrom.Right.IsFull;
                        transferredBlockFrom.Right.Remove(sharedNode);
                        if (wasFullRight)
                        {
                            transferredBlockFrom.Right.Mate.TransferToMate();
                        }
                        transferredBlockFrom.Add(transferredBlockFrom.Nodes.Count, sharedNode);
                    }
                    else if (transferredBlockFrom.Left != null)
                    {
                        Node sharedNode = transferredBlockFrom.Left.Nodes[transferredBlockFrom.Left.Nodes.Count - 1];
                        bool wasFullLeft = transferredBlockFrom.Left.IsFull;
                        transferredBlockFrom.Left.Remove(sharedNode);
                        if (wasFullLeft)
                        {
                            transferredBlockFrom.Left.Mate.TransferToMate();
                        }
                        transferredBlockFrom.Add(0, sharedNode);
                    }
                }

                transferredBlockTo.Add(transferredBlockTo.Nodes.Count, transferredNode);

                if (wasFullBlockTo)
                {
                    if (transferredBlockTo.Mate == null)
                    {
                        transferredBlockTo.Mate = new Block1()
                        {
                            Mate = transferredBlockTo
                        };
                        transferredBlockTo.Father.Add(transferredBlockTo, transferredBlockTo.Mate);
                    }
                    transferredBlockTo.TransferToMate();
                }

                if (transferredBlockTo.IsFull && transferredBlockTo.Mate != null && transferredBlockTo.Mate.IsFull)
                {
                    transferredBlockTo.Mate.Mate = null;
                    transferredBlockTo.Mate = null;
                }
            }
        }

        internal void Remove(Block1 e)
        {
            // Remove it from the list of nodes.
            Blocks1.Remove(e);

            Block1 left = e.Left;
            Block1 right = e.Right;

            if (left != null)
                left.Right = right;
            if (right != null)
                right.Left = left;

            // If it becomes empty, remove this block2 from its node, and also make sure that the Mate is announced. 
            if (Blocks1.Count == 0)
            {
                Node.Remove(this);
                if (Pending == false && Mate != null)
                    Mate.Mate = null;
                return;
            }
        }

        internal bool IsBreakPossible()
        {
            if (Mate == Right)
            {
                Block1 lastBlock1 = Blocks1[Blocks1.Count - 1];
                if (lastBlock1.Nodes.Count == 0)
                    lastBlock1 = lastBlock1.Left;
                Node lastNode = lastBlock1.Nodes[lastBlock1.Nodes.Count - 1];

                if (lastNode is Leaf)
                    return true;

                return lastNode.Group != lastNode.Right.Group;
            }
            else if (Mate == Left)
            {
                Block1 lastBlock1 = Mate.Blocks1[Mate.Blocks1.Count - 1];
                if (lastBlock1.Nodes.Count == 0)
                    lastBlock1 = lastBlock1.Left;
                Node lastNode = lastBlock1.Nodes[lastBlock1.Nodes.Count - 1];

                if (lastNode is Leaf)
                    return true;

                return lastNode.Group != lastNode.Left.Group;
            }
            else
                return false;
        }
    }
}
