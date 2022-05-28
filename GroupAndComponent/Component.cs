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

        public Component Left { get; set; }

        public Component Right { get; set; }

        public int Degree { get; set; }
    }
}
