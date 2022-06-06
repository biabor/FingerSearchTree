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
        public Group Group { get => Node.Group; }

        public Block2 Mate { get; set; }

        public bool Pending { get; set; }

        public Node Node { get; set; }

        public Block2 Left { get; set; }

        public Block2 Right { get; set; }

        public int Degree { get => children_.Sum(element => element.Degree); }

        public bool IsFull { get => children_.Count >= 6; }

        private List<Block1> children_ = new List<Block1>();

        public Block2(Block2 mate)
        {
            Mate = mate;
        }

        public Block2(Block1 child)
        {
            children_.Add(child);
            children_.Add(child.Mate);
            child.Father = this;
            child.Mate.Father = this;
            Pending = false;
            Mate = new Block2(this);
            Right = Mate;
            Mate.Left = this;
        }

        public Block1 FirstBlock1()
        {
            if (children_.Count == 0)
                return null;
            return children_[0];
        }

        public Block1 LastBlock1()
        {
            if (children_.Count == 0)
                return Left.LastBlock1();
            return children_[children_.Count - 1];
        }

        internal Node GetNodeContaining(int searchValue, out bool biggerFound)
        {
            // goes through all blocks1
            for (int index = 0; index < children_.Count; index++)
            {
                Block1 block1 = children_[index];
                // we skip the ones that contain only smaller elements.
                if (block1.LastNode().GetMax() < searchValue)
                    continue;

                // search for the node.
                Node node = block1.GetNodeContaining(searchValue, out bool isBigger);

                // if the node is found, or if the biggest node smaller is found, just return it.
                if (node != null)
                {
                    biggerFound = isBigger;
                    return node;
                }
                else if (isBigger)
                {
                    // if all nodes are bigger, then return the biggest node from the previous blick1.
                    biggerFound = true;
                    if (index == 0)
                        return null;
                    else
                        return children_[index - 1].LastNode();
                }
            }

            biggerFound = false;
            return null;
        }

        public void Add(Block1 e, Block1 eP)
        {
            if (IsFull && Mate != null && Mate.IsFull)
            {
                if (Invariant5Holds())
                {
                    Block2 oldMate = Mate;

                    Mate = new Block2(this);
                    Node.Add(this, Mate);

                    oldMate.Mate = new Block2(oldMate);
                    oldMate.Node.Add(oldMate, oldMate.Mate);
                }
            }

            // find position to insert.
            int positionEP = 0;
            for (; positionEP < children_.Count; positionEP++)
            {
                if (children_[positionEP] == e)
                {
                    break;
                }
            }
            positionEP++;

            // actually insert in the list.
            children_.Insert(positionEP, eP);
            eP.Father = this;

            // Make sure the left/right pointers are set correctly.
            Block1 aux = e.Right;
            e.Right = eP;
            eP.Left = e;

            if (aux != null)
            {
                eP.Right = aux;
                aux.Left = eP;
            }

            if (children_.Count > 6)
            {
                if (Mate == Right)
                {
                    Block1 toBeTransferred = children_[children_.Count - 1];
                    Mate.Transfer(toBeTransferred, true);
                    children_.Remove(toBeTransferred);
                }
                else
                {
                    Block1 toBeTransferred = children_[0];
                    Mate.Transfer(toBeTransferred, false);
                    children_.Remove(toBeTransferred);
                }
            }
        }

        private bool Invariant5Holds()
        {
            if (FirstBlock1().Left != null && FirstBlock1().FirstNode().Group == FirstBlock1().Left.LastNode().Group)
                return false;

            if (LastBlock1().Right != null && LastBlock1().LastNode().Group == LastBlock1().Right.FirstNode().Group)
                return false;
            return true;
        }

        public void Transfer(Block1 block1, bool atStart)
        {
            if (atStart)
            {
                children_.Insert(0, block1);
            }
            else
            {
                children_.Insert(children_.Count, block1);
            }

            block1.Father = this;
        }
    }
}
