using Blocks;
using GroupAndComponent;
using Nodes;
using System.Collections.Generic;

namespace FingerSearchTree
{
    public static class Tree
    {
        public static Leaf CreateList()
        {
            return new Leaf();
        }

        public static Leaf Insert(Leaf left, int value)
        {
            Leaf right = new Leaf(value);
            InsertLeaf(left, right);

            Group r = Find(right.FatherNode);

            if (MultiBreak(r))
            {
                Node u = r.Block2.Node;
                Node uP = Split(u);
                if (uP != null)
                {
                    if (u.FatherNode == null)
                        new Node(new Block2(new Block1(u)));
                    u.Father.Add(u, uP);
                }
            }

            return right;
        }

        /// <summary>
        /// Splits the Node into two nodes, by transferring the rightmost pair of blocks2 from u to uP.
        /// </summary>
        /// <param name="u">The node that needs to be split in two.</param>
        /// <returns>The right part of the node.</returns>
        private static Node Split(Node u)
        {
            Component temp = u.Component;
            u.Group = new Group(u)
            {
                Component = temp,
                IsSplitGroup = true
            };
            u.IsUnderContruction = true;

            if (u.Blocks2.Count < 4)
                return null;

            Node uP = new Node
            {
                Blocks2 = new List<Block2>()
                {
                    u.Blocks2[u.Blocks2.Count - 1],
                    u.Blocks2[u.Blocks2.Count - 1].Mate
                },
                Level = u.Level,
            };

            u.Group.Add(uP);

            u.Blocks2.RemoveAll(elem => uP.Blocks2.Contains(elem));

            return uP;
        }

        /// <summary>
        /// Finds the root group of the component containing the group f, which in itself contains node node
        /// </summary>
        /// <param name="f">group </param>
        /// <param name="node">node</param>
        /// <returns>Root group of the component containing the group f</returns>
        private static Group Find(Node f)
        {
            if (f.Group.Valid && f.Component.Valid)
                return f.Component.Root;

            if (f.Group.Valid)
                f.Group.Component = new Component(f.Group);
            else
                f.Group = new Group(f);
            return f.Group;
        }

        /// <summary>
        /// Performs the MultiSplit/MultiFusion operation.
        /// </summary>
        /// <param name="r">The group in question</param>
        /// <returns>True, if a rebalancing operation is needed, false otherwise.</returns>
        private static bool MultiBreak(Group r)
        {
            if (r.Nodes.Count == Helpers.RiP(r.Nodes[0].Level))
            {
                r.Valid = false;
                r.Component.Valid = false;
                r.Component = r.Block2.Node.Component;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Inserts the right leaf to the right of the left one in the parent of the left one.
        /// </summary>
        /// <param name="left">the left leaf.</param>
        /// <param name="right">the right leaf.</param>
        private static void InsertLeaf(Leaf left, Leaf right)
        {
            left.Father.Add(left, right);
            right.Group.Block2 = right.Father.Father;
        }
    }
}
