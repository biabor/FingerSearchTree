using System.Collections.Generic;
using System.Linq;
using Blocks;
using Nodes;

namespace GroupAndComponent
{
    public class Group
    {
        public int Degree { get => Nodes.Sum(node => node.Degree); }

        public bool Valid { get; set; } = true;

        public bool IsSplitGroup { get; set; } = true;

        public Component Component { get; set; } = null;

        public Block2 Block2 { get; set; } = null;

        public List<Node> Nodes = new List<Node>();

        public Group Mate { get; set; } = null;

        public Group(Node node)
        {
            Nodes.Add(node);
            Component = new Component(this);
            if (node.FatherNode != null)
                Block2 = node.Father.Father;
        }

        public void Add(Node node)
        {
            Nodes.Add(node);
            node.Group = this;
            node.IsUnderContruction = true;
        }
    }
}
