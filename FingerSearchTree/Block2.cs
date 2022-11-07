using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerSearchTree
{
    public class Block2
    {
        public Block2? Left { get; set; }

        public Block2? Right { get; set; }

        public Block2? Mate { get; set; }

        public Node Node { get; set; }

        public List<Block1> Blocks1 { get; }

        public int Degree
        {
            get => Blocks1.Sum(bl => bl.Degree);
        }

        public bool IsFull
        {
            get =>
                Node.Group.IsSplitGroup ?
                Degree >= Bounds.BiP(Node.Level) :
                Degree >= Bounds.Fi(Node.Level);
        }

        public bool Pending { get; set; }

        public int Min
        {
            get => Blocks1.Count == 0 ? int.MaxValue : Blocks1.First().Min;
        }

        public int Max
        {
            get => Blocks1.Count == 0 ? int.MinValue : Blocks1.Last().Max;
        }

        public Block2(Node node)
        {
            Node = node;
            Blocks1 = new List<Block1>();
        }

        internal bool ContainsValue(int value)
        {
            return Min <= value && value <= Max;
        }

        internal Node FindChildContaining(int value)
        {
            if (value > Max)
                return Blocks1.Last().FindChildContaining(value);

            int minpos = 0;
            int maxpos = Blocks1.Count - 1;
            int midpos = (maxpos + minpos) / 2;
            while (Blocks1[midpos].ContainsValue(value) == false && maxpos > minpos)
            {
                if (Blocks1[midpos].Min > value)
                    maxpos = midpos - 1;
                else
                    minpos = midpos + 1;
                midpos = (maxpos + minpos) / 2;
            }

            if (Blocks1[midpos].ContainsValue(value) || Blocks1[midpos].Max < value)
                return Blocks1[midpos].FindChildContaining(value);
            else
            {
                Node first = Blocks1[midpos].Nodes.First();
                if (first.Left != null)
                    return first.Left;
                else
                    return first;
            }
        }

        internal void Add(Block1 left, Block1 middle)
        {
            int position = Blocks1.IndexOf(left);
            Blocks1.Insert(position + 1, middle);
            middle.Father = this;

            Block1? right = left.Right;
            left.Right = middle;
            middle.Left = left;
            middle.Right = right;
            if (right != null)
                right.Left = middle;
        }

        internal void Add(int position, Block1 middle)
        {
            Blocks1.Insert(position, middle);
            middle.Father = this;

            Block1? left = null;
            Block1? right = null;

            if (position > 0)
                left = Blocks1[position - 1];
            if(position < Blocks1.Count - 1)
                right = Blocks1[position + 1];

            if (left != null)
                left.Right = middle;
            middle.Left = left;
            middle.Right = right;
            if (right != null)
                right.Left = middle;
        }

        internal void Remove(Block1 middle)
        {
            Blocks1.Remove(middle);

            Block1? left = middle.Left;
            Block1? right = middle.Right;

            if (left != null)
                left.Right = right;
            if (right != null)
                right.Left = left;

            if(Blocks1.Count == 0)
            {
                Node.Remove(this);
                if (Pending == false && Mate != null)
                    Mate.Mate = null;
            }
        }

        internal void TransferToMate()
        {
            if(Mate.Blocks1.Count == 0)
            {
                Mate.Blocks1.Add(new Block1(Mate));
            }
            if(Mate == Right)
            {
                Block1 from = Blocks1.Last();
                Block1 to = Mate.Blocks1.First();
                Node transferred = from.Nodes.Last();

                bool wasFromFull = from.IsFull;
                bool wasToFull = to.IsFull;

                from.Remove(transferred);

                if(wasFromFull)
                {
                    if (from.Mate != null)
                    {
                        from.Mate.TransferToMate();
                    }
                    else if(from.Left != null)
                    {
                        if (from.Left.Mate == null)
                        {
                            from.Mate = from.Left;
                            from.Left.Mate = from;
                            from.Mate.TransferToMate();
                        }
                        else
                        {
                            Node shared = from.Left.Nodes.Last();
                            bool wasLeftFull = from.Left.IsFull;
                            from.Left.Remove(shared);
                            if (wasLeftFull)
                                from.Left.Mate.TransferToMate();
                            from.Add(0, shared);
                        }
                    }
                }

                to.Add(0, transferred);

                if(wasToFull)
                {
                    if(to.Mate == null)
                    {
                        to.Mate = new Block1(to.Father) { Mate = to };
                        Mate.Add(to, to.Mate);
                    }
                    to.TransferToMate();
                }

                if(to.IsFull && to.Mate != null && to.Mate.IsFull)
                {
                    to.Mate.Mate = null;
                    to.Mate = null;
                }
            }
            else
            {
                Block1 from = Blocks1.First();
                Block1 to = Mate.Blocks1.Last();
                Node transferred = from.Nodes.First();

                bool wasFromFull = from.IsFull;
                bool wasToFull = to.IsFull;

                from.Remove(transferred);

                if (wasFromFull)
                {
                    if(from.Mate != null)
                    {
                        from.Mate.TransferToMate();
                    }
                    else if(from.Right != null)
                    {
                        if(from.Right.Mate == null)
                        {
                            from.Mate = from.Right;
                            from.Right.Mate = from;
                            from.Mate.TransferToMate();
                        }
                        else
                        {
                            Node shared = from.Right.Nodes.First();
                            bool wasRightFull = from.Right.IsFull;
                            from.Right.Remove(shared);
                            if (wasRightFull)
                                from.Right.Mate.TransferToMate();
                            from.Add(from.Nodes.Count, shared);
                        }
                    }
                }

                to.Add(to.Nodes.Count, transferred);

                if (wasToFull)
                {
                    if (to.Mate == null)
                    {
                        to.Mate = new Block1(to.Father) { Mate = to };
                        Mate.Add(to, to.Mate);
                    }
                    to.TransferToMate();
                }

                if (to.IsFull && to.Mate != null && to.Mate.IsFull)
                {
                    to.Mate.Mate = null;
                    to.Mate = null;
                }
            }
        }

        internal void Transfer(Block2 to)
        {
            if(Right == to)
            {
                Block1 transferred = Blocks1.Last();
                Remove(transferred);
                to.Add(0, transferred); 

                if(transferred.Mate != null)
                {
                    transferred = transferred.Mate;
                    Remove(transferred);
                    to.Add(0, transferred);
                }
            }
            else
            {
                Block1 transferred = Blocks1.First();
                Remove(transferred);
                to.Add(to.Blocks1.Count, transferred);

                if (transferred.Mate != null)
                {
                    transferred = transferred.Mate;
                    Remove(transferred);
                    to.Add(to.Blocks1.Count, transferred);
                }
            }

            if (to.Pending && to.IsFull)
            {
                to.Pending = false;
                to.Mate = null;
            }
        }

        internal bool IsBreakPossible()
        {
            if(Mate == Right)
            {
                Block1 block = Blocks1.Last();
                Node node = block.Nodes.Last();

                return node.Right == null ||  node.Group != node.Right.Group;
            }
            else
            {
                Block1 block = Blocks1.First();
                Node node = block.Nodes.First();

                return node.Left == null || node.Group != node.Left.Group;
            }
        }
    }
}
