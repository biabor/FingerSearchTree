using System.Collections.Generic;
using System.Linq;
using Blocks;
using Nodes;

namespace GroupAndComponent
{
    public class Group
    {
        public int Degree { get => Nodes.Sum(node => node.Degree); }
        
        public int Level { get; set; } = 0;

        public bool Valid { get; set; } = true;

        public bool IsSplitGroup { get; set; } = false;

        public Component Component { get; set; } = null;

        public Block2 Block2 { get => Nodes[0].Father?.Father; }

        public List<Node> Nodes = new List<Node>();

        public Group(Node node)
        {
            Nodes.Add(node);
            Level = node.Level;
        }

        public Group Right(Node node)
        {
            if (Valid)
            {
                Group right = Nodes[Nodes.Count - 1].Right?.Group;

                if (right == null)
                    return null;

                if (right.Valid)
                    return right;

                if (right.Nodes.Count == 1)
                {
                    right.Valid = true;
                    return right;
                }

                Node first = right.Nodes[0];
                right.Nodes.Remove(first);
                first.Group = new Group(first)
                {
                    IsSplitGroup = right.IsSplitGroup,
                    Component = right.Component
                };
                return first.Group;
            }
            else
            {
                if (Nodes.Count == 1)
                    Valid = true;
                else
                {
                    Nodes.Remove(node);
                    node.Group = new Group(node)
                    {
                        IsSplitGroup = this.IsSplitGroup,
                        Component = this.Component
                    };
                }

                Node first = node.Right;

                if (first == null)
                    return null;

                Group right = first.Group;

                if (right.Valid)
                    return right;

                if(right.Nodes.Count == 1)
                {
                    right.Valid = true;
                    return right;
                }

                right.Nodes.Remove(first);
                first.Group = new Group(first)
                {
                    IsSplitGroup = right.IsSplitGroup,
                    Component = right.Component
                };
                return first.Group;
            }
        }

        public Group Left(Node node)
        {
            if (Valid)
            {
                Group left = Nodes[0].Left?.Group;

                if (left == null)
                    return null;

                if (left.Valid)
                    return left;

                if(left.Nodes.Count == 1)
                {
                    left.Valid = true;
                    return left;
                }

                Node last = left.Nodes[left.Nodes.Count - 1];
                left.Nodes.Remove(last);
                last.Group = new Group(last)
                {
                    IsSplitGroup = left.IsSplitGroup,
                    Component = left.Component
                };
                return last.Group;
            }
            else
            {
                if (Nodes.Count == 1)
                    Valid = true;
                else
                {
                    Nodes.Remove(node);
                    node.Group = new Group(node)
                    {
                        IsSplitGroup = this.IsSplitGroup,
                        Component = this.Component
                    };
                }

                Node last = node.Left;

                if (last == null)
                    return null;

                Group left = last.Group;

                if (left.Valid)
                    return left;

                if(left.Nodes.Count == 1)
                {
                    left.Valid = true;
                    return left;
                }

                left.Nodes.Remove(last);
                last.Group = new Group(last)
                {
                    IsSplitGroup = left.IsSplitGroup, //TODO vezi daca chiar e left
                    Component = left.Component
                };
                return last.Group;
            }
        }
    }
}
