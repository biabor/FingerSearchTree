using System;
using System.Collections.Generic;
using GroupAndComponent;
using Blocks;
using System.Linq;
using FingerSearchTree;

namespace Nodes
{
    public class Node
    {
        public bool IsUnderContruction { get; set; } = false;

        public int Level { get; set; } = 0;

        public int Degree { get => Blocks2.Sum(x => x.Degree); }

        public Node Left { get; set; } = null;

        public Node Right { get; set; } = null;

        public Node FatherNode { get => Father?.Father?.Node; }

        public List<Block2> Blocks2 = new List<Block2>();

        public Block1 Father { get; set; } = null;

        public Group Group { get; set; } = null;

        public Component Component { get => Group?.Component; }

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
            Level= Blocks2[0].Blocks1[0].Nodes[0].Level + 1;
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

            if (Blocks2.Count >= 8) // TODO 4 * Helpers.BiP(Level))
            {
                Node wP = Split();
                if(FatherNode == null)
                {
                    new Node(new Block2(new Block1(this)));
                }
                Father.Add(this, wP);
                Group.Block2 = Father.Father;
            }
        }

        /// <summary>
        /// Splits the Node into two nodes.
        /// </summary>
        /// <param name="u">The node that needs to be split in two.</param>
        /// <returns>The right part of the node.</returns>
        public Node Split()
        {
            Node wP = new Node
            {
                Blocks2 = Blocks2.GetRange(Blocks2.Count / 2, Blocks2.Count - Blocks2.Count / 2),
                Level = Level
            };

            Group.Add(wP);
            Blocks2.RemoveRange(Blocks2.Count / 2, Blocks2.Count - Blocks2.Count / 2);

            return wP;
        }

    }
}
