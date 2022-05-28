using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerSearchTree;
using GroupAndComponent;
using Blocks;

namespace Nodes
{
    public class Node
    {
        public Group Group { get; set; }

        public Block1 Father { get; set; }

        public Component Comp { get; set; }

        public bool NewNode { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Degree { get; }
    }
}
