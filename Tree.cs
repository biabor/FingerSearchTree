using GroupAndComponent;
using Nodes;

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

            Group f = right.FatherNode.Group;

            Group r = Find(f, right.FatherNode);


            MultiBreak(r);

            Node u = r.Block2.Node;
            if (u.Blocks2.Count >= 4)
            {
                Node uP = Split(u);

                //Node z = Find(right.FatherNode);
                //Break(z);

                //List<Node> zNodes = MultiSplit(z);
                //Node y = Find(z.FatherNode);

                //foreach (Node u in zNodes)
                //    Add(u, y);
            }
            return right;
        }

        private static Node Split(Node u)
        {
            // Rebalance Node u
            u.Group.IsSplitGroup = true;
            u.IsUnderContruction = true;

            // Split the node.
            Node uP = new Node(); //TODO: move blocks.
            GAdd(uP, u.Group);
            return uP;
        }

        /// <summary>
        /// Finds the root group of the component containing the group f, which in itself contains node node
        /// </summary>
        /// <param name="f">group </param>
        /// <param name="node">node</param>
        /// <returns>oot group of the component containing the group f</returns>
        private static Group Find(Group f, Node node)
        {
            if (f.Valid && f.Component.Valid)
                return f.Component.Root;

            if (f.Valid)
            {
                f.Component = new Component(f);
                return f;
            }

            // TODO: understand better this part. Page 28-29 
            node.Group = new Group(node);
            return node.Group;
        }

        /// <summary>
        /// Adds node v to the group G.
        /// </summary>
        /// <param name="v">Node to be added</param>
        /// <param name="G">Group to be added in.</param>
        private static void GAdd(Node v, Group G)
        {
            G.Nodes.Add(v);
            v.Group = G;
            v.IsUnderContruction = true;
        }

        private static void MultiBreak(Group G)
        {
            G.Valid = false;
            if (G.IsSplitGroup)
            {
                G.Component.Valid = false;
            }
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

        ///// <summary>
        ///// Adds node u, which is a singleton component, in the component with handle y.
        ///// It is assumed that y is the handle of the valid component of father(u).
        ///// </summary>
        ///// <param name="u">Node to change its component</param>
        ///// <param name="y">Handle of the father(u) component.</param>
        //private static void Add(Node u, Node y)
        //{
        //    Component component = y.Component;

        //    u.Component = component;
        //    component.Nodes.Add(u);
        //}

        //private static List<Node> MultiSplit(Node z)
        //{
        //    return new List<Node>() { z }; // TODO 
        //}

        ///// <summary>
        ///// Breaks the component in which the node is.
        ///// </summary>
        ///// <param name="z">the node of which component to break</param>
        //private static void Break(Node z)
        //{
        //    z.Component.Valid = false;
        //}

        ///// <summary>
        ///// Component method: finds the root of the component containing the given node.
        ///// </summary>
        ///// <param name="node">Node of which the component root is found.</param>
        ///// <returns>the component root</returns>
        //private static Node Find(Node node)
        //{
        //    Component component = node.Component;

        //    if (component.Valid)
        //        return component.Root;

        //    component.Nodes.Remove(node);
        //    node.Component = new Component(node);
        //    return node;

        //}
    }
}
