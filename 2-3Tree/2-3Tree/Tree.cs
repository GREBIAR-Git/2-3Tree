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

        public void Search(string strCode)
        {
            Code code = new Code(strCode);
        }
        public void ShowTree(System.Windows.Forms.TreeNodeCollection node)
        {
            ShowBranch(node, root);
        }
        void ShowBranch(System.Windows.Forms.TreeNodeCollection node, Branch currentBranch)
        {
            System.Windows.Forms.TreeNode nodeInside;
            if (currentBranch.RightCode != null)
            {
                nodeInside = node.Add(currentBranch.LeftCode.str + "|" + currentBranch.RightCode.str);
            }
            else
            {
                nodeInside = node.Add(currentBranch.LeftCode.str);
            }
            if (currentBranch.ChildFirst != null)
            {
                ShowBranch(nodeInside.Nodes, currentBranch.ChildFirst);
            }
            if (currentBranch.ChildSecond != null)
            {
                ShowBranch(nodeInside.Nodes, currentBranch.ChildSecond);
            }
            if (currentBranch.ChildThird != null)
            {
                ShowBranch(nodeInside.Nodes, currentBranch.ChildThird);
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
