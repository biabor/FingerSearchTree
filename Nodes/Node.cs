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

            block1.OldNode = fatherNode;
            block1.NewNode = fatherNode;

            block2.Group = fatherNode.Group;
            block2.Node = fatherNode;

            Comp = comp;
            NewNode = false;
            Group = group;
        }

        internal Node FindChildNodeContaining(int searchValue)
        {
            // we go through all blocks2
            for (int index = 0; index < block2s_.Count(); index++)
            {
                Block2 block2 = block2s_[index];
                //if this the max value contained in this one is smaller, we can skip it.
                if (block2.LastBlock1().LastNode().GetMax() < searchValue)
                    continue;

                // seach in all blocks1 of this block2 for the node.
                Node node = block2.GetNodeContaining(searchValue, out bool bigger);

                //if the node is found then return it.
                if (node != null)
                    return node;
                // if the node is not found, but a bigger node is, then we return the last node from the previous one.
                else if (bigger)
                {
                    if (index == 0)
                        break;
                    else
                        return block2s_[index - 1].LastBlock1().LastNode();
                }
            }

            return block2s_[block2s_.Count - 1].LastBlock1().LastNode();
        }

        internal virtual bool ContainsElement(int searchValue)
        {
            try
            {
                // if it is the root, that we assume that the root can contain all elements.
                if (Father == null || Father.Father == null || Father.Father.Node == null)
                    return true;

                // if it has no children it is a leaf, but this should never happen here. just double checking.
                if (block2s_.Count == 0)
                    return false;

                // if the searchValue is smaller then the minimal Value contained in the subtree rooted at this node, then it means that the node does not contain the value.
                if (searchValue < GetMin())
                    return false;
                
                // if the searchValue is bigger then the maximal Value contained in the subtree rooted at this node, then it means that the node does not contain the value.
                if (GetMax() > searchValue)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal virtual int GetMin()
        {
            if (block2s_.Count == 0)
                return int.MaxValue;

            return block2s_[0].FirstBlock1().FistNode().GetMin();
        }

        internal virtual int GetMax()
        {
            if (block2s_.Count == 0)
                return int.MinValue;

            return block2s_[block2s_.Count - 1].LastBlock1().LastNode().GetMax();
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
            block2s_.Add(block2.Mate);
        }

        public Node(int value) 
        {
            Component comp = new Component(this);
            Group group = new Group(this);

            group.Comp = comp;

            Comp = comp;
            NewNode = false;
            Group = group;
        }
    }
}
