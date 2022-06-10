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

        public Node Find(Node u)
        {
            if (u.Comp != this)
                return u.Comp.Find(u);
            
            if (Valid)
                return Root;

            u.Comp = new Component(u);
            return u;
        }

        public void Break(Node z)
        {
            if (z.Comp != this)
            {
                z.Comp.Break(z);
                return;
            }

            Valid = false;
            z.Comp = new Component(z);
        }

        public bool Add(Node v, Node z)
        {
            if (z.Comp != this)
                return z.Comp.Add(v, z);

            if(v.Comp.Degree != 1)
                return false;
            Node faV = v.FatherNode;
            if (faV == null)
                return false;
            if (faV.Comp.Valid == false || faV.Comp.Find(faV) != z)
                return false;

            v.Comp = this;
            Degree++;
            return true;
        }
    }
}
