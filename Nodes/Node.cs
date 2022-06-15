using System;
using System.Collections.Generic;
using GroupAndComponent;
using Blocks;

namespace Nodes
{
    public class Node
    {
        public bool IsUnderContruction { get; set; } = false;

        public int Level { get; set; } = 0;

        public long Bi { get => (long)/*Math.Pow(2, */Math.Pow(2, 2 * Level + 4)/*)*/; }

        public long BiP { get => (long) /*Math.Pow(2,*/ Math.Pow(2, 2 * Level + 3) - 2/*)*/; } //Bi'

        public long Ai { get => (long)/*Math.Pow(2, */Math.Pow(2, 2 * Level)/*)*/; }

        public long Fi { get => (long)/*Math.Pow(2, */Math.Pow(2, 2 * Level + 1)/*)*/; }

        public long Ri { get => Bi / BiP; }

        public Node Left { get; set; } = null;

        public Node Right { get; set; } = null;

        public Node FatherNode { get => Father == null || Father.Father == null || Father.Father.Node == null ? null : Father.Father.Node; }

        public List<Block2> Blocks2 = new List<Block2>();

        public Block1 Father { get; set; } = null;

        public Group Group { get; set; } = null;

        public Node() { }

        /// <summary>
        /// Creates the father node/root of the initial tree.
        /// </summary>
        /// <param name="block2">block2 it contains</param>
        public Node(Block2 block2)
        {
            Blocks2.Add(block2);
            block2.Node = this;

            Blocks2.Add(block2.Mate);
            block2.Mate.Node = this;

            Group = new Group(this);
            Level++;
        }

        /// <summary>
        /// Adds the block2 right to the right of the block2 left.
        /// </summary>
        /// <param name="left">The block2 next to which it needs to be inserted.</param>
        /// <param name="right">The block2 that needs to be inserted.</param>
        internal void Add(Block2 left, Block2 right)
        {
            // find position to insert.
            int position = Blocks2.FindIndex(x => x == left);
            position++;

            // actually insert in the list.
            Blocks2.Insert(position, right);
            right.Node = this;

            // Make sure the left/right pointers are set correctly.
            Block2 aux = left.Right;
            left.Right = right;
            right.Left = left;

            if (aux != null)
            {
                right.Right = aux;
                aux.Left = right;
            }
        }

    }
}
