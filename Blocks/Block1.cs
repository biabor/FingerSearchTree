using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerSearchTree;
using Nodes;

namespace Blocks
{
    public class Block1
    {
        public Block2 Father { get; set; }

        public Block1 Mate { get; set; }

        public Node OldNode { get; set; }

        public Node NewNode { get; set; }
        
        public Block1 Left { get; set; }

        public Block2 Right { get; set; }

        public int Degree { get => nodes_.Count; }

        private List<Node> nodes_ = new List<Node>();

        public Block1(Node node)
        {
            nodes_.Add(node);
        }
    }
}
