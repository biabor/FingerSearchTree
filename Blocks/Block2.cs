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
            Block1 rightTest = left.Right;

            left.Right = middle;
            middle.Left = left;

            if (pos < Blocks1.Count - 1)
            {
                Block1 right = Blocks1[pos + 1];
                if(right != rightTest)
                { int ok; }
                if(right.Left != left)
                { int ok; }
                middle.Right = right;
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
            Block1 rightTest = null;
            Block1 leftTest = null;
            if (position != 0)
            {
                Block1 left = Blocks1[position - 1];
                rightTest = left.Right;
                middle.Left = left;
                left.Right = middle;
                middle.NewNode = left.NewNode;
            }

            if (position != Blocks1.Count - 1)
            {
                Block1 right = Blocks1[position + 1];
                leftTest = right.Left;
                if(rightTest != null && right != rightTest)
                { int ok; }
                if(position != 0 && Blocks1[position -1 ] != leftTest)
                { int ok; }
                middle.Right = right;
                right.Left = middle;
                middle.NewNode = right.NewNode;
            }
        }

        internal void TransferToMate()
        {
            if (Mate == Right)
            {
                Block1 transferredBlock = Blocks1[Blocks1.Count - 1];
                Remove(transferredBlock, true);
                Mate.Add(0, transferredBlock);

                transferredBlock.NewNode = Node;
                transferredBlock.OldNode = Mate.Node;

                if (transferredBlock.Mate != null)
                {
                    if (transferredBlock.Mate == Blocks1[Blocks1.Count - 1])
                    {
                        Block1 transferredBlockMate = Blocks1[Blocks1.Count - 1];
                        Remove(transferredBlockMate, true);
                        Mate.Add(0, transferredBlockMate);

                        transferredBlockMate.NewNode = Node;
                        transferredBlockMate.OldNode = Mate.Node;

                        if (transferredBlock.Mate != transferredBlockMate || transferredBlockMate.Mate != transferredBlock || transferredBlock.Mate != transferredBlock.Left || transferredBlockMate.Mate != transferredBlockMate.Right)
                        { int ok; }
                    }
                    else
                    {
                        int ok;
                    }
                }
            }
            else if(Mate == Left)
            {
                Block1 transferredBlock = Blocks1[0];
                Remove(transferredBlock, true);
                Mate.Add(Mate.Blocks1.Count, transferredBlock);

                transferredBlock.NewNode = Node;
                transferredBlock.OldNode = Mate.Node;

                if (transferredBlock.Mate != null)
                {
                    if (transferredBlock.Mate == Blocks1[0])
                    {
                        Block1 transferredBlockMate = Blocks1[0];
                        Remove(transferredBlockMate, true);
                        Mate.Add(Mate.Blocks1.Count, transferredBlockMate);

                        transferredBlockMate.NewNode = Node;
                        transferredBlockMate.OldNode = Mate.Node;

                        if (transferredBlock.Mate != transferredBlockMate || transferredBlockMate.Mate != transferredBlock || transferredBlock.Mate != transferredBlock.Right || transferredBlockMate.Mate != transferredBlockMate.Left)
                        { int ok; }
                    }
                    else
                    {
                        int ok;
                    }
                }
            }
            else
            { int ok;  }
        }

        internal void Remove(Block1 e, bool justForTransfer = false)
        {
            bool wasFull = IsFull;
            
            int position = Blocks1.FindIndex(x => x == e);

            // Remove it from the list of nodes.
            Blocks1.Remove(e);

            Block1 left = null;
            Block1 right = null;

            // Sort the left right pointers.
            if (position != 0)
                left = Blocks1[position - 1];
            if (position <= Blocks1.Count - 1)
                right = Blocks1[position];

            if (left != e.Left)
            { int ok; }
            if (right != e.Right)
            { int ok; }

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

            // If it is a pending block, then there is nothing else to do.
            if (Pending)
                return;

            // If it is not the full mate in the pair of blocks2, then there is no need to perform the transfers.
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
            else if (Right != null && Right.Pending) // If there is a pending block to the right, then form a pair with this pending block.
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
            else if (Right != null) // If there is a right block1, but is not pending, then set this as the pending block.
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

        internal bool IsBreakPossible()
        {
            if (Mate == Right)
            {
                try
                {
                    Block1 lastBlock1 = Blocks1[Blocks1.Count - 1];
                    if (lastBlock1.Nodes.Count == 0)
                        lastBlock1 = lastBlock1.Left;
                    Node lastNode = lastBlock1.Nodes[lastBlock1.Nodes.Count - 1];

                    if (lastNode is Leaf)
                        return true;

                    return lastNode.Group != lastNode.Right.Group;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else if(Mate == Left)
            {
                try
                {
                    Block1 lastBlock1 = Mate.Blocks1[Mate.Blocks1.Count - 1];
                    if (lastBlock1.Nodes.Count == 0)
                        lastBlock1 = lastBlock1.Left;
                    Node lastNode = lastBlock1.Nodes[lastBlock1.Nodes.Count - 1];

                    if (lastNode is Leaf)
                        return true;

                    return lastNode.Group != lastNode.Left.Group;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else { return false; }
        }
    }
}
