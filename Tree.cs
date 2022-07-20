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

            Node r = Find(newLeaf.Father);
            int i = r.Level + 1;
            bool isRSecureInvterval = Helpers.Fi(i-1) * 4 < r.Degree && r.Degree < Helpers.BiP(i-1);

            Group rPP = MultiBreak(r.Group);
            Group rP = rPP.Left;

            if (isRSecureInvterval)
                rPP.IsSplitGroup = true;

            if(rPP.Nodes.Count == 1 && rPP.Nodes[0].Blocks2.Count == 1 && rPP.Nodes[0].Blocks2[0].Blocks1.Count == 1)
            {
                if (rPP.Degree + rP.Degree <= 4 * Helpers.Fi(i))
                    GFuse(rPP, rP);
                else
                    GShare(rPP, rP);
            }

            return newLeaf;
        }

        #region Private Methods.

        private static Node Find(Block1 father)
        {
            Node f = father.Father.Node;

            if (f.Group.IsSplitGroup)
            {
                if (f.Group.Valid)
                {
                    if (f.Group.Component.Valid)
                        return f.Group.Component.Root;
                    else
                    {
                        f.Component = new Component(f);
                        f.Group.Component = f.Component;
                        return f.Group.Component.Root;
                    }
                }
                else
                {
                    f.Component = new Component(f);
                    f.Group = new Group(f)
                    {
                        Component = f.Component,
                        IsSplitGroup = true
                    };
                    return f.Component.Root;
                }
            }
            else
            {
                f = father.OldNode.Group.Valid ? father.OldNode : father.NewNode;

                if (f.Component.Valid)
                    return f.Component.Root;
                else
                {
                    f.Component = new Component(f);
                    return f.Component.Root;
                }
            }
        }

        private static Group MultiBreak(Group g)
        {
            g.Valid = false;
            if (g.IsSplitGroup)
            {
                g.Component.Valid = false;
                /// Adds all the new nodes to the component in which their father group z belongs?
                return g;
            }
            else
            {
                // TODO break all components rooted at nodes inside this fusion group simultaneously and in constant time.
                //foreach(Node n in g.Nodes)
                //{
                //    if (n.Component.Root == n)
                //        n.Component.Valid = false;
                //}
                //g.Nodes.ForEach(n => { if (n.Component.Root == n) n.Component.Valid = false; });

                if (g.Mate != null && g.Mate.Valid == false)
                {
                    MultiBreak(g.Mate);
                }

                Node node = g.Nodes[0];
                //node.Component = node.FatherNode.Component; // ???
                g.Component = node.Component;
                return g;
            } 
        }

        private static void GFuse(Group g, Group gP)
        {
            //if (g.Degree > gP.Degree)
            //    GFuse(gP, g);

            // TODO transfer block2 p of g to gP in constant time


            g.Mate = gP;
            gP.Mate = g;

            if (gP.Right == g)
            {
                // TODO gP.Incr = g.LeftMostBlock1
            }
            else
            {
                // TODO gP.Incr = g.RightMostBlock1
            }

            // More specifically, fields oldnode and newnode of blocks1 and field group of the nodes are updated incrementally
            // gP will not participate in a new Gfuse operation as long as the incremental transfer contninues.
            // When the transfer ends, g is discarded and gP.mate as well as gP.incr are set to null.

            // When GFuse involves a normal singleton group gP and a small group g, the node under construction will be the singleton node inside gP.
            // In this way, there is no need to update the fields of blocks1 inside the only node of gP.
        }

        private static void GShare(Group g, Group gP)
        {
            MultiBreak(gP);
            if (g.Degree > gP.Degree)
                GFuse(gP, g);
            //Move a block2 pP from gP to g incrementally, in order to update the corresponding pointer fields of blocks1 and nodes.
            //insert block1 q (the only one of g)to pP
            //When the transfer ends, pointers g.Mate, gP.Mate are set to null
        }

        private static Node Split(Node node)
        {
            List<Block2> block2s = GetAndRemoveLastPairOfBlocks2(node);
            if (block2s == null)
                return null;

            Node nodeP = new Node()
            {
                Blocks2 = block2s,
                Level = node.Level
            };

            if (node.FatherNode == null)
            {
                new Node(new Block2(new Block1(node)));
            }

            node.Father.Add(node, nodeP);

            GAdd(nodeP, node.Group);
            return nodeP;
        }

        private static void GAdd(Node v, Group g)
        {
            if(v.Group != null)
                v.Group.Nodes.Remove(v);
            v.Group = g;
            v.Group.Nodes.Add(v);
            v.IsUnderContruction = true;
        }

        private static List<Block2> GetAndRemoveLastPairOfBlocks2(Node node)
        {
            if (node.Blocks2.Count < 4)
                return null;

            List<Block2> block2s = new List<Block2>();
            Block2 bl2 = node.Blocks2[node.Blocks2.Count - 1];
            block2s.Add(bl2);
            if (bl2.Pending)
            {
                block2s.Add(node.Blocks2[node.Blocks2.Count - 2]);
                block2s.Add(node.Blocks2[node.Blocks2.Count - 3]);
                if (node.Blocks2[node.Blocks2.Count - 4].Pending)
                    block2s.Add(node.Blocks2[node.Blocks2.Count - 4]);
            }
            else
            {
                block2s.Add(node.Blocks2[node.Blocks2.Count - 2]);
                if (node.Blocks2[node.Blocks2.Count - 3].Pending)
                    block2s.Add(node.Blocks2[node.Blocks2.Count - 3]);
            }

            block2s.Reverse();

            if (block2s.Contains(node.Blocks2[0]))
                return null;

            node.Blocks2.RemoveAll(x => block2s.Contains(x));
            return block2s;
        }

        #endregion Private Methods.
    }
}
