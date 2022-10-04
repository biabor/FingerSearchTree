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

        internal static Leaf Insert(Leaf left, int value)
        {
            Leaf newLeaf = new Leaf(value);
            InsertLeaf(left, newLeaf);

            Update(left);

            return newLeaf;
        }

        internal static Leaf Delete(Leaf leaf)
        {
            DeleteLeaf(leaf);
            Update(leaf);

            return leaf.Left as Leaf;
        }

        #region Private Methods.

        private static void InsertLeaf(Leaf left, Leaf newLeaf)
        {
            left.Father.Add(left, newLeaf);

            Node fatherNode = left.FatherNode;
            if (fatherNode.Degree >= Helpers.BiP(fatherNode.Level) && ContainsAtLeastTwoBlock2Pairs(fatherNode))
                Split(fatherNode);
            else if (4 * Helpers.Fi(fatherNode.Level) < fatherNode.Degree && fatherNode.Degree < Helpers.BiP(fatherNode.Level) && fatherNode.Blocks2.Count > 1)
            {
                Block2 firstBlock2 = fatherNode.Blocks2[0];
                Block2 secondBlock2 = firstBlock2.Right;
                if (secondBlock2.Degree <= firstBlock2.Degree)
                {
                    Block1 toBeMoved = secondBlock2.Blocks1[0];
                    secondBlock2.Remove(toBeMoved, true);
                    firstBlock2.Add(firstBlock2.Blocks1.Count, toBeMoved);
                }
                else if (secondBlock2.Degree > firstBlock2.Degree)
                {
                    Block1 toBeMoved = firstBlock2.Blocks1[firstBlock2.Blocks1.Count - 1];
                    firstBlock2.Remove(toBeMoved, true);
                    secondBlock2.Add(0, toBeMoved);
                }
            }
        }

        private static void DeleteLeaf(Leaf leaf)
        {
            leaf.Father.Remove(leaf);
        }

        private static void Update(Leaf leaf)
        {
            Node r = Find(leaf.Father);
            Group rGroup = r.Group;

            MultiBreak(rGroup);

            if (4 * Helpers.Fi(r.Level) < rGroup.Degree && rGroup.Degree < Helpers.BiP(r.Level))
                rGroup.IsSplitGroup = true;

            if (rGroup.Degree <= Helpers.Ai(r.Level)) //if it contains one block1
            {
                Group rLeft = rGroup.Left(r);
                Group rRight = rGroup.Right(r);

                if (rLeft != null)
                {
                    if (rLeft.Degree + rGroup.Degree <= 4 * Helpers.Fi(r.Level + 1))
                        rGroup = GFuse(rGroup, rLeft);
                    else
                    {
                        MultiBreak(rLeft);
                        GShare(rGroup, rLeft);
                    }
                }
                else if (rRight != null)
                {
                    if (rRight.Degree + rGroup.Degree <= 4 * Helpers.Fi(r.Level + 1))
                        rGroup = GFuse(rGroup, rRight);
                    else
                    {
                        MultiBreak(rRight);
                        GShare(rGroup, rRight);
                    }
                }
            }

            if (r.FatherNode != null)
            {
                Block1 qZ = r.Father;
                Node uP = qZ.Father.Node;
                Group z = uP.Group;

                Block1 qX = uP.Father;

                if (4 * Helpers.Fi(uP.Level) < z.Degree && z.Degree < Helpers.BiP(uP.Level))
                {
                    // If the size of uP is less than fi, then its unique block2 is moved to an adjacent
                    // node under construction.There is surely at least one such node, since we
                    // assumed that z is in the secure interval.
                    // Then, a fusion or a sharing operation between blocks2 is performed by using the operations Add and Remove. ??????? TODO
                    if (uP.Degree <= Helpers.Fi(uP.Level))
                    {
                        Block2 toBeMoved = uP.Blocks2[0];
                        uP.Remove(toBeMoved);

                        if (uP.Right?.Group == uP.Group)
                        {
                            uP.Right.Add(0, toBeMoved);
                            uP = uP.Right;
                        }
                        else
                        {
                            uP.Left.Add(uP.Left.Blocks2.Count, toBeMoved);
                            uP = uP.Left;
                        }
                    }

                    Block2 pZ = rGroup.Block2;
                    Block2 pZP = pZ.Mate ?? pZ.Right ?? pZ.Left;

                    if (uP.Degree > 8 * Helpers.Fi(uP.Level) && uP.Blocks2.Count > 1)
                    {
                        if (pZ.Degree > pZP.Degree)
                            Transfer(pZP, pZ);
                        else
                            Transfer(pZ, pZP);
                    }
                    else
                    {
                        if (pZ.Degree > Helpers.Fi(uP.Level) && pZP != null && pZP.Degree < Helpers.Fi(uP.Level))
                            Transfer(pZ, pZP);
                        else
                        {
                            Block2 pZPP = new Block2();
                            uP.Add(pZ, pZPP);
                            Transfer(pZ, pZPP);
                        }
                    }
                }
                else if (z.Degree >= Helpers.BiP(uP.Level))
                {
                    if (ContainsAtLeastTwoBlock2Pairs(uP))
                    {
                        Split(uP);
                    }

                    if (qX != null && qX.Degree < Helpers.Ai(uP.Level) && qX.Mate == null && (qX.Left != null || qX.Right != null))
                    {
                        if (qX.Left != null && (qX.OldNode == qX.Left.OldNode || qX.NewNode == qX.Left.OldNode))
                        {
                            // Update qx.oldnoded and qx.newnode as Lines 22-26 of Delete(l) - TODO
                            if (qX.OldNode.Group.Valid == false)
                                qX.OldNode = qX.NewNode;
                            qX.OldNode.Group = qX.Father.Group;
                            qX.NewNode = qX.Father.Node;


                            if (qX.Left.Mate == null)
                            {
                                qX.Left.Mate = qX;
                                qX.Mate = qX.Left;
                            }
                            else if (qX.Right != null && qX.Right.Mate == null)
                            {
                                qX.Right.Mate = qX;
                                qX.Mate = qX.Right;
                            }
                        }
                        else if (qX.Right != null && (qX.OldNode == qX.Right.OldNode || qX.NewNode == qX.Right.OldNode))
                        {
                            // Update qx.oldnode and qx.newnode as Lines 22-26 of Delete(l) - TODO
                            if (qX.OldNode.Group.Valid == false)
                                qX.OldNode = qX.NewNode;
                            qX.OldNode.Group = qX.Father.Group;
                            qX.NewNode = qX.Father.Node;

                            if (qX.Right.Mate == null)
                            {
                                qX.Right.Mate = qX;
                                qX.Mate = qX.Right;
                            }
                            else if (qX.Left != null && qX.Left.Mate == null)
                            {
                                qX.Left.Mate = qX;
                                qX.Mate = qX.Left;
                            }
                        }
                    }
                }
                else
                {
                    z.IsSplitGroup = false;
                    // Lines 5-33 of the Delete(l) algorithm.

                    if (z.Degree < Helpers.Fi(z.Level))
                    {
                        Group y = z.Right(uP);
                        if (y != null && y.Block2 == qX.Father && z.Degree + y.Degree < 4 * Helpers.Fi(uP.Level) && y.Mate == null)
                        {
                            int temp = y.Degree;
                            y = GFuse(z, y);
                            qX.Remove(z.Nodes[0]);

                            if (y.Degree < Helpers.Fi(y.Level) && temp < Helpers.Ai(y.Level))
                            {
                                Group w = y.Left(uP);
                                if (w != null && w.Block2 == qX.Father && y.Degree + w.Degree < 4 * Helpers.Fi(y.Level) && w.Mate == null)
                                {
                                    temp = w.Degree;
                                    w = GFuse(y, w);
                                    qX.Remove(y.Nodes[0]); // Sau up.right? TODO 

                                    if (w.Degree < Helpers.Fi(w.Level) && temp < Helpers.Ai(w.Level))
                                    {
                                        Group t = w.Right(uP);
                                        if (t != null && t.Block2 == qX.Father && w.Degree + t.Degree < 4 * Helpers.Fi(w.Level) && t.Mate == null)
                                        {
                                            temp = t.Degree;
                                            t = GFuse(w, t);
                                            qX.Remove(w.Nodes[0]); // Sau up.right? TODO 

                                            if (t.Degree < Helpers.Fi(t.Level) && temp < Helpers.Ai(t.Level))
                                            {
                                                Group tP = t.Left(uP);
                                                if (tP != null && tP.Block2 == qX.Father && t.Degree + tP.Degree < 4 * Helpers.Fi(t.Level) && tP.Mate == null)
                                                {
                                                    GFuse(t, tP);
                                                    qX.Remove(t.Nodes[0]);
                                                }
                                            }
                                        }
                                        else if (w.Left(uP) != null && w.Left(uP).Block2 == qX.Father && w.Degree + w.Left(uP).Degree < 4 * Helpers.Fi(w.Level) && w.Left(uP).Mate == null)
                                        {
                                            Group tP = w.Left(uP);
                                            GFuse(w, tP);
                                            qX.Remove(w.Nodes[0]);
                                        }
                                    }
                                }
                                else if (y.Right(uP) != null && y.Right(uP).Block2 == qX.Father && y.Degree + y.Right(uP).Degree < 4 * Helpers.Fi(y.Level) && y.Right(uP).Mate == null)
                                {
                                    Group t = y.Right(uP);
                                    GFuse(y, t);
                                    qX.Remove(y.Nodes[0]);
                                }
                            }
                        }
                        else if (z.Left(uP) != null && z.Left(uP).Block2 == qX.Father && z.Degree + z.Left(uP).Degree < 4 * Helpers.Fi(uP.Level) && z.Left(uP).Mate == null)
                        {
                            Group w = z.Left(uP);
                            int temp = w.Degree;
                            w = GFuse(z, w);
                            qX.Remove(z.Nodes[0]);

                            if (w.Degree < Helpers.Fi(w.Level) && temp < Helpers.Ai(w.Level))
                            {
                                Group tP = w.Left(uP);
                                if (tP != null && tP.Block2 == qX.Father && w.Degree + tP.Degree < 4 * Helpers.Fi(w.Level) && tP.Mate == null)
                                {
                                    GFuse(w, tP);
                                    qX.Remove(w.Nodes[0]);
                                }
                            }
                        }
                    }
                    else if (z.Mate != null)
                    {
                        Group g = z.Mate;
                        if (z.Incr != null)
                        {
                            if (z.Incr.OldNode.Group.Valid == false)
                                z.Incr.OldNode = z.Incr.NewNode;
                            z.Incr.OldNode.Group = z;
                            z.Incr.NewNode = z.Incr.Father.Node;
                            if (z.Left(uP) == g)
                            {
                                if (z.Incr.Father.Group == z)
                                {
                                    if (z.Incr.Left != null && z.Incr.Left.Father.Group == z.Incr.Father.Group)
                                        z.Incr = z.Incr.Left;
                                    else
                                    {
                                        z.Incr = null;
                                        z.Mate = null;
                                        g.Mate = null;
                                    }
                                }
                                else
                                {
                                    if (z.Incr.Right != null && z.Incr.Right.Father.Group == z.Incr.Father.Group)
                                        z.Incr = z.Incr.Right;
                                    else
                                    {
                                        z.Incr = null;
                                        z.Mate = null;
                                        g.Mate = null;
                                    }
                                }
                            }
                            else
                            {
                                if (z.Incr.Father.Group == z)
                                {
                                    if (z.Incr.Right != null && z.Incr.Right.Father.Group == z.Incr.Father.Group)
                                        z.Incr = z.Incr.Right;
                                    else
                                    {
                                        z.Incr = null;
                                        z.Mate = null;
                                        g.Mate = null;
                                    }
                                }
                                else
                                {
                                    if (z.Incr.Left != null && z.Incr.Left.Father.Group == z.Incr.Father.Group)
                                        z.Incr = z.Incr.Left;
                                    else
                                    {
                                        z.Incr = null;
                                        z.Mate = null;
                                        g.Mate = null;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (g.Incr.OldNode.Group.Valid == false)
                                g.Incr.OldNode = g.Incr.NewNode;
                            g.Incr.OldNode.Group = g;
                            g.Incr.NewNode = g.Incr.Father.Node;
                            if (g.Left(uP) == z)
                            {
                                if (g.Incr.Father.Group == g)
                                {
                                    if (g.Incr.Left != null && g.Incr.Left.Father.Group == g.Incr.Father.Group)
                                        g.Incr = g.Incr.Left;
                                    else
                                    {
                                        g.Incr = null;
                                        g.Mate = null;
                                        z.Mate = null;
                                    }
                                }
                                else
                                {
                                    if (g.Incr.Right != null && g.Incr.Right.Father.Group == g.Incr.Father.Group)
                                        g.Incr = g.Incr.Right;
                                    else
                                    {
                                        g.Incr = null;
                                        g.Mate = null;
                                        z.Mate = null;
                                    }
                                }
                            }
                            else
                            {
                                if (g.Incr.Father.Group == g)
                                {
                                    if (g.Incr.Right != null && g.Incr.Right.Father.Group == g.Incr.Father.Group)
                                        g.Incr = g.Incr.Right;
                                    else
                                    {
                                        g.Incr = null;
                                        g.Mate = null;
                                        z.Mate = null;
                                    }
                                }
                                else
                                {
                                    if (g.Incr.Left != null && g.Incr.Left.Father.Group == g.Incr.Father.Group)
                                        g.Incr = g.Incr.Left;
                                    else
                                    {
                                        g.Incr = null;
                                        g.Mate = null;
                                        z.Mate = null;
                                    }
                                }
                            }
                        }
                    }

                    if (qX != null && qX.Degree < Helpers.Ai(qX.Father.Node.Level /* sau -1 TODO */ ) && qX.Mate == null && (qX.Left != null || qX.Right != null))
                    {
                        if (qX.Left != null && (qX.OldNode == qX.Left.OldNode || qX.NewNode == qX.Left.OldNode))
                        {
                            // Update qx.oldnoded and qx.newnode as Lines 22-26 of Delete(l) - TODO
                            if (qX.OldNode.Group.Valid == false)
                                qX.OldNode = qX.NewNode;
                            qX.OldNode.Group = qX.Father.Group;
                            qX.NewNode = qX.Father.Node;

                            if (qX.Left.Mate == null)
                            {
                                qX.Left.Mate = qX;
                                qX.Mate = qX.Left;
                            }
                            else if (qX.Right != null && qX.Right.Mate == null)
                            {
                                qX.Right.Mate = qX;
                                qX.Mate = qX.Right;
                            }
                        }
                        else if (qX.Right != null && (qX.OldNode == qX.Right.OldNode || qX.NewNode == qX.Right.OldNode))
                        {
                            // Update qx.oldnode and qx.newnode as Lines 22-26 of Delete(l) - TODO
                            if (qX.OldNode.Group.Valid == false)
                                qX.OldNode = qX.NewNode;
                            qX.OldNode.Group = qX.Father.Group;
                            qX.NewNode = qX.Father.Node;

                            if (qX.Right.Mate == null)
                            {
                                qX.Right.Mate = qX;
                                qX.Mate = qX.Right;
                            }
                            else if (qX.Left != null && qX.Left.Mate == null)
                            {
                                qX.Left.Mate = qX;
                                qX.Mate = qX.Left;
                            }
                        }
                    }
                }
            }
        }

        public static bool ContainsAtLeastTwoBlock2Pairs(Node u)
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
                    if (f.Group.Component.Valid == false)
                    {
                        f.Group.Component = new Component(f);
                    }
                }
                else
                {
                    if (f.Group.Component.Valid == false || f.FatherNode == null)
                    {
                        if (f.Group.Nodes.Count == 1)
                        {
                            f.Group.Valid = true;
                        }
                        else
                        {
                            f.Group.Nodes.Remove(f);
                            f.Group = new Group(f)
                            {
                                IsSplitGroup = true
                            };
                        }
                        f.Group.Component = new Component(f);
                    }
                    else if (f.Group.Component == f.FatherNode.Component)
                    {
                        if (f.Group.Nodes.Count == 1)
                        {
                            f.Group.Valid = true;
                        }
                        else
                        {
                            f.Group.Nodes.Remove(f);
                            f.Group = new Group(f)
                            {
                                IsSplitGroup = true
                            };
                        }
                        f.Group.Component = f.FatherNode.Component;
                    }
                }
            }
            else
            {
                f = father.OldNode.Group.Valid ? father.OldNode : father.NewNode ?? father.Father.Node;

                if (f.Group.Valid == false)
                {
                    if (f.Group.Nodes.Count == 1)
                    {
                        f.Group.Valid = true;
                    }
                    else
                    {
                        f.Group.Nodes.Remove(f);
                        f.Group = new Group(f);
                    }
                }

                if (f.Component.Valid == false)
                    f.Component = new Component(f);
            }

            return f.Component.Root;
        }

        private static void MultiBreak(Group g)
        {
            if (g.IsSplitGroup)
            {
                g.Component.Valid = false;
                if (g.Nodes.Count > 1)
                {
                    g.Valid = false;
                }
                if (g.Block2 != null)
                {
                    g.Component = g.Block2.Node.Component;
                }
                else g.Component = new Component(g.Nodes[0]);
            }
            else
            {
                g.Valid = false;
                g.Nodes[0].Component.Valid = false;
                if (g.Block2 != null)
                {
                    g.Nodes[0].Component = g.Block2.Node.Component;
                }
                else
                    g.Nodes[0].Component = new Component(g.Nodes[0]);

            }
        }

        private static Group GFuse(Group g, Group gP)
        {
            if (g.Mate != null || gP.Mate != null)
                return null;

            if (g.Nodes.Count == 1 && gP.Degree <= Helpers.Ai(gP.Level))
            {
                //Move the only block1 from gp to g.
                if (g.Left(g.Nodes[0]) == gP)
                {
                    Block2 toBeMovedIn = g.Nodes[0].Blocks2[0];
                    Block2 toBeMovedFrom = gP.Nodes[gP.Nodes.Count - 1].Blocks2[gP.Nodes[gP.Nodes.Count - 1].Blocks2.Count - 1];
                    Block1 toBeMoved = toBeMovedFrom.Blocks1[toBeMovedFrom.Blocks1.Count - 1];

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedIn.Add(0, toBeMoved);

                    toBeMoved.OldNode = toBeMovedFrom.Node;
                    toBeMoved.NewNode = toBeMovedIn.Node;
                }
                else
                {
                    Block2 toBeMovedIn = g.Nodes[g.Nodes.Count - 1].Blocks2[g.Nodes[g.Nodes.Count - 1].Blocks2.Count - 1];
                    Block2 toBeMovedFrom = gP.Nodes[0].Blocks2[0];
                    Block1 toBeMoved = toBeMovedFrom.Blocks1[0];

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedIn.Add(toBeMovedIn.Blocks1.Count, toBeMoved);

                    toBeMoved.OldNode = toBeMovedFrom.Node;
                    toBeMoved.NewNode = toBeMovedIn.Node;
                }
                return g;
            }
            else if (gP.Nodes.Count == 1 && g.Degree <= Helpers.Ai(g.Level))
            {
                //Move the only block1 from g to gp.
                if (gP.Left(gP.Nodes[0]) == g)
                {
                    Block2 toBeMovedIn = gP.Nodes[0].Blocks2[0];
                    Block2 toBeMovedFrom = g.Nodes[g.Nodes.Count - 1].Blocks2[g.Nodes[g.Nodes.Count - 1].Blocks2.Count - 1];
                    Block1 toBeMoved = toBeMovedFrom.Blocks1[toBeMovedFrom.Blocks1.Count - 1];

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedIn.Add(0, toBeMoved);

                    toBeMoved.OldNode = toBeMovedFrom.Node;
                    toBeMoved.NewNode = toBeMovedIn.Node;
                }
                else
                {
                    Block2 toBeMovedIn = gP.Nodes[gP.Nodes.Count - 1].Blocks2[gP.Nodes[gP.Nodes.Count - 1].Blocks2.Count - 1];
                    Block2 toBeMovedFrom = g.Nodes[0].Blocks2[0];
                    Block1 toBeMoved = toBeMovedFrom.Blocks1[0];

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedIn.Add(toBeMovedIn.Blocks1.Count, toBeMoved);

                    toBeMoved.OldNode = toBeMovedFrom.Node;
                    toBeMoved.NewNode = toBeMovedIn.Node;
                }
                return gP;
            }

            g.Mate = gP;
            gP.Mate = g;

            if (g.Degree <= Helpers.Fi(g.Level))
            {
                if (g.Left(g.Nodes[0]) == gP)
                {
                    Node toBeMovedFrom = g.Nodes[0];
                    Node toBeMovedTo = gP.Nodes[gP.Nodes.Count - 1];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[0];

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedTo.Add(toBeMovedTo.Blocks2.Count, toBeMoved);

                    // set gP.incr to the leftmost block1 of G if G is to the right of gP
                    gP.Incr = toBeMoved.Blocks1[0];
                }
                else
                {
                    Node toBeMovedFrom = g.Nodes[g.Nodes.Count - 1];
                    Node toBeMovedTo = gP.Nodes[0];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[toBeMovedFrom.Blocks2.Count - 1];

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedTo.Add(0, toBeMoved);

                    // set gP.incr to the rightmost block1 of G if G is to the left of gP
                    gP.Incr = toBeMoved.Blocks1[toBeMoved.Blocks1.Count - 1];
                }

                return gP;
            }
            else if (gP.Degree <= Helpers.Fi(g.Level))
            {
                if (gP.Left(gP.Nodes[0]) == g)
                {
                    Node toBeMovedFrom = gP.Nodes[0];
                    Node toBeMovedTo = g.Nodes[g.Nodes.Count - 1];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[0];

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedTo.Add(toBeMovedTo.Blocks2.Count, toBeMoved);

                    // set g.incr to the leftmost block1 of gP if gP is to the right of g
                    g.Incr = toBeMoved.Blocks1[0];
                }
                else
                {
                    Node toBeMovedFrom = gP.Nodes[gP.Nodes.Count - 1];
                    Node toBeMovedTo = g.Nodes[0];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[toBeMovedFrom.Blocks2.Count - 1];

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedTo.Add(0, toBeMoved);

                    // set g.incr to the rightmost block1 of gP if gP is to the left of g
                    g.Incr = toBeMoved.Blocks1[toBeMoved.Blocks1.Count - 1];
                }

                return g;
            }

            return null;
        }

        private static void GShare(Group g, Group gP)
        {
            if (g.Mate != null || gP.Mate != null)
                return;

            g.Mate = gP;
            gP.Mate = g;

            if (g.Degree <= Helpers.Ai(g.Level))
            {
                //Move a block2 from gp to g.
                //Add the block1 from g to that block2.
                //Set the incr pointer of that block2.
                if (g.Left(g.Nodes[0]) == gP)
                {
                    Node toBeMovedFrom = gP.Nodes[gP.Nodes.Count - 1];
                    Node toBeMovedTo = g.Nodes[0];
                    Block2 toBeRemoved = toBeMovedTo.Blocks2[0];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[toBeMovedFrom.Blocks2.Count - 1];
                    Block1 onlyBlockTo = toBeRemoved.Blocks1[0];

                    toBeMovedTo.Remove(toBeRemoved);

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedTo.Add(toBeMovedTo.Blocks2.Count, toBeMoved);

                    toBeRemoved.Remove(onlyBlockTo);
                    toBeMoved.Add(0, onlyBlockTo);

                    g.Incr = onlyBlockTo.Left;
                }
                else
                {
                    Node toBeMovedFrom = gP.Nodes[0];
                    Node toBeMovedTo = g.Nodes[g.Nodes.Count - 1];
                    Block2 toBeRemoved = toBeMovedTo.Blocks2[toBeMovedTo.Blocks2.Count - 1];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[0];
                    Block1 onlyBlockTo = toBeRemoved.Blocks1[toBeRemoved.Blocks1.Count - 1];

                    toBeMovedTo.Remove(toBeRemoved);

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedTo.Add(toBeMovedTo.Blocks2.Count, toBeMoved);

                    toBeRemoved.Remove(onlyBlockTo);
                    toBeMoved.Add(0, onlyBlockTo);

                    g.Incr = onlyBlockTo.Right;
                }
            }
            else
            {
                //Move a block2 from g to gp.
                //Add the block1 from gp to that block2.
                //Set the incr pointer of that block2.
                if (gP.Left(gP.Nodes[0]) == g)
                {
                    Node toBeMovedFrom = gP.Nodes[g.Nodes.Count - 1];
                    Node toBeMovedTo = g.Nodes[0];
                    Block2 toBeRemoved = toBeMovedTo.Blocks2[0];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[toBeMovedFrom.Blocks2.Count - 1];
                    Block1 onlyBlockTo = toBeRemoved.Blocks1[0];

                    toBeMovedTo.Remove(toBeRemoved);

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedTo.Add(toBeMovedTo.Blocks2.Count, toBeMoved);

                    toBeRemoved.Remove(onlyBlockTo);
                    toBeMoved.Add(0, onlyBlockTo);

                    gP.Incr = onlyBlockTo.Left;
                }
                else
                {
                    Node toBeMovedFrom = g.Nodes[0];
                    Node toBeMovedTo = gP.Nodes[gP.Nodes.Count - 1];
                    Block2 toBeRemoved = toBeMovedTo.Blocks2[toBeMovedTo.Blocks2.Count - 1];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[0];
                    Block1 onlyBlockTo = toBeRemoved.Blocks1[toBeRemoved.Blocks1.Count - 1];

                    toBeMovedTo.Remove(toBeRemoved);

                    toBeMovedFrom.Remove(toBeMoved);
                    toBeMovedTo.Add(0, toBeMoved);

                    toBeRemoved.Remove(onlyBlockTo);
                    toBeMoved.Add(0, onlyBlockTo);

                    gP.Incr = onlyBlockTo.Right;
                }
            }
        }

        private static void Split(Node node)
        {
            Node newNode = new Node()
            {
                IsUnderContruction = true,
                Level = node.Level
            };

            bool pending = false;
            Block2 lastBlock2 = node.Blocks2[node.Blocks2.Count - 1];
            if (lastBlock2.Pending)
            {
                node.Remove(lastBlock2);
                newNode.Add(0, lastBlock2);
                lastBlock2 = node.Blocks2[node.Blocks2.Count - 1];
                pending = true;
            }

            node.Remove(lastBlock2);
            newNode.Add(0, lastBlock2);
            lastBlock2 = node.Blocks2[node.Blocks2.Count - 1];
            if (pending)
            {
                newNode.Blocks2[1].Mate = newNode.Blocks2[0];
                newNode.Blocks2[1].Pending = true;
            }

            if (lastBlock2.Pending == false && lastBlock2.Mate == lastBlock2.Right && lastBlock2.Mate != null)
            {
                node.Remove(lastBlock2);
                newNode.Add(0, lastBlock2);
                lastBlock2 = node.Blocks2[node.Blocks2.Count - 1];
                newNode.Blocks2[0].Mate = newNode.Blocks2[1];
                newNode.Blocks2[1].Mate = newNode.Blocks2[0];
            }

            if (lastBlock2.Pending && lastBlock2.Mate == lastBlock2.Right && lastBlock2.Mate != null)
            {
                node.Remove(lastBlock2);
                newNode.Add(0, lastBlock2);
                newNode.Blocks2[0].Mate = newNode.Blocks2[1];
                newNode.Blocks2[0].Pending = true;
            }

            if (node.FatherNode == null)
            {
                new Node(new Block2(new Block1(node)));
                node.Father.OldNode = node.FatherNode;
                node.Father.Father.Group = node.FatherNode.Group;
            }

            node.Father.Add(node, newNode);

            GAdd(newNode, node.Group);
        }

        private static void GAdd(Node v, Group g)
        {
            v.Group = g;
            v.Component = g.Component;
            int position = g.Nodes.FindIndex(x => x == v.Left);
            g.Nodes.Insert(position + 1, v);
        }

        private static void Transfer(Block2 from, Block2 to)
        {
            if (from.Blocks1.Count == 0)
            {
                from.Node.Remove(from);
                return;
            }

            if (from.Right == to)
            {
                Block1 what = from.Blocks1[from.Blocks1.Count - 1];
                from.Remove(what, true);
                to.Add(0, what);
            }
            else
            {
                Block1 what = from.Blocks1[0];
                from.Remove(what, true);
                to.Add(to.Blocks1.Count, what);
            }
        }

        #endregion Private Methods.
    }
}
