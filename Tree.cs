using Blocks;
using GroupAndComponent;
using Nodes;
using System;
using System.Collections.Generic;

namespace FingerSearchTree
{
    public static class Tree
    {
        public static Leaf CreateList()
        {
            return new Leaf();
        }

        internal static Leaf Search(Leaf lastLeaf, int value)
        {
            Node temp = lastLeaf;

            while (temp.ContainsValue(value) == false)
            {
                if (temp.Left != null && temp.Left.ContainsValue(value))
                    temp = temp.Left;
                else if (temp.Right != null && temp.Right.ContainsValue(value))
                    temp = temp.Right;
                else if (temp.FatherNode != null)
                    temp = temp.FatherNode;
                else
                    break;
            }

            while (temp is Leaf == false)
                temp = temp.FindChildContaining(value);

            return temp as Leaf;
        }

        public static Leaf Insert(Leaf left, int value)
        {
            Leaf newLeaf = new Leaf(value);
            left.Father.Add(left, newLeaf);

            Update(left);

            return newLeaf;
        }

        #region Private Methods.

        private static void Update(Leaf left)
        {
            Node rootR = Find(left.Father);

            #region Get Pointers.

            Group r = rootR.Group;
            Group rP = r.Left;
            Group rPP = r.Right;

            Block1 qz = rootR.Father;
            Node u = qz.OldNode;
            Node uP = qz.NewNode;
            Group z = u.Group;

            Group y = z.Right;
            Group w = z.Left;
            Group x = u.Father.Father.Group;

            int i = rootR.Level + 1;
            int rDeg = r.Degree;
            int zDeg = z.Degree;

            #endregion Get Pointers.  

            MultiBreak(r);

            if (Helpers.Fi(i - 1) * 4 < rDeg && rDeg < Helpers.BiP(i - 1))
                r.IsSplitGroup = true;

            if (rDeg < Helpers.Fi(i)) // F_i-1?
            {
                if (r.Degree + rP.Degree < 4 * Helpers.Fi(i)) // F_i-1?
                    GFuse(r, rP);
                else
                    GShare(r, rP);
            }

            if (Helpers.Fi(i) * 4 < zDeg && zDeg < Helpers.BiP(i - 1))
            {
                Block2 pz = r.Block2;
                Block2 pzP = pz.Mate;

                if (zDeg > 8 * Helpers.Fi(i))
                {
                    if (pz.Degree > pzP.Degree)
                    {
                        // Tranfer a block1 from pz to pzp
                    }
                    else
                    {
                        // Transfer a block1 from pzp to pz
                    }
                }
                else
                {
                    if (pz.Degree > Helpers.Fi(i))
                    {
                        // Transfer a block1 from pz to its mate pzp.
                    }
                    else
                    {
                        // Transfer a block1 from pz to a new block2 pzp.
                    }
                }
            }
            else if (zDeg >= Helpers.BiP(i))
            {
                if (ContainsAtLeastTwoBlock2Pairs(u))
                {
                    Node uPP = Split(u);
                    u.Father.Add(u, uPP);
                }

                Block1 qx = u.Father;
                if (qx.Degree < Helpers.Ai(i) && qx.Mate == null) // A_i-1?
                {
                    if (qx.OldNode == qx.Left?.OldNode || qx.NewNode == qx.Left?.OldNode)
                    {
                        // Update qx.oldnode and qx.newnode as lines 22-26 of delete(l)
                        // Make a pair if possible btw qx and one of qx.left or qx.right
                    }
                    else if(qx.OldNode == qx.Right?.OldNode || qx.NewNode == qx.Right?.NewNode)
                    {
                        // Update qx.oldnode and qx.newnode as lines 22-26 of delete(l)
                        // Make a pair if possible btw qx and one of qx.left or qx.right
                    }
                }
            }
            else
            {
                if (z.IsSplitGroup)
                    z.IsSplitGroup = false;

                // Lines 5-33 if the delete(l) algorithm in fig.17
            }

        }

        private static bool ContainsAtLeastTwoBlock2Pairs(Node u)
        {
            switch (u.Blocks2.Count)
            {
                case 0: return false;
                case 1: return false;
                case 2: return u.Blocks2[0].Mate != u.Blocks2[1];
                case 3:
                    if (u.Blocks2[1].Pending) return true;
                    return u.Blocks2[0].Mate == null || u.Blocks2[2].Mate == null;
                case 4: return u.Blocks2[0].Pending == false || u.Blocks2[3].Pending == false;
                default: return true;

            }
        }

        private static Node Find(Block1 father)
        {
            Node f = father.Father.Node;

            if (f.Group.IsSplitGroup)
            {
                if (f.Group.Valid)
                {
                    if (f.Component.Valid == false)
                        f.Component = new Component(f);
                }
                else
                {
                    f.Group = new Group() { Block2 = f.Father?.Father };
                    f.Component = new Component(f);
                }
            }
            else
            {
                f = father.OldNode.Group.Valid ? father.OldNode : father.NewNode;

                if (f.Component.Valid == false)
                    f.Component = new Component(f);
            }

            return f.Component.Root;
        }

        private static void MultiBreak(Group g)
        {
            g.Valid = false;
            if (g.IsSplitGroup)
                g.Component.Valid = false;
            else if (g.Mate != null && g.Mate.Valid == false)
            {
                MultiBreak(g.Mate);

                g.Nodes[0].Component = g.Block2.Node.Component;
            }

            g.Component = g.Block2.Node.Component;
        }

        private static void GFuse(Group g, Group gP)
        {
            g.Mate = gP;
            gP.Mate = g;
            if (g.Degree < Helpers.Fi(g.Nodes[0].Level) && g.IsSplitGroup == false)
            {
                if (g.Left == gP)
                    gP.Incr = g.Nodes[0].Blocks2[0].Blocks1[0];
                else
                    gP.Incr = g.Nodes[g.Nodes.Count - 1]
                        .Blocks2[g.Nodes[g.Nodes.Count - 1].Blocks2.Count - 1]
                        .Blocks1[g.Nodes[g.Nodes.Count - 1].Blocks2[g.Nodes[g.Nodes.Count - 1].Blocks2.Count - 1].Blocks1.Count - 1];
            }
            else if (gP.Degree < Helpers.Fi(gP.Nodes[0].Level) && gP.IsSplitGroup == false)
            {
                if (gP.Left == g)
                    g.Incr = gP.Nodes[0].Blocks2[0].Blocks1[0];
                else
                    g.Incr = gP.Nodes[gP.Nodes.Count - 1]
                        .Blocks2[gP.Nodes[gP.Nodes.Count - 1].Blocks2.Count - 1]
                        .Blocks1[gP.Nodes[gP.Nodes.Count - 1].Blocks2[gP.Nodes[gP.Nodes.Count - 1].Blocks2.Count - 1].Blocks1.Count - 1];

            }
        }

        private static void GShare(Group g, Group gP)
        {
            MultiBreak(gP);
            g.Mate = gP;
            gP.Mate = g;
            if (g.Degree < Helpers.Fi(g.Nodes[0].Level) && g.IsSplitGroup == false)
            {
                if (gP.Left == g)
                    g.Incr = gP.Nodes[0].Blocks2[0].Blocks1[0];
                else
                    g.Incr = gP.Nodes[gP.Nodes.Count - 1]
                        .Blocks2[gP.Nodes[gP.Nodes.Count - 1].Blocks2.Count - 1]
                        .Blocks1[gP.Nodes[gP.Nodes.Count - 1].Blocks2[gP.Nodes[gP.Nodes.Count - 1].Blocks2.Count - 1].Blocks1.Count - 1];
            }
            else
            {

                if (g.Left == gP)
                    gP.Incr = g.Nodes[0].Blocks2[0].Blocks1[0];
                else
                    gP.Incr = g.Nodes[g.Nodes.Count - 1]
                        .Blocks2[g.Nodes[g.Nodes.Count - 1].Blocks2.Count - 1]
                        .Blocks1[g.Nodes[g.Nodes.Count - 1].Blocks2[g.Nodes[g.Nodes.Count - 1].Blocks2.Count - 1].Blocks1.Count - 1];
            }
        }

        private static Node Split(Node node)
        {
            Node newNode = new Node()
            {
                IsUnderContruction = true,
                Level = node.Level
            };

            Block2 lastBlock2 = node.Blocks2[node.Blocks2.Count - 1];
            if (lastBlock2.Pending)
            {
                node.Blocks2.Remove(lastBlock2);
                newNode.Blocks2.Insert(0, lastBlock2);
                lastBlock2 = lastBlock2.Left;
            }

            node.Blocks2.Remove(lastBlock2);
            newNode.Blocks2.Insert(0, lastBlock2);
            lastBlock2 = lastBlock2.Left;

            if (lastBlock2.Pending == false && lastBlock2.Mate == lastBlock2.Right)
            {
                node.Blocks2.Remove(lastBlock2);
                newNode.Blocks2.Insert(0, lastBlock2);
                lastBlock2 = lastBlock2.Left;
            }

            if (lastBlock2.Pending && lastBlock2.Mate == lastBlock2.Right)
            {
                node.Blocks2.Remove(lastBlock2);
                newNode.Blocks2.Insert(0, lastBlock2);
            }

            lastBlock2.Left.Right = null;
            lastBlock2.Left = null;

            if (node.FatherNode == null)
            {
                new Node(new Block2(new Block1(node)));
            }

            GAdd(newNode, node.Group);

            return newNode;
        }

        private static void GAdd(Node v, Group g)
        {
            v.Group = g;
            g.Nodes.Add(v);
            v.IsUnderContruction = true;
        }

        private static void TransferBlock1(Block2 from, Block2 to)
        {
            if(from.Right == to)
            {

            }
            else
            {

            }
        }

        #endregion Private Methods.
    }
}
