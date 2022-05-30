using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerSearchTree;
using Nodes;
using GroupAndComponent;

namespace Blocks
{
    public class Block1
    {
        public Block2 Father { get; set; }

        public Block1 Mate { get; set; }

        public Node OldNode { get; set; }

        public Node NewNode { get; set; }

        public Block1 Left { get; set; }

        public Block1 Right { get; set; }

        public int Degree { get => nodes_.Count; }

        public bool IsFull { get => Degree >= 3; }

        private List<Node> nodes_ = new List<Node>();

        public Block1(Block1 mate)
        {
            Mate = mate;
        }

        public Block1(Node node)
        {
            nodes_.Add(node);
            node.Father = this;
            Mate = new Block1(this);
            Right = Mate;
            Mate.Left = this;
        }

        public Node FistNode()
        {
            if (nodes_.Count == 0)
                return null;
            return nodes_[0];
        }

        public Node LastNode()
        {
            if (nodes_.Count == 0)
                return Left.LastNode();
            return nodes_[nodes_.Count - 1];
        }

        internal Node GetNodeContaining(int searchValue, out bool isBigger)
        {
            // go through all the elements. 
            for (int index = 0; index < nodes_.Count; index++)
            {
                Node node = nodes_[index];

                // ig we found one, just return it.
                if (node.ContainsElement(searchValue))
                {
                    isBigger = false;
                    return node;
                }
                if (node.GetMin() > searchValue)
                {
                    // if we found a bigger one, then all the next ones are bigger, and we return the previous one that is smaller. 
                    isBigger = true;
                    if (index == 0)
                        return null;
                    else
                        return nodes_[index - 1];
                }
            }

            isBigger = false;
            return null;
        }

        public void Add(Node e, Node eP)
        {
            // find position to insert.
            int positionEP = 0;
            for (; positionEP < nodes_.Count; positionEP++)
            {
                if (nodes_[positionEP] == e)
                {
                    break;
                }
            }
            positionEP++;

            // actually insert in the list.
            nodes_.Insert(positionEP, eP);
            eP.Father = this;

            // Make sure the left/right pointers are set correctly.
            Node aux = e.Right;
            e.Right = eP;
            eP.Left = e;
            e.Group.Right = eP.Group;
            eP.Group.Left = e.Group;

            if (aux != null)
            {
                eP.Right = aux;
                aux.Left = eP;
                eP.Group.Right = aux.Group;
                aux.Group.Left = eP.Group;
            }

            if (Degree > 3)
            {
                if (Mate == Right)
                {
                    Mate.Transfer(nodes_[nodes_.Count - 1], true);
                    nodes_.RemoveAt(nodes_.Count - 1);
                }
                else
                {
                    Mate.Transfer(nodes_[0], false);
                    nodes_.RemoveAt(0);
                }
            }

            if (IsFull && Mate != null && Mate.IsFull)
            {
                if (Mate == Right)
                {
                    Block1 oldMate = Mate;

                    Mate = new Block1(this);
                    Father.Add(this, Mate);

                    Block1 oldMateRightNew = new Block1(oldMate);
                    Father.Add(oldMate, oldMateRightNew);
                }
                else
                {
                    Block1 oldMate = Mate;

                    Mate = new Block1(this);
                    Father.Add(this, Mate);

                    oldMate.Mate = new Block1(oldMate);
                    Father.Add(oldMate, oldMate.Mate);
                }
            }
        }

        public void Transfer(Node node, bool atStart)
        {
            if (atStart)
            {
                nodes_.Insert(0, node);
            }
            else
            {
                nodes_.Insert(nodes_.Count, node);
            }
            node.Father = this;
        }
    }
}
