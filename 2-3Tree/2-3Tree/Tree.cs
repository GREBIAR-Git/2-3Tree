using System.Drawing;
using System.Windows.Forms;

namespace _2_3Tree
{
    public class Tree
    {
        Branch root;

        public Tree()
        {
            Root = null;
        }


        public Tree(Branch root)
        {
            Root = root;
        }

        public Branch Root
        {
            get => root;
            private set => root = value;
        }

        public new string ToString => ToStringType(root);


        public void Clear()
        {
            root = null;
        }

        public bool Insert()
        {
            return Insert(RandomCode.Random());
        }

        public bool Insert(string code)
        {
            Key newKey = new Key(code);
            if (Root == null)
            {
                Root = new Branch(newKey);
            }
            else
            {
                Branch currentBranch = SearchInsertionPoint(Root, newKey);
                if (currentBranch == null)
                {
                    return false;
                }

                if (currentBranch.NeighborEmpty())
                {
                    currentBranch.SetNeighbor(newKey);
                }
                else
                {
                    currentBranch.SetCenter(newKey);
                    currentBranch.SplitBranch(ref root);
                }
            }

            return true;
        }

        Branch SearchInsertionPoint(Branch branch, Key key)
        {
            if (branch.IsLeaf())
            {
                if (key == branch.LeftKey || key == branch.RightKey)
                {
                    return null;
                }

                return branch;
            }

            if (branch.NeighborEmpty())
            {
                if (key < branch.LeftKey)
                {
                    return SearchInsertionPoint(branch.ChildFirst, key);
                }

                if (key == branch.LeftKey)
                {
                    return null;
                }

                return SearchInsertionPoint(branch.ChildSecond, key);
            }

            if (key < branch.LeftKey)
            {
                return SearchInsertionPoint(branch.ChildFirst, key);
            }

            if (key == branch.LeftKey)
            {
                return null;
            }

            if (key > branch.LeftKey && key < branch.RightKey)
            {
                return SearchInsertionPoint(branch.ChildSecond, key);
            }

            if (key == branch.RightKey)
            {
                return null;
            }

            return SearchInsertionPoint(branch.ChildThird, key);
        }

        public bool Remove(string code)
        {
            Branch removeBranch = Search(code);
            if (removeBranch != null)
            {
                Equivalent(ref removeBranch, ref code);
                FixingTree(removeBranch, code);
                return true;
            }

            return false;
        }

        void Equivalent(ref Branch removeBranch, ref string code)
        {
            if (!removeBranch.IsLeaf())
            {
                Branch min;
                if (removeBranch.LeftKey.ToString == code)
                {
                    min = SearchMin(removeBranch.ChildSecond);
                    removeBranch.LeftKey = min.LeftKey;
                }
                else
                {
                    min = SearchMin(removeBranch.ChildThird);
                    removeBranch.RightKey = min.LeftKey;
                }

                removeBranch = min;
                code = min.LeftKey.ToString;
            }
        }

        void FixingTree(Branch currentBranch, string code)
        {
            if (!currentBranch.NeighborEmpty())
            {
                if (currentBranch.LeftKey.ToString == code)
                {
                    currentBranch.LeftKey = currentBranch.RightKey;
                }

                currentBranch.RightKey = null;
            }
            else if (currentBranch == Root)
            {
                Root = null;
            }
            else
            {
                Balancing(currentBranch);
            }
        }

        void Balancing(Branch currentBranch)
        {
            if (currentBranch != null)
            {
                int numChild = currentBranch.WhichChildren();
                if (numChild == 0)
                {
                    Merge(currentBranch);
                    return;
                }

                if (Redistribute(currentBranch, numChild))
                {
                    return;
                }

                Merge(numChild, currentBranch);
                Balancing(currentBranch.Parent);
            }
        }

        void Merge(int numChild, Branch currentBranch)
        {
            if (numChild == 1)
            {
                if (currentBranch.LeftKey == null)
                {
                    currentBranch.LeftKey = currentBranch.Parent.LeftKey;
                    if (currentBranch.Parent.ChildSecond != null)
                    {
                        currentBranch.RightKey = currentBranch.Parent.ChildSecond.LeftKey;
                        if (currentBranch.Parent.ChildSecond.ChildFirst != null)
                        {
                            currentBranch.ChildSecond = currentBranch.Parent.ChildSecond.ChildFirst;
                            currentBranch.ChildSecond.Parent = currentBranch;
                            if (currentBranch.Parent.ChildSecond.ChildSecond != null)
                            {
                                currentBranch.ChildThird = currentBranch.Parent.ChildSecond.ChildSecond;
                                currentBranch.ChildThird.Parent = currentBranch;
                            }
                        }

                        currentBranch.Parent.ChildSecond = null;
                    }

                    currentBranch.Parent.LeftKey = null;
                }
                else
                {
                    currentBranch.LeftKey = currentBranch.Parent.LeftKey;
                    currentBranch.RightKey = currentBranch.Parent.ChildSecond.LeftKey;
                    currentBranch.Parent.ChildSecond = null;
                    currentBranch.Parent.LeftKey = null;
                }
            }
            else if (numChild == 2)
            {
                if (currentBranch.LeftKey == null)
                {
                    currentBranch.Parent.ChildFirst.RightKey = currentBranch.Parent.LeftKey;
                    if (currentBranch.ChildFirst != null)
                    {
                        currentBranch.Parent.ChildFirst.ChildThird = currentBranch.ChildFirst;
                        currentBranch.Parent.ChildFirst.ChildThird.Parent = currentBranch.Parent.ChildFirst;
                    }

                    currentBranch.Parent.LeftKey = null;
                    currentBranch.Parent.ChildSecond = null;
                }
                else
                {
                    currentBranch.Parent.ChildFirst.RightKey = currentBranch.Parent.LeftKey;
                    currentBranch.Parent.LeftKey = null;
                    currentBranch.Parent.ChildSecond = null;
                }
            }
        }

        void Merge(Branch currentBranch)
        {
            Root = currentBranch.ChildFirst;
            Root.Parent = null;
        }


        bool Redistribute(Branch currentBranch, int numChild)
        {
            Branch parent = currentBranch.Parent;
            if (!parent.ChildFirst.NeighborEmpty() || !parent.ChildSecond.NeighborEmpty() || !parent.NeighborEmpty())
            {
                Key key = currentBranch.LeftKey;
                if (numChild == 1)
                {
                    if (!currentBranch.Parent.ChildSecond.NeighborEmpty())
                    {
                        currentBranch.LeftKey = currentBranch.Parent.LeftKey;
                        currentBranch.Parent.LeftKey = currentBranch.Parent.ChildSecond.LeftKey;
                        currentBranch.Parent.ChildSecond.LeftKey = currentBranch.Parent.ChildSecond.RightKey;
                        currentBranch.Parent.ChildSecond.RightKey = null;
                        if (key == null)
                        {
                            currentBranch.ChildSecond = currentBranch.Parent.ChildSecond.ChildFirst;
                            currentBranch.ChildSecond.Parent = currentBranch;
                            currentBranch.Parent.ChildSecond.ChildFirst = currentBranch.Parent.ChildSecond.ChildSecond;
                            currentBranch.Parent.ChildSecond.ChildSecond = currentBranch.Parent.ChildSecond.ChildThird;
                            currentBranch.Parent.ChildSecond.ChildThird = null;
                        }
                    }
                    else if (!currentBranch.Parent.NeighborEmpty())
                    {
                        if (currentBranch.Parent.ChildThird.NeighborEmpty())
                        {
                            currentBranch.LeftKey = currentBranch.Parent.LeftKey;
                            currentBranch.RightKey = currentBranch.Parent.ChildSecond.LeftKey;
                            currentBranch.Parent.LeftKey = currentBranch.Parent.RightKey;
                            currentBranch.Parent.RightKey = null;
                            if (key == null)
                            {
                                currentBranch.ChildSecond = currentBranch.Parent.ChildSecond.ChildFirst;
                                currentBranch.ChildSecond.Parent = currentBranch;
                                currentBranch.ChildThird = currentBranch.Parent.ChildSecond.ChildSecond;
                                currentBranch.ChildThird.Parent = currentBranch;
                            }

                            currentBranch.Parent.ChildSecond = currentBranch.Parent.ChildThird;
                            currentBranch.Parent.ChildThird = null;
                        }
                        else
                        {
                            currentBranch.LeftKey = currentBranch.Parent.LeftKey;
                            currentBranch.Parent.LeftKey = currentBranch.Parent.RightKey;
                            currentBranch.Parent.RightKey = null;
                            currentBranch.RightKey = currentBranch.Parent.ChildSecond.LeftKey;
                            if (key == null)
                            {
                                currentBranch.ChildSecond = currentBranch.Parent.ChildSecond.ChildFirst;
                                currentBranch.ChildSecond.Parent = currentBranch;
                                currentBranch.ChildThird = currentBranch.Parent.ChildSecond.ChildSecond;
                                currentBranch.ChildThird.Parent = currentBranch;
                            }

                            currentBranch.Parent.ChildSecond = currentBranch.Parent.ChildThird;
                            currentBranch.Parent.ChildThird = null;
                        }
                    }
                }
                else if (numChild == 2)
                {
                    if (!currentBranch.Parent.ChildFirst.NeighborEmpty())
                    {
                        Branch first = currentBranch.Parent.ChildFirst;
                        currentBranch.LeftKey = currentBranch.Parent.LeftKey;
                        currentBranch.Parent.LeftKey = currentBranch.Parent.ChildFirst.RightKey;
                        currentBranch.Parent.ChildFirst.RightKey = null;
                        if (key == null)
                        {
                            currentBranch.ChildSecond = currentBranch.ChildFirst;
                            currentBranch.ChildFirst = first.ChildThird;
                            currentBranch.ChildFirst.Parent = currentBranch;
                            first.ChildThird = null;
                        }
                    }
                    else if (!currentBranch.Parent.NeighborEmpty())
                    {
                        if (currentBranch.Parent.ChildThird.NeighborEmpty())
                        {
                            Branch first = currentBranch.Parent.ChildFirst;
                            first.RightKey = currentBranch.Parent.LeftKey;
                            currentBranch.Parent.LeftKey = currentBranch.Parent.RightKey;
                            currentBranch.Parent.RightKey = null;
                            if (key == null)
                            {
                                first.ChildThird = currentBranch.ChildFirst;
                                first.ChildThird.Parent = first;
                            }

                            currentBranch.Parent.ChildSecond = currentBranch.Parent.ChildThird;
                            currentBranch.Parent.ChildThird = null;
                        }
                        else
                        {
                            Branch third = currentBranch.Parent.ChildThird;
                            currentBranch.LeftKey = currentBranch.Parent.RightKey;
                            currentBranch.Parent.RightKey = currentBranch.Parent.ChildThird.LeftKey;
                            currentBranch.Parent.ChildThird.LeftKey = currentBranch.Parent.ChildThird.RightKey;
                            currentBranch.Parent.ChildThird.RightKey = null;
                            if (key == null)
                            {
                                currentBranch.ChildSecond = third.ChildFirst;
                                currentBranch.ChildSecond.Parent = currentBranch;
                                third.ChildFirst = third.ChildSecond;
                                third.ChildSecond = third.ChildThird;
                                third.ChildThird = null;
                            }
                        }
                    }
                }
                else if (numChild == 3)
                {
                    if (!currentBranch.Parent.ChildSecond.NeighborEmpty())
                    {
                        currentBranch.LeftKey = currentBranch.Parent.RightKey;
                        currentBranch.Parent.RightKey = currentBranch.Parent.ChildSecond.RightKey;
                        currentBranch.Parent.ChildSecond.RightKey = null;
                        if (key == null)
                        {
                            currentBranch.ChildSecond = currentBranch.ChildFirst;
                            currentBranch.ChildFirst = currentBranch.Parent.ChildSecond.ChildThird;
                            currentBranch.ChildFirst.Parent = currentBranch;
                            currentBranch.Parent.ChildSecond.ChildThird = null;
                        }
                    }
                    else
                    {
                        currentBranch.Parent.ChildSecond.RightKey = currentBranch.Parent.RightKey;
                        currentBranch.Parent.RightKey = null;
                        if (key == null)
                        {
                            currentBranch.Parent.ChildSecond.ChildThird = currentBranch.ChildFirst;
                            currentBranch.Parent.ChildSecond.ChildThird.Parent = currentBranch.Parent.ChildSecond;
                        }

                        currentBranch.Parent.ChildThird = null;
                    }
                }

                return true;
            }

            return false;
        }

        Branch SearchMin(Branch currentBranch)
        {
            if (currentBranch == null)
            {
                return null;
            }

            if (currentBranch.ChildFirst == null)
            {
                return currentBranch;
            }

            return SearchMin(currentBranch.ChildFirst);
        }

        public Branch Search(string strCode)
        {
            return Search(new Key(strCode), Root);
        }

        public Branch Search(Key key, Branch currentBranch)
        {
            if (currentBranch != null)
            {
                if (currentBranch.LeftKey == key ||
                    (currentBranch.RightKey != null && currentBranch.RightKey == key))
                {
                    return currentBranch;
                }

                if (currentBranch.NeighborEmpty())
                {
                    if (key < currentBranch.LeftKey)
                    {
                        return Search(key, currentBranch.ChildFirst);
                    }

                    return Search(key, currentBranch.ChildSecond);
                }

                if (key < currentBranch.LeftKey)
                {
                    return Search(key, currentBranch.ChildFirst);
                }

                if (key >= currentBranch.LeftKey && key < currentBranch.RightKey)
                {
                    return Search(key, currentBranch.ChildSecond);
                }

                return Search(key, currentBranch.ChildThird);
            }

            return null;
        }

        public Branch Search(Key key, Branch currentBranch, ref int countBranch, ref int s)
        {
            if (currentBranch != null)
            {
                s++;
                countBranch++;
                if (currentBranch.LeftKey == key ||
                    (currentBranch.RightKey != null && currentBranch.RightKey == key))
                {
                    return currentBranch;
                }

                if (currentBranch.NeighborEmpty())
                {
                    s++;
                    if (key < currentBranch.LeftKey)
                    {
                        s++;
                        return Search(key, currentBranch.ChildFirst, ref countBranch, ref s);
                    }

                    s++;
                    return Search(key, currentBranch.ChildSecond, ref countBranch, ref s);
                }

                s++;
                if (key < currentBranch.LeftKey)
                {
                    s++;
                    return Search(key, currentBranch.ChildFirst, ref countBranch, ref s);
                }

                if (key >= currentBranch.LeftKey && key < currentBranch.RightKey)
                {
                    s += 3;
                    return Search(key, currentBranch.ChildSecond, ref countBranch, ref s);
                }

                s += 3;
                return Search(key, currentBranch.ChildThird, ref countBranch, ref s);
            }

            return null;
        }

        public void ShowTreeWithFoundBranch(TreeNodeCollection node, Branch foundBranch)
        {
            ShowBranch(node, Root, foundBranch);
        }

        public void ShowTree(TreeNodeCollection node)
        {
            ShowBranch(node, Root);
        }

        void ShowBranch(TreeNodeCollection node, Branch currentBranch)
        {
            AddNodeToTreeView(currentBranch, out TreeNode nodeInside, node);
            TransitionToChild(currentBranch.ChildFirst, nodeInside);
            TransitionToChild(currentBranch.ChildSecond, nodeInside);
            TransitionToChild(currentBranch.ChildThird, nodeInside);
        }

        void ShowBranch(TreeNodeCollection node, Branch currentBranch, Branch foundBranch)
        {
            AddNodeToTreeView(currentBranch, out TreeNode nodeInside, node);
            if (foundBranch == currentBranch)
            {
                nodeInside.BackColor = Color.Red;
            }

            TransitionToChild(currentBranch.ChildFirst, nodeInside, foundBranch);
            TransitionToChild(currentBranch.ChildSecond, nodeInside, foundBranch);
            TransitionToChild(currentBranch.ChildThird, nodeInside, foundBranch);
        }

        void AddNodeToTreeView(Branch currentBranch, out TreeNode nodeInside, TreeNodeCollection node)
        {
            if (currentBranch.Parent != null)
            {
                if (currentBranch.Parent.ChildFirst == currentBranch)
                {
                    nodeInside = node.Add(BuildStrCode("L", currentBranch));
                }
                else if ((currentBranch.Parent.ChildSecond == currentBranch &&
                          currentBranch.Parent.ChildThird == null) || currentBranch.Parent.ChildThird == currentBranch)
                {
                    nodeInside = node.Add(BuildStrCode("R", currentBranch));
                }
                else
                {
                    nodeInside = node.Add(BuildStrCode("M", currentBranch));
                }
            }
            else
            {
                nodeInside = node.Add(BuildStrCode("", currentBranch));
            }
        }

        string BuildStrCode(string type, Branch branch)
        {
            if (branch.RightKey == null)
            {
                return type + "<" + branch.LeftKey.ToString + ">";
            }

            return type + "<" + branch.LeftKey.ToString + "><" + branch.RightKey.ToString + ">";
        }

        string ToStringType(Branch branch)
        {
            if (branch != null)
            {
                if (!branch.IsLeaf())
                {
                    if (branch.RightKey != null)
                    {
                        return branch.LeftKey.ToString + ":" + branch.RightKey.ToString + "(" +
                               ToStringType(branch.ChildFirst) + "|" +
                               ToStringType(branch.ChildSecond) + "|" + ToStringType(branch.ChildThird) + ")";
                    }

                    return branch.LeftKey.ToString + "(" + ToStringType(branch.ChildFirst) + "|" +
                           ToStringType(branch.ChildSecond) + ")";
                }

                if (branch.RightKey != null)
                {
                    return "(" + branch.LeftKey.ToString + ":" + branch.RightKey.ToString + ")";
                }

                return branch.LeftKey.ToString;
            }

            return string.Empty;
        }

        void TransitionToChild(Branch childBranch, TreeNode nodeInside)
        {
            if (childBranch != null)
            {
                ShowBranch(nodeInside.Nodes, childBranch);
            }
        }

        void TransitionToChild(Branch childBranch, TreeNode nodeInside, Branch foundBranch)
        {
            if (childBranch != null)
            {
                ShowBranch(nodeInside.Nodes, childBranch, foundBranch);
            }
        }
    }
}