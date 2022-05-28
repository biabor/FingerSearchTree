using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupAndComponent;
using Nodes;

namespace FingerSearchTree
{
    class Tree
    {
        private DummyLeaf dummyLeaf_;

        public Tree()
        {
            dummyLeaf_ = CreateList();
        }

        public DummyLeaf CreateList()
        {
            return new DummyLeaf();
        }
    }
}
