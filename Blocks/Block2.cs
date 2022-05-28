using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerSearchTree;
using GroupAndComponent;
using Nodes;

namespace Blocks
{
    public class Block2
    {
        public Group Group { get; set; }

        public Block2 Mate { get; set; }

        public bool Pending { get; set; }

        public Node Node { get; set; }

        public Block2 Left { get; set; }

        public Block2 Right { get; set; }

        public int Degree { get => children_.Sum(element => element.Degree); }

        private List<Block1> children_ = new List<Block1>();

        public Block2(Block1 child)
        {
            children_.Add(child);
            Pending = false;
        }
    }
}
