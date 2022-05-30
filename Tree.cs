using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupAndComponent;
using Blocks;
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

        public void Search(int searchValue)
        {
            dummyLeaf_ = Search(dummyLeaf_, searchValue);
        }

        private DummyLeaf Search(DummyLeaf startingFinger, int searchValue)
        {
            // start at the given finger.
            Node temp = startingFinger;

            //as long as the element is not found and we are not at the root of the while tree.
            while (temp.ContainsElement(searchValue) == false)
            {
                // Try searching the node to the right.
                if (temp.Left != null && temp.Left.ContainsElement(searchValue))
                    temp = temp.Left;

                // Try searching the node to the left.
                if (temp.Right != null && temp.Right.ContainsElement(searchValue))
                    temp = temp.Right;

                //Go to the ancestor.
                if (temp.Father != null && temp.Father.Father != null && temp.Father.Father.Node != null)
                    temp = temp.Father.Father.Node;
                else
                    break;
            }

            // While the searched node is not a finger.
            while(temp is DummyLeaf == false)
            {
                // Search for the child that contains the element.
                temp = temp.FindChildNodeContaining(searchValue);
            }

            return temp as DummyLeaf;
        }

        public void Add(int addValue)
        {
            dummyLeaf_ = Search(dummyLeaf_, addValue);
            if(dummyLeaf_.Value < addValue)
                 dummyLeaf_ = Insert(dummyLeaf_, addValue);
        }

        private DummyLeaf Insert(DummyLeaf dummyLeaf_, int addValue)
        {
            // InsertLeaf.
            DummyLeaf lP = new DummyLeaf(addValue);
            Block1 father = dummyLeaf_.Father;
            father.Add(dummyLeaf_, lP);
            lP.Group.Block2 = lP.Father.Father;

            return lP;
        }
    }
}
