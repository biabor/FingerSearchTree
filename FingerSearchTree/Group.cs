namespace FingerSearchTree
{
    public class Group
    {
        public Group? Left
        {
            get => Nodes.First().Left?.Group;
        }

        public Group? Right
        {
            get => Nodes.Last().Right?.Group;
        }

        public List<Node> Nodes { get; }

        public Block2? Block2
        {
            get => Nodes.Count == 0 ? null : Nodes.First().Father?.Father;
        }

        public Component Component { get; private set; }


        public bool IsSplitGroup
        {
            get => Degree > 4 * Bounds.Fi(Level);
        }

        public int Degree
        {
            get => Nodes.Sum(node => node.Degree);
        }

        public bool hasOnlyOneBlock1
        {
            get
            {
                if (Nodes.Count != 1)
                    return false;
                if (Nodes.First().Blocks2.Count != 1)
                    return false;
                return Nodes.First().Blocks2.First().Blocks1.Count == 1;
            }
        }

        public int Level
        {
            get => Nodes.Count == 0 ? -1 : Nodes.First().Level;
        }

        public bool Valid { get; internal set; }

        public Group(Node node)
        {
            Nodes = new List<Node> { node };
            Component = new Component(node);
            Valid = true;
        }

        public Group(Node node, Component component) : this(node)
        {
            if (component.Valid)
                Component = component;
        }

        internal void MultiBreak()
        {
            Component.Valid = false;
            Valid = false;
            if (Block2 != null)
                Component = Block2.Node.Component;
            else
                Component = new Component(Nodes.First());
        }

        internal void Fuse(Group g)
        {
            bool left = Left == g;
            if (hasOnlyOneBlock1)
            {
                Block2 to = g.Nodes.First().Blocks2.First();
                Block2 from = Nodes.First().Blocks2.First();
                Block1 what = from.Blocks1.First();

                Node fatherNode = from.Node;
                fatherNode.Fused = true;
                from.Remove(what);
                fatherNode.Fused = false;

                Tree.DeleteNode(fatherNode);

                if (left)
                    to.Add(to.Blocks1.Count, what);
                else
                    to.Add(0, what);

                if (to.Pending && to.IsFull)
                {
                    to.Pending = false;
                    to.Mate = null;
                }
                return;
            }

            if (g.hasOnlyOneBlock1)
            {
                g.Fuse(this);
                return;
            }

            if (Nodes.First().Blocks2.Count == 1)
            {
                Node from = Nodes.First();
                Node to = g.Nodes.First();
                Block2 what = from.Blocks2.First();

                from.Fused = true;
                from.Remove(what);
                from.Fused = false;

                Tree.DeleteNode(from);

                if (what.Mate != null && what.Pending == false)
                    what.Mate.Mate = null;
                what.Mate = null;
                what.Right = null;
                what.Left = null;

                Block2? whatNeighbour;
                if (left)
                {
                    to.Add(to.Blocks2.Count, what);
                    whatNeighbour = what.Left;
                }
                else
                {
                    to.Add(0, what);
                    whatNeighbour = what.Right;
                }

                if (whatNeighbour != null)
                {
                    if ((what.IsFull && whatNeighbour.IsFull == false && whatNeighbour.Mate == null) || (what.IsFull == false && whatNeighbour.IsFull && whatNeighbour.Mate == null))
                    {
                        what.Mate = whatNeighbour;
                        whatNeighbour.Mate = what;
                    }
                    else if (whatNeighbour.Mate != null && whatNeighbour.Pending && what.IsFull == false)
                    {
                        what.Mate = whatNeighbour;
                        what.Pending = true;
                    }
                }
                return;
            }
            else if (g.Nodes.First().Blocks2.Count == 1)
            {
                g.Fuse(this);
                return;
            }
        }

        internal void Share(Group g)
        {
            if (hasOnlyOneBlock1)
            {
                if (Left == g)
                {
                    Node from = g.Nodes.Last();
                    Node to = Nodes.First();
                    Block2 removed = to.Blocks2.First();
                    Block2 transferred = from.Blocks2.Last();
                    Block1 added = removed.Blocks1.First();

                    to.Fused = true;
                    removed.Remove(added);
                    to.Fused = false;

                    from.Remove(transferred);
                    to.Add(0, transferred);

                    if (transferred.Mate != null && transferred.Pending == false)
                        transferred.Mate.Mate = null;
                    transferred.Mate = null;
                    transferred.Pending = false;

                    transferred.Add(transferred.Blocks1.Count, added);
                }
                else
                {
                    Node from = g.Nodes.First();
                    Node to = Nodes.Last();
                    Block2 removed = to.Blocks2.Last();
                    Block2 transferred = from.Blocks2.First();
                    Block1 added = removed.Blocks1.Last();

                    to.Fused = true;
                    removed.Remove(added);
                    to.Fused = false;

                    from.Remove(transferred);
                    to.Add(to.Blocks2.Count, transferred);

                    if (transferred.Mate != null && transferred.Pending == false)
                        transferred.Mate.Mate = null;
                    transferred.Mate = null;
                    transferred.Pending = false;

                    transferred.Add(0, added);
                }
            }
            else
                g.Share(this);
        }

        internal bool CanBeFused(Group g)
        {
            if (Degree + g.Degree > 4 * Bounds.Fi(Level))
                return false;

            if (IsSplitGroup || g.IsSplitGroup)
                return false;

            if (Nodes.Count != 1 && g.Nodes.Count != 1)
                return false;

            if (Block2 != g.Block2) return false;

            return (Nodes.First().Blocks2.Count == 1 && g.Nodes.First().Blocks2.Count <= 3) || (g.Nodes.First().Blocks2.Count == 1 && Nodes.First().Blocks2.Count <= 3);
        }
    }
}
