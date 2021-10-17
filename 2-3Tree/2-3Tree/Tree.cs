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
