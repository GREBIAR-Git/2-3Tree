namespace _2_3Tree
{
    class Branch
    {
        public Code LeftCode { get; set; }

        public Code CenterCode { get; set; }
        public Code RightCode { get; set; }

        public Branch ChildFirst { get; set; }
        public Branch ChildSecond { get; set; }
        public Branch ChildThird { get; set; }
        public Branch Parent { get; set; }

        public bool IsLeaf()
        {
            if(ChildFirst==null&& ChildSecond==null&& ChildThird==null)
            {
                return true;
            }
            return false;
        }

        public bool NeighborEmpty()
        {
            if (RightCode==null)
            {
                return true;
            }
            return false;
        }

        public void SetNeighbor(string code)
        {
            Code newCode = new Code(code);
            SetNeighbor(newCode);
        }

        public void SetNeighbor(Code code)
        {
            if (LeftCode <= code)
            {
                RightCode = code;
            }
            else
            {
                RightCode = LeftCode;
                LeftCode = code;
            }
        }

        public void SetCenter(Code code)
        {
            if (LeftCode >= code)
            {
                CenterCode = LeftCode;
                LeftCode = code;
            }
            else if(RightCode >= code)
            {
                CenterCode = code;
            }
            else
            {
                CenterCode = RightCode;
                RightCode = code;
            }
        }

        public void AddChild(Branch branch)
        {
            if (ChildFirst==null)
            {
                ChildFirst = branch;
            }
            else if(ChildSecond == null)
            {
                if(ChildFirst.LeftCode< branch.LeftCode)
                {
                    ChildSecond = branch;
                }
                else
                {
                    ChildSecond = ChildFirst;
                    ChildFirst = branch;
                }
            }
            else if (ChildThird == null)
            {
                if (ChildFirst.LeftCode > branch.LeftCode)
                {
                    ChildThird = ChildSecond;
                    ChildSecond = ChildFirst;
                    ChildFirst = branch;
                }
                else if (ChildSecond.LeftCode > branch.LeftCode)
                {
                    ChildThird = ChildSecond;
                    ChildSecond = branch;
                }
                else
                {
                    ChildThird = branch;
                }
            }
        }

        public Branch SplitBranch(Branch root)
        {
            if(Parent==null)
            {
                Parent = new Branch(CenterCode);
                CenterCode = null;
                Parent.AddChild(this);
                Parent.AddChild(new Branch(RightCode));
                RightCode = null;
                return Parent;
            }
            else if(Parent.NeighborEmpty())
            {
                Parent.SetNeighbor(CenterCode);
                CenterCode = null;
                Parent.AddChild(this);
                Parent.AddChild(new Branch(RightCode));
                RightCode = null;
                return root;
            }
            else
            {
                Parent.SetCenter(CenterCode);
                Parent.SplitBranch(root);
            }
            return root;
        }

        public Branch()
        {
            LeftCode.str = null;
            RightCode.str = null;
        }
        public Branch(string code)
        {
            this.LeftCode = new Code(code);
        }

        public Branch(Code code)
        {
            this.LeftCode = code;
        }
    }
}
