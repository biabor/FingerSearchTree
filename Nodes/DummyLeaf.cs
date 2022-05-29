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
    public class DummyLeaf: Node
    {
        public int Value { get; set; }

        public DummyLeaf() 
        {
            Value = int.MinValue;
        }

        internal override int GetMin()
        {
            return Value;
        }

        internal override int GetMax()
        {
            return Value;
        }

        internal override bool ContainsElement(int searchedValue)
        {
            return Value == searchedValue;
        }
    }
}
