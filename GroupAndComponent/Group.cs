using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerSearchTree;
using Blocks;
using Nodes;

namespace GroupAndComponent
{
    public class Group
    {
        public bool Valid { get; set; }

        public bool Type { get; set; } // IsSplitGroup;

        public Component Comp { get; set; }

        public Block2 Block2 { get; set; }

        public Group Mate { get; set; }

        public Block1 Incr { get; set; }

        public Group Left { get; set; }

        public Group Right { get; set; }

        public int Degree { get => nodes_.Count; }

        private List<Node> nodes_ = new List<Node>();

        public Group(Node node)
        {
            Valid = true;
            nodes_.Add(node);
        }
    }
}
