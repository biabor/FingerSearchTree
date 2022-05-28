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

        public bool NewNode { get; set; } //IsUnderConstruction

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Degree { get => block2s_.Sum(element => element.Degree); }

        private List<Block2> block2s_ = new List<Block2>();


        public Node() 
        {
            Component comp = new Component(this);
            Group group = new Group(this);

            Block1 block1 = new Block1(this);
            Block2 block2 = new Block2(block1);

            Node fatherNode = new Node(block2);

            group.Comp = comp;
            group.Block2 = block2;

            block1.Father = block2;
            block1.OldNode = fatherNode;
            block1.NewNode = fatherNode;

            block2.Group = fatherNode.Group;
            block2.Node = fatherNode;

            Comp = comp;
            NewNode = false;
            Group = group;
            Father = block1;
        }

        public Node(Block2 block2)
        {
            Component comp = new Component(this);
            Group group = new Group(this);

            group.Comp = comp;

            Comp = comp;
            NewNode = false;
            Group = group;

            block2s_.Add(block2);
        }
    }
}
