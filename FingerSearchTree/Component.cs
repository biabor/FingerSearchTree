using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerSearchTree
{
    public class Component
    {
        public bool Valid { get; set; }

        public Node Root { get; }

        public Component(Node root)
        {
            Root = root;
            Valid = true;
        }
    }
}
