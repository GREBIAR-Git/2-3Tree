using System.Windows.Forms;

namespace _2_3Tree
{
    class Tree
    {
        public Branch root { get; set; }
        public void Insert(string code)
        {
            Code newCode = new Code(code);
            Branch currentBranch = SearchInsertionPoint(root, newCode);
            if (currentBranch == null)
            {
                root = new Branch(code);
            }
            else if (currentBranch.NeighborEmpty())
            {
                currentBranch.SetNeighbor(newCode);
            }
            else
            {
                currentBranch.SetCenter(newCode);
                root = currentBranch.SplitBranch(root);
            }
        }

        public void Insert()
        {
            Insert(RandomCode.Random());
        }

        Branch SearchInsertionPoint(Branch branch, Code code)
        {
            if(branch==null || branch.IsLeaf())
            {
                return branch;
            }
            else if(branch.NeighborEmpty())
            {
                if(code < branch.LeftCode)
                {
                    return SearchInsertionPoint(branch.ChildFirst, code);
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
                else if (code >= branch.LeftCode && code < branch.RightCode)
                {
                    return SearchInsertionPoint(branch.ChildSecond, code);
                }
                else
                {
                    return SearchInsertionPoint(branch.ChildThird, code);
                }
            }
        }
        public void Remove(string code)
        {
            Branch removeBranch = Search(code);
            if (removeBranch!=null)
            {
                PreparingForDeletion(ref removeBranch, ref code);
                FixingTreeAfterRemoval(removeBranch, code);
            }
        }

        void PreparingForDeletion(ref Branch removeBranch,ref string code)
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

        public void FixingTreeAfterRemoval(Branch currentBranch, string code)
        {
            if (currentBranch == root && currentBranch.NeighborEmpty())
            {
                root = null;
            }
            else if (!currentBranch.NeighborEmpty())
            {
                if (currentBranch.LeftCode.str == code)
                {
                    currentBranch.LeftCode = currentBranch.RightCode;
                }
                currentBranch.RightCode = null;
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
                    root = currentBranch.ChildFirst;
                    root.Parent = null;
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

        public void Redistribute(Branch currentBranch,int numChild)
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
                    if(code==null)
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
                        if(code == null)
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
                    if(code == null)
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
                        if(code ==null)
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
                        if(code == null)
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
                    if(code ==null)
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
                    if(code == null)
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
            else if(currentBranch.ChildFirst==null)
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
            return Search(new Code(strCode),root);
        }
        public Branch Search(Code code, Branch currentBranch)
        {
            if (currentBranch != null)
            {
                if (currentBranch.LeftCode==code  ||(currentBranch.RightCode!=null && currentBranch.RightCode==code))
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
            ShowBranch(node, root, foundBranch);
        }
        public void ShowTree(TreeNodeCollection node)
        {
            ShowBranch(node, root);
        }
        void ShowBranch(TreeNodeCollection node, Branch currentBranch)
        {
            TreeNode nodeInside;
            AddNodeToTreeView(currentBranch, out nodeInside, node);
            TransitionToChild(currentBranch.ChildFirst, nodeInside);
            TransitionToChild(currentBranch.ChildSecond, nodeInside);
            TransitionToChild(currentBranch.ChildThird, nodeInside);
        }
        void ShowBranch(TreeNodeCollection node, Branch currentBranch, Branch foundBranch)
        {
            TreeNode nodeInside;
            AddNodeToTreeView(currentBranch, out nodeInside, node);
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
            if (currentBranch.RightCode != null)
            {
                nodeInside = node.Add("<"+currentBranch.LeftCode.str + "><" + currentBranch.RightCode.str+">");
            }
            else
            {
                nodeInside = node.Add("<"+currentBranch.LeftCode.str+">");
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
            root = null;
        }
        public Tree(Branch root)
        {
            this.root = root;
        }
    }
}
