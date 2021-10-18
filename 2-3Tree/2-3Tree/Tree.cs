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
            if(removeBranch.IsLeaf()&&!removeBranch.NeighborEmpty())
            {
                removeBranch.RightCode = null;
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
