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
            AddNode(left, newLeaf);

            Node fatherNode = left.FatherNode;
            if (fatherNode.Degree >= Helpers.BiP(fatherNode.Level) && ContainsAtLeastTwoBlock2Pairs(fatherNode))
            {
                Split(fatherNode);
            }
            else if (4 * Helpers.Fi(fatherNode.Level) < fatherNode.Degree && fatherNode.Degree < Helpers.BiP(fatherNode.Level) && fatherNode.Blocks2.Count > 1)
            {
                fatherNode.Group.IsSplitGroup = true;
                Block2 firstBlock2 = fatherNode.Blocks2[0];
                Block2 secondBlock2 = firstBlock2.Right;
                if (secondBlock2.Degree <= firstBlock2.Degree)
                {
                    Block1 toBeMoved = secondBlock2.Blocks1[0];
                    secondBlock2.Remove(toBeMoved);
                    firstBlock2.Add(firstBlock2.Blocks1.Count, toBeMoved);

                    if (toBeMoved.Mate != null)
                    {
                        toBeMoved = secondBlock2.Blocks1[0];
                        secondBlock2.Remove(toBeMoved);
                        firstBlock2.Add(firstBlock2.Blocks1.Count, toBeMoved);
                    }
                }
                else if (secondBlock2.Degree > firstBlock2.Degree)
                {
                    Block1 toBeMoved = firstBlock2.Blocks1[firstBlock2.Blocks1.Count - 1];
                    firstBlock2.Remove(toBeMoved);
                    secondBlock2.Add(0, toBeMoved);

                    if (toBeMoved.Mate != null)
                    {
                        toBeMoved = firstBlock2.Blocks1[firstBlock2.Blocks1.Count - 1];
                        firstBlock2.Remove(toBeMoved);
                        secondBlock2.Add(0, toBeMoved);
                    }
                }
            }
        }

        private static void DeleteLeaf(Leaf leaf)
        {
            DeleteNode(leaf);

            Node fatherNode = leaf.FatherNode;
            Group fatherGroup = fatherNode.Group;
            Group left = fatherGroup.Left(fatherNode);
            Group right = fatherGroup.Right(fatherNode);


            if (fatherGroup.Degree <= Helpers.Fi(fatherGroup.Level))
            {
                fatherGroup.IsSplitGroup = false;
                if (left != null && left.Degree <= 4 * Helpers.Ai(left.Level) && left.Block2.Node == fatherGroup.Block2.Node && left.IsSplitGroup == false)
                {
                    if (left.Degree + fatherGroup.Degree <= 4 * Helpers.Fi(fatherGroup.Level))
                        fatherGroup = GFuse(fatherGroup, left);
                    else
                    {
                        MultiBreak(left);
                        GShare(fatherGroup, left);
                    }
                }
                if (fatherGroup.Degree <= Helpers.Fi(fatherGroup.Level) && right != null && right.Degree <= 4 * Helpers.Ai(right.Level) && right.Block2.Node == fatherGroup.Block2.Node && right.IsSplitGroup == false)
                {
                    if (right.Degree + fatherGroup.Degree <= 4 * Helpers.Fi(fatherGroup.Level))
                        GFuse(fatherGroup, right);
                    else
                    {
                        MultiBreak(right);
                        GShare(fatherGroup, right);
                    }
                }
            }
        }

        private static void Update(Leaf leaf)
        {
            Node r = Find(leaf.Father);
            Group rGroup = r.Group;

            MultiBreak(rGroup);

            rGroup.IsSplitGroup = 4 * Helpers.Fi(r.Level) < rGroup.Degree;

            if (rGroup.Degree <= Helpers.Ai(r.Level)) //if it contains one block1
            {
                Group rLeft = rGroup.Left(r);
                Group rRight = rGroup.Right(r);

                if (rLeft != null && rLeft.Degree < 4 * Helpers.Fi(r.Level) && rLeft.Block2.Node == rGroup.Block2.Node && rLeft.IsSplitGroup == false)
                {
                    if (rLeft.Degree + rGroup.Degree <= 4 * Helpers.Fi(r.Level))
                        rGroup = GFuse(rGroup, rLeft);
                    else
                    {
                        MultiBreak(rLeft);
                        GShare(rGroup, rLeft);
                    }
                }
                if (rGroup.Degree <= Helpers.Ai(r.Level) && rRight != null && rRight.Degree < 4 * Helpers.Fi(r.Level) && rRight.Block2.Node == rGroup.Block2.Node && rRight.IsSplitGroup == false)
                {
                    if (rRight.Degree + rGroup.Degree <= 4 * Helpers.Fi(r.Level))
                        rGroup = GFuse(rGroup, rRight);
                    else
                    {
                        MultiBreak(rRight);
                        GShare(rGroup, rRight);
                    }
                }
            }

            if (rGroup.Block2 != null)
            {
                Block1 qZ = r.Father;
                Node uP = qZ.Father.Node;
                Group z = uP.Group;

                if (4 * Helpers.Fi(uP.Level) < z.Degree && z.Degree < Helpers.BiP(uP.Level))
                {
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

                    Block1 qX = uP.Father;
                    if (qX != null)
                    {
                        if (qX.Mate == null && qX.Right != null && qX.Right.Mate == null)
                        {
                            qX.Mate = qX.Right;
                            qX.Right.Mate = qX;
                        }
                        if (qX.Mate == null && qX.Left != null && qX.Left.Mate == null)
                        {
                            qX.Mate = qX.Left;
                            qX.Left.Mate = qX;
                        }
                    }
                }
                else
                {
                    z.IsSplitGroup = false;

                    Block1 qX = uP.Father;
                    if (z.Degree < Helpers.Fi(z.Level))
                    {
                        Group y = z.Right(uP);
                        if (y != null && y.Block2 == qX.Father && z.Degree + y.Degree < 4 * Helpers.Fi(uP.Level) && y.Block2.Node == z.Block2.Node && y.IsSplitGroup == false)
                        {
                            int temp = y.Degree;
                            y = GFuse(z, y);
                            qX.Remove(z.Nodes[0]);

                            if (y.Degree < Helpers.Fi(y.Level) && temp < Helpers.Ai(y.Level))
                            {
                                Group w = y.Left(uP);
                                if (w != null && w.Block2 == qX.Father && y.Degree + w.Degree < 4 * Helpers.Fi(y.Level) && w.Block2.Node == y.Block2.Node && w.IsSplitGroup == false)
                                {
                                    temp = w.Degree;
                                    w = GFuse(y, w);
                                    qX.Remove(y.Nodes[0]); 

                                    if (w.Degree < Helpers.Fi(w.Level) && temp < Helpers.Ai(w.Level))
                                    {
                                        Group t = w.Right(uP);
                                        if (t != null && t.Block2 == qX.Father && w.Degree + t.Degree < 4 * Helpers.Fi(w.Level) && t.Block2.Node == w.Block2.Node && t.IsSplitGroup == false)
                                        {
                                            temp = t.Degree;
                                            t = GFuse(w, t);
                                            qX.Remove(w.Nodes[0]);

                                            if (t.Degree < Helpers.Fi(t.Level) && temp < Helpers.Ai(t.Level))
                                            {
                                                Group tP = t.Left(uP);
                                                if (tP != null && tP.Block2 == qX.Father && t.Degree + tP.Degree < 4 * Helpers.Fi(t.Level) && tP.Block2.Node == t.Block2.Node && tP.IsSplitGroup == false)
                                                {
                                                    GFuse(t, tP);
                                                    qX.Remove(t.Nodes[0]);
                                                }
                                            }
                                        }
                                        else if (w.Left(uP) != null && w.Left(uP).Block2 == qX.Father && w.Degree + w.Left(uP).Degree < 4 * Helpers.Fi(w.Level) && w.Left(uP).Block2.Node == w.Block2.Node && w.Left(uP).IsSplitGroup == false)
                                        {
                                            Group tP = w.Left(uP);
                                            GFuse(w, tP);
                                            qX.Remove(w.Nodes[0]);
                                        }
                                    }
                                }
                                else if (y.Right(uP) != null && y.Right(uP).Block2 == qX.Father && y.Degree + y.Right(uP).Degree < 4 * Helpers.Fi(y.Level) && y.Right(uP).Block2.Node == y.Block2.Node && y.Right(uP).IsSplitGroup == false)
                                {
                                    Group t = y.Right(uP);
                                    GFuse(y, t);
                                    qX.Remove(y.Nodes[0]);
                                }
                            }
                        }
                        else if (z.Left(uP) != null && z.Left(uP).Block2 == qX.Father && z.Degree + z.Left(uP).Degree < 4 * Helpers.Fi(uP.Level) && z.Left(uP).Block2.Node == z.Block2.Node && z.Left(uP).IsSplitGroup == false)
                        {
                            Group w = z.Left(uP);
                            int temp = w.Degree;
                            w = GFuse(z, w);
                            qX.Remove(z.Nodes[0]);

                            if (w.Degree < Helpers.Fi(w.Level) && temp < Helpers.Ai(w.Level))
                            {
                                Group tP = w.Left(uP);
                                if (tP != null && tP.Block2 == qX.Father && w.Degree + tP.Degree < 4 * Helpers.Fi(w.Level) && tP.Block2.Node == w.Block2.Node && tP.IsSplitGroup == false)
                                {
                                    GFuse(w, tP);
                                    qX.Remove(w.Nodes[0]);
                                }
                            }
                        }
                    }

                    qX = uP.Father;
                    if (qX != null)
                    {
                        if (qX.Mate == null && qX.Right != null && qX.Right.Mate == null)
                        {
                            qX.Mate = qX.Right;
                            qX.Right.Mate = qX;
                        }
                        if (qX.Mate == null && qX.Left != null && qX.Left.Mate == null)
                        {
                            qX.Mate = qX.Left;
                            qX.Left.Mate = qX;
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
            if (g.Nodes.Count == 1 && gP.Degree <= Helpers.Ai(gP.Level))
            {
                //Move the only block1 from gp to g.
                if (g.Left(g.Nodes[0]) == gP)
                {
                    Block2 toBeMovedIn = g.Nodes[0].Blocks2[0];
                    Block2 toBeMovedFrom = gP.Nodes[gP.Nodes.Count - 1].Blocks2[gP.Nodes[gP.Nodes.Count - 1].Blocks2.Count - 1];
                    Block1 toBeMoved = toBeMovedFrom.Blocks1[toBeMovedFrom.Blocks1.Count - 1];

                    if (toBeMovedFrom.Node.Component.Valid && toBeMovedFrom.Node.Component.Root == toBeMovedFrom.Node)
                        toBeMovedFrom.Node.Component.Valid = false;

                    toBeMovedFrom.Node.Group.Nodes.Remove(toBeMovedFrom.Node);

                    if (toBeMovedIn.Node.Component.Valid && toBeMovedIn.Node.Component.Root == toBeMovedIn.Node)
                        toBeMovedIn.Node.Component.Valid = false;

                    toBeMovedFrom.Remove(toBeMoved);

                    Node fatherNode = toBeMovedFrom.Node;
                    if (fatherNode.FatherNode != null && fatherNode.FatherNode.Degree == 1)
                    {
                        toBeMovedIn.Node.Left = null;
                        toBeMovedIn.Node.Right = null;
                        toBeMovedIn.Node.Father = null;
                    }

                    toBeMovedIn.Add(0, toBeMoved);

                    if (toBeMovedIn.IsFull)
                    { }
                }
                else
                {
                    Block2 toBeMovedIn = g.Nodes[g.Nodes.Count - 1].Blocks2[g.Nodes[g.Nodes.Count - 1].Blocks2.Count - 1];
                    Block2 toBeMovedFrom = gP.Nodes[0].Blocks2[0];
                    Block1 toBeMoved = toBeMovedFrom.Blocks1[0];

                    if (toBeMovedFrom.Node.Component.Valid && toBeMovedFrom.Node.Component.Root == toBeMovedFrom.Node)
                        toBeMovedFrom.Node.Component.Valid = false;

                    toBeMovedFrom.Node.Group.Nodes.Remove(toBeMovedFrom.Node);

                    if (toBeMovedIn.Node.Component.Valid && toBeMovedIn.Node.Component.Root == toBeMovedIn.Node)
                        toBeMovedIn.Node.Component.Valid = false;

                    toBeMovedFrom.Remove(toBeMoved);

                    Node fatherNode = toBeMovedFrom.Node;
                    if (fatherNode.FatherNode != null && fatherNode.FatherNode.Degree == 1)
                    {
                        toBeMovedIn.Node.Left = null;
                        toBeMovedIn.Node.Right = null;
                        toBeMovedIn.Node.Father = null;
                    }

                    toBeMovedIn.Add(toBeMovedIn.Blocks1.Count, toBeMoved);

                    if (toBeMovedIn.IsFull)
                    { }
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

                    if (toBeMovedFrom.Node.Component.Valid && toBeMovedFrom.Node.Component.Root == toBeMovedFrom.Node)
                        toBeMovedFrom.Node.Component.Valid = false;

                    toBeMovedFrom.Node.Group.Nodes.Remove(toBeMovedFrom.Node);

                    if (toBeMovedIn.Node.Component.Valid && toBeMovedIn.Node.Component.Root == toBeMovedIn.Node)
                        toBeMovedIn.Node.Component.Valid = false;

                    toBeMovedFrom.Remove(toBeMoved);

                    Node fatherNode = toBeMovedFrom.Node;
                    if (fatherNode.FatherNode != null && fatherNode.FatherNode.Degree == 1)
                    {
                        toBeMovedIn.Node.Left = null;
                        toBeMovedIn.Node.Right = null;
                        toBeMovedIn.Node.Father = null;
                    }

                    toBeMovedIn.Add(0, toBeMoved);

                    if (toBeMovedIn.IsFull)
                    { }
                }
                else
                {
                    Block2 toBeMovedIn = gP.Nodes[gP.Nodes.Count - 1].Blocks2[gP.Nodes[gP.Nodes.Count - 1].Blocks2.Count - 1];
                    Block2 toBeMovedFrom = g.Nodes[0].Blocks2[0];
                    Block1 toBeMoved = toBeMovedFrom.Blocks1[0];

                    if (toBeMovedFrom.Node.Component.Valid && toBeMovedFrom.Node.Component.Root == toBeMovedFrom.Node)
                        toBeMovedFrom.Node.Component.Valid = false;

                    toBeMovedFrom.Node.Group.Nodes.Remove(toBeMovedFrom.Node);

                    if (toBeMovedIn.Node.Component.Valid && toBeMovedIn.Node.Component.Root == toBeMovedIn.Node)
                        toBeMovedIn.Node.Component.Valid = false;

                    toBeMovedFrom.Remove(toBeMoved);

                    Node fatherNode = toBeMovedFrom.Node;
                    if (fatherNode.FatherNode != null && fatherNode.FatherNode.Degree == 1)
                    {
                        toBeMovedIn.Node.Left = null;
                        toBeMovedIn.Node.Right = null;
                        toBeMovedIn.Node.Father = null;
                    }

                    toBeMovedIn.Add(toBeMovedIn.Blocks1.Count, toBeMoved);

                    if (toBeMovedIn.IsFull)
                    { }
                }
                return gP;
            }

            if (g.Degree <= Helpers.Fi(g.Level))
            {
                if (g.Left(g.Nodes[0]) == gP)
                {
                    Node toBeMovedFrom = g.Nodes[0];
                    Node toBeMovedTo = gP.Nodes[gP.Nodes.Count - 1];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[0];

                    if (toBeMovedFrom.Component.Valid && toBeMovedFrom.Component.Root == toBeMovedFrom)
                        toBeMovedFrom.Component.Valid = false;

                    if (toBeMovedTo.Component.Valid && toBeMovedTo.Component.Root == toBeMovedTo)
                        toBeMovedTo.Component.Valid = false;

                    toBeMovedFrom.Remove(toBeMoved);
                    if (toBeMovedFrom.FatherNode != null && toBeMovedFrom.FatherNode.Degree == 1)
                    {
                        toBeMovedTo.Left = null;
                        toBeMovedTo.Right = null;
                        toBeMovedTo.Father = null;
                    }
                    toBeMovedTo.Add(toBeMovedTo.Blocks2.Count, toBeMoved);
                }
                else
                {
                    Node toBeMovedFrom = g.Nodes[g.Nodes.Count - 1];
                    Node toBeMovedTo = gP.Nodes[0];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[toBeMovedFrom.Blocks2.Count - 1];

                    if (toBeMovedFrom.Component.Valid && toBeMovedFrom.Component.Root == toBeMovedFrom)
                        toBeMovedFrom.Component.Valid = false;

                    if (toBeMovedTo.Component.Valid && toBeMovedTo.Component.Root == toBeMovedTo)
                        toBeMovedTo.Component.Valid = false;

                    toBeMovedFrom.Remove(toBeMoved);
                    if (toBeMovedFrom.FatherNode != null && toBeMovedFrom.FatherNode.Degree == 1)
                    {
                        toBeMovedTo.Left = null;
                        toBeMovedTo.Right = null;
                        toBeMovedTo.Father = null;
                    }

                    toBeMovedTo.Add(0, toBeMoved);
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

                    if (toBeMovedFrom.Component.Valid && toBeMovedFrom.Component.Root == toBeMovedFrom)
                        toBeMovedFrom.Component.Valid = false;

                    if (toBeMovedTo.Component.Valid && toBeMovedTo.Component.Root == toBeMovedTo)
                        toBeMovedTo.Component.Valid = false;

                    toBeMovedFrom.Remove(toBeMoved);
                    if (toBeMovedFrom.FatherNode != null && toBeMovedFrom.FatherNode.Degree == 1)
                    {
                        toBeMovedTo.Left = null;
                        toBeMovedTo.Right = null;
                        toBeMovedTo.Father = null;
                    }

                    toBeMovedTo.Add(toBeMovedTo.Blocks2.Count, toBeMoved);
                }
                else
                {
                    Node toBeMovedFrom = gP.Nodes[gP.Nodes.Count - 1];
                    Node toBeMovedTo = g.Nodes[0];
                    Block2 toBeMoved = toBeMovedFrom.Blocks2[toBeMovedFrom.Blocks2.Count - 1];

                    if (toBeMovedFrom.Component.Valid && toBeMovedFrom.Component.Root == toBeMovedFrom)
                        toBeMovedFrom.Component.Valid = false;

                    if (toBeMovedTo.Component.Valid && toBeMovedTo.Component.Root == toBeMovedTo)
                        toBeMovedTo.Component.Valid = false;

                    toBeMovedFrom.Remove(toBeMoved);
                    if (toBeMovedFrom.FatherNode != null && toBeMovedFrom.FatherNode.Degree == 1)
                    {
                        toBeMovedTo.Left = null;
                        toBeMovedTo.Right = null;
                        toBeMovedTo.Father = null;
                    }

                    toBeMovedTo.Add(0, toBeMoved);
                }

                return g;
            }

            return null;
        }

        private static void GShare(Group g, Group gP)
        {
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

                    if (toBeMoved.IsFull)
                    { }
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
                    if (toBeMoved.IsFull)
                    { }
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

                    if (toBeMoved.IsFull)
                    { }
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
                    if (toBeMoved.IsFull)
                    { }
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
                node.Father.Father.Group = node.FatherNode.Group;
            }

            GAdd(newNode, node);

            AddNode(node, newNode);
        }

        private static void AddNode(Node left, Node newNode)
        {
            bool wasFullBlock1 = left.Father.IsFull;
            bool wasFullBlock2 = left.Father.Father.IsFull;

            Block1 father = left.Father;
            Block2 grandfather = left.Father.Father;

            father.Add(left, newNode);

            // If this block1 was already full before the insert, then transfer to one node to the mate.
            if (wasFullBlock1)
            {
                if (father.Mate == null)
                {
                    father.Mate = new Block1()
                    {
                        Mate = father
                    };
                    grandfather.Add(father, father.Mate);
                }
                father.TransferToMate();
            }

            // if both become full, break the pair.
            if (father.IsFull && father.Mate != null && father.Mate.IsFull)
            {
                father.Mate.Mate = null;
                father.Mate = null;
            }

            // if it is a pending object there is no transfer needed. But if it became full then break it from the pair.
            if (grandfather.Pending && grandfather.IsFull)
            {
                grandfather.Pending = false;
                grandfather.Mate = null;
            }

            // if the block2 was already full before the insert, the treansfer one block1 to the mate. 
            if (wasFullBlock2)
            {
                // if there is no mate, then find one. 
                if (grandfather.Mate == null)
                {
                    // if we can pair it with a pending block, we make the pair.
                    if (grandfather.Right != null && grandfather.Right.Pending && grandfather.Right.Mate == grandfather)
                    {
                        grandfather.Right.Pending = false;
                        grandfather.Mate = grandfather.Right;
                    }
                    else if (grandfather.Left != null && grandfather.Left.Pending && grandfather.Left.Mate == grandfather)
                    {
                        grandfather.Left.Pending = false;
                        grandfather.Mate = grandfather.Left;
                    }
                    else
                    {
                        grandfather.Mate = new Block2()
                        {
                            Mate = grandfather
                        };

                        grandfather.Node.Add(grandfather, grandfather.Mate);
                    }
                }
                grandfather.TransferToMate();
            }

            // if both blocks2 of them are full, and the break would not spoil invariant 5, then break the pair;
            if (grandfather.IsFull && grandfather.Mate != null && grandfather.Mate.IsFull && grandfather.IsBreakPossible())
            {
                Block2 oldMate = grandfather.Mate;
                if (grandfather.Mate == grandfather.Right)
                {
                    if (grandfather.Left != null && grandfather.Left.Pending && grandfather.Left.Mate == grandfather)
                    {
                        grandfather.Mate = grandfather.Left;
                        grandfather.Pending = false;
                    }
                    else
                    {
                        grandfather.Mate = null;
                    }

                    if (oldMate.Right != null && oldMate.Right.Pending && oldMate.Right.Mate == oldMate)
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
                    if (grandfather.Right != null && grandfather.Right.Pending && grandfather.Right.Mate == grandfather)
                    {
                        grandfather.Mate = grandfather.Right;
                        grandfather.Mate.Pending = false;
                    }
                    else
                    {
                        grandfather.Mate = null;
                    }

                    if (oldMate.Left != null && oldMate.Left.Pending && oldMate.Left.Mate == oldMate)
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

        private static void DeleteNode(Node node)
        {
            bool wasFatherFull = node.Father.IsFull;
            bool wasGrandfatherFull = node.Father.Father.IsFull;

            Block1 father = node.Father;
            Block2 grandfather = node.Father.Father;

            father.Remove(node);

            if (wasFatherFull)
            {
                if (father.Mate != null)
                {
                    father.Mate.TransferToMate();
                }
                else if (father.Right != null && father.Right.Mate == null)
                {
                    father.Mate = father.Right;
                    father.Right.Mate = father;
                    father.Mate.TransferToMate();
                }
                else if (father.Left != null && father.Left.Mate == null)
                {
                    father.Mate = father.Left;
                    father.Left.Mate = father;
                    father.Mate.TransferToMate();
                }
                else if (father.Right != null)
                {
                    Node sharedNode = father.Right.Nodes[0];
                    bool wasFullRight = father.Right.IsFull;
                    father.Right.Remove(sharedNode);
                    if (wasFullRight)
                    {
                        father.Right.Mate.TransferToMate();
                    }
                    father.Add(father.Nodes.Count, sharedNode);
                }
                else if (father.Left != null)
                {
                    Node sharedNode = father.Left.Nodes[father.Left.Nodes.Count - 1];
                    bool wasFullLeft = father.Left.IsFull;
                    father.Left.Remove(sharedNode);
                    if (wasFullLeft)
                    {
                        father.Left.Mate.TransferToMate();
                    }
                    father.Add(0, sharedNode);
                }
            }

            if (wasGrandfatherFull && grandfather.IsFull == false)
            {
                if (grandfather.Mate != null)
                {
                    grandfather.Mate.TransferToMate();
                }
                else if (grandfather.Right != null && grandfather.Right.Pending == false && grandfather.Right.Mate == null)
                {
                    grandfather.Right.Mate = grandfather;
                    grandfather.Mate = grandfather.Right;
                    grandfather.Mate.TransferToMate();
                }
                else if (grandfather.Left != null && grandfather.Left.Pending == false && grandfather.Left.Mate == null)
                {
                    grandfather.Left.Mate = grandfather;
                    grandfather.Mate = grandfather.Left;
                    grandfather.Mate.TransferToMate();
                }
                else if (grandfather.Right != null && grandfather.Right.Pending)
                {
                    grandfather.Right.Pending = false;
                    grandfather.Right.Mate = grandfather;
                    grandfather.Mate = grandfather.Right;
                    grandfather.Mate.TransferToMate();
                }
                else if (grandfather.Left != null && grandfather.Left.Pending)
                {
                    grandfather.Left.Pending = false;
                    grandfather.Left.Mate = grandfather;
                    grandfather.Mate = grandfather.Left;
                    grandfather.Mate.TransferToMate();
                }
                else if (grandfather.Right != null)
                {
                    grandfather.Mate = grandfather.Right;
                    grandfather.Pending = true;
                }
                else if (grandfather.Left != null)
                {
                    grandfather.Mate = grandfather.Left;
                    grandfather.Pending = true;
                }
            }
        }

        private static void GAdd(Node v, Node l)
        {
            Group g = l.Group;
            v.Group = g;
            v.Component = g.Component;
            int position = g.Nodes.FindIndex(x => x == l);
            g.Nodes.Insert(position + 1, v);
        }

        private static void Transfer(Block2 from, Block2 to)
        {
            if (from.Right == to)
            {
                Block1 what = from.Blocks1[from.Blocks1.Count - 1];
                from.Remove(what);
                to.Add(0, what);

                if (what.Mate != null)
                {
                    what = from.Blocks1[from.Blocks1.Count - 1];
                    from.Remove(what);
                    to.Add(0, what);
                }
            }
            else
            {
                Block1 what = from.Blocks1[0];
                from.Remove(what);
                to.Add(to.Blocks1.Count, what);

                if (what.Mate != null)
                {
                    what = from.Blocks1[0];
                    from.Remove(what);
                    to.Add(to.Blocks1.Count, what);
                }
            }
        }

        #endregion Private Methods.
    }
}
