using System.Windows.Forms;

namespace _2_3Tree
{
    class Tree
    {
        Branch root; 
        public Branch Root { get { return root; } private set { root = value; } }

        public bool Insert()
        {
            return Insert(RandomCode.Random());
        }

        public bool Insert(string code)
        {
            Code newCode = new Code(code);
            if (Root == null)
            {
                Root = new Branch(newCode);
            }
            else
            {
                Branch currentBranch = SearchInsertionPoint(Root, newCode);
                if (currentBranch == null)
                {
                    return false;
                }
                else if (currentBranch.NeighborEmpty())
                {
                    currentBranch.SetNeighbor(newCode);
                }
                else
                {
                    currentBranch.SetCenter(newCode);
                    currentBranch.SplitBranch(ref root);
                }
            }
            return true;
        }

        Branch SearchInsertionPoint(Branch branch, Code code)
        {
            if (branch.IsLeaf())
            {
                if (code == branch.LeftCode || code == branch.RightCode)
                {
                    return null;
                }
                return branch;
            }
            else if (branch.NeighborEmpty())
            {
                if (code < branch.LeftCode)
                {
                    return SearchInsertionPoint(branch.ChildFirst, code);
                }
                else if (code == branch.LeftCode)
                {
                    return null;
                }
                else
                {
                    return SearchInsertionPoint(branch.ChildSecond, code);
                }
            }
            else
            {
                if (code < branch.LeftCode)
                {
                    return SearchInsertionPoint(branch.ChildFirst, code);
                }
                else if (code == branch.LeftCode)
                {
                    return null;
                }
                else if (code > branch.LeftCode && code < branch.RightCode)
                {
                    return SearchInsertionPoint(branch.ChildSecond, code);
                }
                else if (code == branch.RightCode)
                {
                    return null;
                }
                else
                {
                    return SearchInsertionPoint(branch.ChildThird, code);
                }
            }
        }
        public bool Remove(string code)
        {
            Branch removeBranch = Search(code);
            if (removeBranch != null)
            {
                PreparingForDeletion(ref removeBranch, ref code);
                FixingTree(removeBranch, code);
                return true;
            }
            else
            {
                return false;
            }
        }

        void PreparingForDeletion(ref Branch removeBranch, ref string code)
        {
            if (!removeBranch.IsLeaf())
            {
                Branch min = null;
                if (removeBranch.LeftCode.str == code)
                {
                    min = SearchMin(removeBranch.ChildSecond);
                    removeBranch.LeftCode = min.LeftCode;
                }
                else
                {
                    min = SearchMin(removeBranch.ChildThird);
                    removeBranch.RightCode = min.LeftCode;
                }
                removeBranch = min;
                code = min.LeftCode.str;
            }
        }

        public void FixingTree(Branch currentBranch, string code)
        {
            if (!currentBranch.NeighborEmpty())
            {
                if (currentBranch.LeftCode.str == code)
                {
                    currentBranch.LeftCode = currentBranch.RightCode;
                }
                currentBranch.RightCode = null;
            }
            else if (currentBranch == Root)
            {
                Root = null;
            }
            else
            {
                Merge(currentBranch);
            }
        }

        public void Merge(Branch currentBranch)
        {
            if (currentBranch != null)
            {
                Branch parent = currentBranch.Parent;
                int numChild = currentBranch.WhichChildren();
                if (numChild == 0)
                {
                    Root = currentBranch.ChildFirst;
                    Root.Parent = null;
                    return;
                }
                else if (numChild == 1)
                {
                    if (!parent.ChildFirst.NeighborEmpty() || !parent.ChildSecond.NeighborEmpty() || !parent.NeighborEmpty())
                    {
                        Redistribute(currentBranch, numChild);
                        return;
                    }
                    if (currentBranch.LeftCode == null)
                    {
                        currentBranch.LeftCode = currentBranch.Parent.LeftCode;
                        if (currentBranch.Parent.ChildSecond != null)
                        {
                            currentBranch.RightCode = currentBranch.Parent.ChildSecond.LeftCode;
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
                        currentBranch.Parent.LeftCode = null;
                    }
                    else
                    {
                        currentBranch.LeftCode = currentBranch.Parent.LeftCode;
                        currentBranch.RightCode = currentBranch.Parent.ChildSecond.LeftCode;
                        currentBranch.Parent.ChildSecond = null;
                        currentBranch.Parent.LeftCode = null;
                    }
                }
                else if (numChild == 2)
                {
                    if (!parent.ChildFirst.NeighborEmpty() || !parent.ChildSecond.NeighborEmpty() || !parent.NeighborEmpty())
                    {
                        Redistribute(currentBranch, numChild);
                        return;
                    }
                    if (currentBranch.LeftCode == null)
                    {
                        currentBranch.Parent.ChildFirst.RightCode = currentBranch.Parent.LeftCode;
                        if (currentBranch.ChildFirst != null)
                        {
                            currentBranch.Parent.ChildFirst.ChildThird = currentBranch.ChildFirst;
                            currentBranch.Parent.ChildFirst.ChildThird.Parent = currentBranch.Parent.ChildFirst;
                        }
                        currentBranch.Parent.LeftCode = null;
                        currentBranch.Parent.ChildSecond = null;
                    }
                    else
                    {
                        currentBranch.Parent.ChildFirst.RightCode = currentBranch.Parent.LeftCode;
                        currentBranch.Parent.LeftCode = null;
                        currentBranch.Parent.ChildSecond = null;
                    }
                }
                else if (numChild == 3)
                {
                    if (!parent.ChildFirst.NeighborEmpty() || !parent.ChildSecond.NeighborEmpty() || !parent.NeighborEmpty())
                    {
                        Redistribute(currentBranch, numChild);
                        return;
                    }
                }
                Merge(parent);
            }
        }

        public void Redistribute(Branch currentBranch, int numChild)
        {
            Code code = currentBranch.LeftCode;
            if (numChild == 1)
            {
                if (!currentBranch.Parent.ChildSecond.NeighborEmpty())
                {
                    currentBranch.LeftCode = currentBranch.Parent.LeftCode;
                    currentBranch.Parent.LeftCode = currentBranch.Parent.ChildSecond.LeftCode;
                    currentBranch.Parent.ChildSecond.LeftCode = currentBranch.Parent.ChildSecond.RightCode;
                    currentBranch.Parent.ChildSecond.RightCode = null;
                    if (code == null)
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
                        currentBranch.LeftCode = currentBranch.Parent.LeftCode;
                        currentBranch.RightCode = currentBranch.Parent.ChildSecond.LeftCode;
                        currentBranch.Parent.LeftCode = currentBranch.Parent.RightCode;
                        currentBranch.Parent.RightCode = null;
                        if (code == null)
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
                        currentBranch.LeftCode = currentBranch.Parent.LeftCode;
                        currentBranch.Parent.LeftCode = currentBranch.Parent.RightCode;
                        currentBranch.Parent.RightCode = null;
                        currentBranch.RightCode = currentBranch.Parent.ChildSecond.LeftCode;
                        if (code == null)
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
                    currentBranch.LeftCode = currentBranch.Parent.LeftCode;
                    currentBranch.Parent.LeftCode = currentBranch.Parent.ChildFirst.RightCode;
                    currentBranch.Parent.ChildFirst.RightCode = null;
                    if (code == null)
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
                        first.RightCode = currentBranch.Parent.LeftCode;
                        currentBranch.Parent.LeftCode = currentBranch.Parent.RightCode;
                        currentBranch.Parent.RightCode = null;
                        if (code == null)
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
                        currentBranch.LeftCode = currentBranch.Parent.RightCode;
                        currentBranch.Parent.RightCode = currentBranch.Parent.ChildThird.LeftCode;
                        currentBranch.Parent.ChildThird.LeftCode = currentBranch.Parent.ChildThird.RightCode;
                        currentBranch.Parent.ChildThird.RightCode = null;
                        if (code == null)
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
                    currentBranch.LeftCode = currentBranch.Parent.RightCode;
                    currentBranch.Parent.RightCode = currentBranch.Parent.ChildSecond.RightCode;
                    currentBranch.Parent.ChildSecond.RightCode = null;
                    if (code == null)
                    {
                        currentBranch.ChildSecond = currentBranch.ChildFirst;
                        currentBranch.ChildFirst = currentBranch.Parent.ChildSecond.ChildThird;
                        currentBranch.ChildFirst.Parent = currentBranch;
                        currentBranch.Parent.ChildSecond.ChildThird = null;
                    }
                }
                else
                {
                    currentBranch.Parent.ChildSecond.RightCode = currentBranch.Parent.RightCode;
                    currentBranch.Parent.RightCode = null;
                    if (code == null)
                    {
                        currentBranch.Parent.ChildSecond.ChildThird = currentBranch.ChildFirst;
                        currentBranch.Parent.ChildSecond.ChildThird.Parent = currentBranch.Parent.ChildSecond;
                    }
                    currentBranch.Parent.ChildThird = null;
                }
            }
        }

        public Branch SearchMin(Branch currentBranch)
        {
            if (currentBranch == null)
            {
                return null;
            }
            else if (currentBranch.ChildFirst == null)
            {
                return currentBranch;
            }
            else
            {
                return SearchMin(currentBranch.ChildFirst);
            }
        }
        public Branch Search(string strCode)
        {
            return Search(new Code(strCode), Root);
        }
        public Branch Search(Code code, Branch currentBranch)
        {
            if (currentBranch != null)
            {
                if (currentBranch.LeftCode == code || (currentBranch.RightCode != null && currentBranch.RightCode == code))
                {
                    return currentBranch;
                }
                else if (currentBranch.NeighborEmpty())
                {
                    if (code < currentBranch.LeftCode)
                    {
                        return Search(code, currentBranch.ChildFirst);
                    }
                    else
                    {
                        return Search(code, currentBranch.ChildSecond);
                    }
                }
                else
                {
                    if (code < currentBranch.LeftCode)
                    {
                        return Search(code, currentBranch.ChildFirst);
                    }
                    else if (code >= currentBranch.LeftCode && code < currentBranch.RightCode)
                    {
                        return Search(code, currentBranch.ChildSecond);
                    }
                    else
                    {
                        return Search(code, currentBranch.ChildThird);
                    }
                }
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
                nodeInside.BackColor = System.Drawing.Color.Red;
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
                else if (currentBranch.Parent.ChildSecond == currentBranch && currentBranch.Parent.ChildThird == null || currentBranch.Parent.ChildThird == currentBranch)
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
            if(branch.RightCode==null)
            {
                return type + "<" + branch.LeftCode.str + ">";
            }
            else
            {
                return type + "<" + branch.LeftCode.str + "><" + branch.RightCode.str + ">";
            }
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

        public Tree()
        {
            Root = null;
        }
        public Tree(Branch Root)
        {
            this.Root = Root;
        }
    }
}
