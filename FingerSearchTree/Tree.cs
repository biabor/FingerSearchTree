namespace FingerSearchTree
{
    public static class Tree
    {
        public static Leaf CreateTree()
        {
            Node root = new Node(1);
            Block2 block2 = new Block2(root);
            Block1 block1 = new Block1(block2);
            Leaf leaf = new Leaf(block1, int.MinValue);

            block1.Nodes.Add(leaf);
            block2.Blocks1.Add(block1);
            root.Blocks2.Add(block2);

            return leaf;
        }

        public static Leaf Search(Leaf lastLeaf, int value)
        {
            Node temp = lastLeaf;

            while (temp.ContainsValue(value) == false)
            {
                if (temp.Left != null && temp.Left.ContainsValue(value))
                    temp = temp.Left;
                else if (temp.Right != null && temp.Right.ContainsValue(value))
                    temp = temp.Right;
                else if (temp.FatherNode != null)
                    temp = temp.FatherNode;
                else
                    break;
            }

            while (temp is Leaf == false)
            {
                temp = temp.FindChildContaining(value);
            }

            return temp as Leaf;
        }

        public static Leaf Insert(Leaf left, int value)
        {
            if (left.Father != null && left.FatherNode != null)
            {
                Leaf newLeaf = new Leaf(left.Father, value);

                AddNode(left, newLeaf);

                if (left.FatherNode.Degree >= Bounds.BiP(left.FatherNode.Level))
                {
                    if (left.FatherNode.ContainsAtLeastTwoBlock2Pairs)
                    {
                        Node node = left.FatherNode;
                        Node newNode = node.Split();
                        AddNode(node, newNode);
                    }
                }
                else if (8 * Bounds.Fi(left.FatherNode.Level) < left.FatherNode.Degree)
                {
                    Block2 firstBlock2 = left.Father.Father;
                    Block2? secondBlock2 = firstBlock2.Mate ?? firstBlock2.Right ?? firstBlock2.Left;
                    if (secondBlock2 != null)
                    {
                        if (secondBlock2.Degree <= firstBlock2.Degree)
                        {
                            secondBlock2.Transfer(firstBlock2);
                        }
                        else if (secondBlock2.Degree > firstBlock2.Degree)
                        {
                            firstBlock2.Transfer(secondBlock2);
                        }
                    }
                }

                Rebalance(left.FatherNode);

                return newLeaf;
            }
            return left;
        }

        public static Leaf Delete(Leaf leaf)
        {
            DeleteNode(leaf);
            if (leaf.Father != null && leaf.FatherNode != null)
            {
                if (leaf.FatherNode.Degree <= 4 * Bounds.Fi(leaf.FatherNode.Level))
                {
                    if (leaf.FatherNode.Group.Left != null && (leaf.FatherNode.Group.hasOnlyOneBlock1 || leaf.FatherNode.Group.Left.hasOnlyOneBlock1) && leaf.FatherNode.Group.Left.Block2 == leaf.FatherNode.Group.Block2)
                    {
                        if (leaf.FatherNode.Group.CanBeFused(leaf.FatherNode.Group.Left))
                            leaf.FatherNode.Group.Fuse(leaf.FatherNode.Group.Left);
                        else
                        {
                            leaf.FatherNode.Group.Left.MultiBreak();
                            leaf.FatherNode.Group.Share(leaf.FatherNode.Group.Left); // Ai grija la share sa stergi pointer la block2, si block2.mate daca exista
                        }
                    }
                    else if (leaf.FatherNode.Group.Right != null && (leaf.FatherNode.Group.hasOnlyOneBlock1 || leaf.FatherNode.Group.Right.hasOnlyOneBlock1) && leaf.FatherNode.Group.Right.Block2 == leaf.FatherNode.Group.Block2)
                    {
                        if (leaf.FatherNode.Group.CanBeFused(leaf.FatherNode.Group.Right))
                            leaf.FatherNode.Group.Fuse(leaf.FatherNode.Group.Right);
                        else
                        {
                            leaf.FatherNode.Group.Right.MultiBreak();
                            leaf.FatherNode.Group.Share(leaf.FatherNode.Group.Right);
                        }
                    }
                }
                else if (leaf.FatherNode.Degree <= 8 * Bounds.Fi(leaf.FatherNode.Level))
                {
                    if (leaf.Father.Father.Degree > Bounds.Fi(leaf.FatherNode.Level))
                    {
                        if (leaf.Father.Father.Mate != null && leaf.Father.Father.Mate.Degree >= Bounds.Fi(leaf.FatherNode.Level))
                        {
                            leaf.Father.Father.Mate.Mate = null;
                            leaf.Father.Father.Mate = null;
                        }
                        if (leaf.Father.Father.Mate == null)
                        {
                            leaf.Father.Father.Mate = new Block2(leaf.FatherNode) { Mate = leaf.Father.Father };
                            leaf.FatherNode.Add(leaf.Father.Father, leaf.Father.Father.Mate);
                        }
                        leaf.Father.Father.Transfer(leaf.Father.Father.Mate);
                    }
                }

                if (leaf.FatherNode != null && leaf.FatherNode.Degree != 0)
                    Rebalance(leaf.FatherNode);

                return leaf.Left as Leaf;
            }
            return leaf;
        }

        internal static void AddNode(Node left, Node newNode)
        {
            if (left.Father != null)
            {
                bool wasFullBlock1 = left.Father.IsFull;
                bool wasFullBlock2 = left.Father.Father.IsFull;

                Block1 father = left.Father;
                Block2 grandfather = left.Father.Father;

                father.Add(left, newNode);

                // If this block1 was already full before the insert, then transfer to one node to the mate.
                if (wasFullBlock1)
                {
                    if (father.Mate == null)
                    {
                        father.Mate = new Block1(grandfather)
                        {
                            Mate = father
                        };
                        grandfather.Add(father, father.Mate);
                    }
                    father.TransferToMate();
                }

                // if both become full, break the pair.
                if (father.IsFull && father.Mate != null && father.Mate.IsFull)
                {
                    father.Mate.Mate = null;
                    father.Mate = null;
                }

                // if it is a pending object there is no transfer needed. But if it became full then break it from the pair.
                if (grandfather.Pending && grandfather.IsFull)
                {
                    grandfather.Pending = false;
                    grandfather.Mate = null;
                }

                // if the block2 was already full before the insert, the treansfer one block1 to the mate. 
                if (wasFullBlock2)
                {
                    // if there is no mate, then find one. 
                    if (grandfather.Mate == null)
                    {
                        // if we can pair it with a pending block, we make the pair.
                        if (grandfather.Right != null && ((grandfather.Right.Pending && grandfather.Right.Mate == grandfather) || (grandfather.Right.Mate == null && grandfather.Right.IsFull == false)))
                        {
                            grandfather.Right.Pending = false;
                            grandfather.Mate = grandfather.Right;
                        }
                        else if (grandfather.Left != null && ((grandfather.Left.Pending && grandfather.Left.Mate == grandfather) || (grandfather.Left.Mate == null && grandfather.Left.IsFull == false)))
                        {
                            grandfather.Left.Pending = false;
                            grandfather.Mate = grandfather.Left;
                        }
                        else
                        {
                            grandfather.Mate = new Block2(grandfather.Node)
                            {
                                Mate = grandfather
                            };

                            grandfather.Node.Add(grandfather, grandfather.Mate);
                        }
                    }
                    grandfather.TransferToMate();
                }

                // if both blocks2 of them are full, and the break would not spoil invariant 5, then break the pair;
                if (grandfather.IsFull && grandfather.Mate != null && grandfather.Mate.IsFull && grandfather.IsBreakPossible())
                {
                    Block2 oldMate = grandfather.Mate;
                    if (grandfather.Mate == grandfather.Right)
                    {
                        if (grandfather.Left != null && grandfather.Left.Pending && grandfather.Left.Mate == grandfather)
                        {
                            grandfather.Mate = grandfather.Left;
                            grandfather.Pending = false;
                        }
                        else
                        {
                            grandfather.Mate = null;
                        }

                        if (oldMate.Right != null && oldMate.Right.Pending && oldMate.Right.Mate == oldMate)
                        {
                            oldMate.Mate = oldMate.Right;
                            oldMate.Mate.Pending = false;
                        }
                        else
                        {
                            oldMate.Mate = null;
                        }
                    }
                    else
                    {
                        if (grandfather.Right != null && grandfather.Right.Pending && grandfather.Right.Mate == grandfather)
                        {
                            grandfather.Mate = grandfather.Right;
                            grandfather.Mate.Pending = false;
                        }
                        else
                        {
                            grandfather.Mate = null;
                        }

                        if (oldMate.Left != null && oldMate.Left.Pending && oldMate.Left.Mate == oldMate)
                        {
                            oldMate.Mate = oldMate.Left;
                            oldMate.Mate.Pending = false;
                        }
                        else
                        {
                            oldMate.Mate = null;
                        }
                    }
                }
            }
        }

        internal static void DeleteNode(Node node)
        {
            if (node.Father != null)
            {

                bool wasFatherFull = node.Father.IsFull;
                bool wasGrandfatherFull = node.Father.Father.IsFull;

                Block1 father = node.Father;
                Block2 grandfather = node.Father.Father;

                father.Remove(node);

                if (wasFatherFull && father.IsFull == false)
                {
                    if (father.Mate != null)
                    {
                        father.Mate.TransferToMate();
                    }
                    else if (father.Right != null && father.Right.Mate == null)
                    {
                        father.Mate = father.Right;
                        father.Right.Mate = father;
                        father.Mate.TransferToMate();
                    }
                    else if (father.Left != null && father.Left.Mate == null)
                    {
                        father.Mate = father.Left;
                        father.Left.Mate = father;
                        father.Mate.TransferToMate();
                    }
                    else if (father.Right != null && father.Right.Mate != null)
                    {
                        Node sharedNode = father.Right.Nodes.First();
                        bool wasFullRight = father.Right.IsFull;
                        father.Right.Remove(sharedNode); 
                        if (wasFullRight)
                        {
                            father.Right.Mate.TransferToMate();
                        }
                        father.Add(father.Nodes.Count, sharedNode);
                    }
                    else if (father.Left != null && father.Left.Mate != null)
                    {
                        Node sharedNode = father.Left.Nodes.First();
                        bool wasFullLeft = father.Left.IsFull;
                        father.Left.Remove(sharedNode);
                        if (wasFullLeft)
                        {
                            father.Left.Mate.TransferToMate();
                        }
                        father.Add(0, sharedNode);
                    }
                }

                if (wasGrandfatherFull && grandfather.IsFull == false)
                {
                    if (grandfather.Pending)
                    {
                        grandfather.Mate = null;
                        grandfather.Pending = false;
                    }

                    if (grandfather.Mate != null && grandfather.Mate.Blocks1.Count == 0)
                    {
                        grandfather.Mate = null;
                    }

                    if (grandfather.Mate != null && grandfather.Mate.Mate != grandfather)
                    {
                        grandfather.Mate = null;
                    }

                    if (grandfather.Mate != null)
                    {
                        grandfather.Mate.TransferToMate();
                    }
                    //else if (grandfather.Right != null && grandfather.Right.Pending == false && grandfather.Right.Mate == null)
                    //{
                    //    grandfather.Right.Mate = grandfather;
                    //    grandfather.Mate = grandfather.Right;
                    //    grandfather.Mate.TransferToMate();
                    //}
                    //else if (grandfather.Left != null && grandfather.Left.Pending == false && grandfather.Left.Mate == null)
                    //{
                    //    grandfather.Left.Mate = grandfather;
                    //    grandfather.Mate = grandfather.Left;
                    //    grandfather.Mate.TransferToMate();
                    //}
                    else if (grandfather.Right != null && (grandfather.Right.Pending || grandfather.Right.Mate == null))
                    {
                        grandfather.Right.Pending = false;
                        grandfather.Right.Mate = grandfather;
                        grandfather.Mate = grandfather.Right;
                        grandfather.Mate.TransferToMate();
                    }
                    else if (grandfather.Left != null && (grandfather.Left.Pending || grandfather.Left.Mate == null))
                    {
                        grandfather.Left.Pending = false;
                        grandfather.Left.Mate = grandfather;
                        grandfather.Mate = grandfather.Left;
                        grandfather.Mate.TransferToMate();
                    }
                    else if (grandfather.Right != null)
                    {
                        grandfather.Mate = grandfather.Right;
                        grandfather.Pending = true;
                    }
                    else if (grandfather.Left != null)
                    {
                        grandfather.Mate = grandfather.Left;
                        grandfather.Pending = true;
                    }
                }

                node.Group.Nodes.Remove(node);

                if (node is Leaf == false && node.FatherNode != null && node.FatherNode.Right == null && node.FatherNode.Left == null && node.FatherNode.Degree == 1)
                {
                    Node? newRoot = node.Right ?? node.Left;
                    if (newRoot != null)
                        newRoot.Father = null;
                    node.FatherNode.Component.Valid = false;
                }
            }
        }

        internal static void Rebalance(Node father)
        {
            Node r = father.Component.Root;

            r.Group.MultiBreak();

            if (r.Group.hasOnlyOneBlock1)
            {
                if (r.Group.Right != null && r.Group.Block2 == r.Group.Right.Block2)
                {
                    if (r.Group.CanBeFused(r.Group.Right))
                    {
                        r.Group.Fuse(r.Group.Right);
                    }
                    else
                    {
                        r.Group.Right.MultiBreak();
                        r.Group.Share(r.Group.Right);
                    }
                }
                else if (r.Group.Left != null && r.Group.Block2 == r.Group.Left.Block2)
                {
                    if (r.Group.CanBeFused(r.Group.Left))
                        r.Group.Fuse(r.Group.Left);
                    else if (r.Group.hasOnlyOneBlock1 || r.Group.Left.hasOnlyOneBlock1)
                    {
                        r.Group.Left.MultiBreak();
                        r.Group.Share(r.Group.Left);
                    }
                }
            }

            if (r.FatherNode != null && r.Group.Block2 != null)
            {
                if (r.FatherNode.Group.Degree <= 4 * Bounds.Fi(r.FatherNode.Level))
                {
                    if (r.FatherNode.Group.Right != null && r.FatherNode.Group.CanBeFused(r.FatherNode.Group.Right))
                    {
                        r.FatherNode.Group.Fuse(r.FatherNode.Group.Right);
                        if (r.FatherNode.Group.Left != null && r.FatherNode.Group.CanBeFused(r.FatherNode.Group.Left))
                        {
                            r.FatherNode.Group.Fuse(r.FatherNode.Group.Left);
                            if (r.FatherNode.Group.Right != null && r.FatherNode.Group.CanBeFused(r.FatherNode.Group.Right))
                            {
                                r.FatherNode.Group.Fuse(r.FatherNode.Group.Right);
                                if (r.FatherNode.Group.Left != null && r.FatherNode.Group.CanBeFused(r.FatherNode.Group.Left))
                                {
                                    r.FatherNode.Group.Fuse(r.FatherNode.Group.Left);
                                }
                            }
                            else if (r.FatherNode.Group.Left != null && r.FatherNode.Group.CanBeFused(r.FatherNode.Group.Left))
                            {
                                r.FatherNode.Group.Fuse(r.FatherNode.Group.Left);
                            }
                        }
                        else if (r.FatherNode.Group.Right != null && r.FatherNode.Group.CanBeFused(r.FatherNode.Group.Right))
                        {
                            r.FatherNode.Group.Fuse(r.FatherNode.Group.Right);
                        }
                    }
                    else if (r.FatherNode.Group.Left != null && r.FatherNode.Group.CanBeFused(r.FatherNode.Group.Left))
                    {
                        r.FatherNode.Group.Fuse(r.FatherNode.Group.Left);
                        if (r.FatherNode.Group.Left != null && r.FatherNode.Group.CanBeFused(r.FatherNode.Group.Left))
                        {
                            r.FatherNode.Group.Fuse(r.FatherNode.Group.Left);
                        }
                    }

                    if (r.FatherNode.Father != null && r.FatherNode.Father.Mate == null)
                    {
                        if (r.FatherNode.Father.Right != null && r.FatherNode.Father.Right.Mate == null && r.FatherNode.Father.IsFull != r.FatherNode.Father.Right.IsFull)
                        {
                            r.FatherNode.Father.Mate = r.FatherNode.Father.Right;
                            r.FatherNode.Father.Right.Mate = r.FatherNode.Father;
                        }
                        else if (r.FatherNode.Father.Left != null && r.FatherNode.Father.Left.Mate == null && r.FatherNode.Father.IsFull != r.FatherNode.Father.Left.IsFull)
                        {
                            r.FatherNode.Father.Mate = r.FatherNode.Father.Left;
                            r.FatherNode.Father.Left.Mate = r.FatherNode.Father;
                        }
                    }
                }
                else if (r.FatherNode.Group.Degree >= Bounds.BiP(r.FatherNode.Level))
                {
                    if (r.FatherNode.ContainsAtLeastTwoBlock2Pairs)
                    {
                        Node node = r.FatherNode;
                        Node newNode = node.Split();
                        AddNode(node, newNode);
                    }

                    if (r.FatherNode.Father != null && r.FatherNode.Father.Mate == null)
                    {
                        if (r.FatherNode.Father.Right != null && r.FatherNode.Father.Right.Mate == null && r.FatherNode.Father.IsFull != r.FatherNode.Father.Right.IsFull)
                        {
                            r.FatherNode.Father.Mate = r.FatherNode.Father.Right;
                            r.FatherNode.Father.Right.Mate = r.FatherNode.Father;
                        }
                        else if (r.FatherNode.Father.Left != null && r.FatherNode.Father.Left.Mate == null && r.FatherNode.Father.IsFull != r.FatherNode.Father.Left.IsFull)
                        {
                            r.FatherNode.Father.Mate = r.FatherNode.Father.Left;
                            r.FatherNode.Father.Left.Mate = r.FatherNode.Father;
                        }
                    }
                }
                else
                {
                    if (r.FatherNode.Group.Degree > 8 * Bounds.Fi(r.FatherNode.Level))
                    {
                        Block2? neighbour = r.Group.Block2.Mate ?? r.Group.Block2.Right ?? r.Group.Block2.Left;
                        if (neighbour != null)
                        {
                            if (r.Group.Block2.Degree > neighbour.Degree)
                                neighbour.Transfer(r.Group.Block2);
                            else
                                r.Group.Block2.Transfer(neighbour);
                        }
                    }
                    else
                    {
                        if (r.Group.Block2.Degree > Bounds.Fi(r.FatherNode.Level))
                        {
                            if (r.Group.Block2.Mate != null && r.Group.Block2.Mate.Degree >= Bounds.Fi(r.FatherNode.Level))
                            {
                                r.Group.Block2.Mate.Mate = null;
                                r.Group.Block2.Mate = null;
                            }
                            if (r.Group.Block2.Mate == null)
                            {
                                r.Group.Block2.Mate = new Block2(r.FatherNode) { Mate = r.Group.Block2 };
                                r.FatherNode.Add(r.Group.Block2, r.Group.Block2.Mate);
                            }

                            r.Group.Block2.Transfer(r.Group.Block2.Mate);
                        }
                    }
                }
            }
        }
    }
}