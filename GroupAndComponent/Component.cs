using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerSearchTree;
using Nodes;

namespace GroupAndComponent
{
    public class Component
    {
        public bool Valid { get; set; }

        public Node Root { get; set; }

        //public Component Left { get; set; }

        //public Component Right { get; set; }

        public int Degree { get; set; } = 0;

        public Component(Node root)
        {
            Root = root;
            Valid = true;
            Degree++;
        }
    }
}
