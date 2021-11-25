namespace _2_3Tree
{
    class Branch
    {
        public Code LeftCode { get; set; }
        Code CenterCode { get; set; }
        public Code RightCode { get; set; }

        public Branch ChildFirst { get; set; }
        public Branch ChildSecond { get; set; }
        public Branch ChildThird { get; set; }
        Branch ChildExtra { get; set; }
        public Branch Parent { get; set; }


        public bool IsLeaf()
        {
            if (ChildFirst == null && ChildSecond == null && ChildThird == null)
            {
                return true;
            }
            return false;
        }
        public bool NeighborEmpty()
        {
            if (RightCode == null)
            {
                return true;
            }
            return false;
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
            else if (RightCode >= code)
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
            if (ChildFirst != branch && ChildSecond != branch && ChildThird != branch)
            {
                if (ChildFirst == null)
                {
                    ChildFirst = branch;
                    SetParent(ChildFirst);
                }
                else if (ChildSecond == null)
                {
                    if (ChildFirst.LeftCode < branch.LeftCode)
                    {
                        ChildSecond = branch;
                        SetParent(ChildSecond);
                    }
                    else
                    {
                        ChildSecond = ChildFirst;
                        SetParent(ChildSecond);
                        ChildFirst = branch;
                        SetParent(ChildFirst);
                    }
                }
                else if (ChildThird == null)
                {
                    if (ChildFirst.LeftCode > branch.LeftCode)
                    {
                        ChildThird = ChildSecond;
                        SetParent(ChildThird);
                        ChildSecond = ChildFirst;
                        SetParent(ChildSecond);
                        ChildFirst = branch;
                        SetParent(ChildFirst);
                    }
                    else if (ChildSecond.LeftCode > branch.LeftCode)
                    {
                        ChildThird = ChildSecond;
                        SetParent(ChildThird);
                        ChildSecond = branch;
                        SetParent(ChildSecond);
                    }
                    else
                    {
                        ChildThird = branch;
                        SetParent(ChildThird);
                    }
                }
                else if (ChildExtra == null && CenterCode != null)
                {
                    if (ChildFirst.LeftCode > branch.LeftCode)
                    {
                        ChildExtra = ChildThird;
                        SetParent(ChildExtra);
                        ChildThird = ChildSecond;
                        SetParent(ChildThird);
                        ChildSecond = ChildFirst;
                        SetParent(ChildSecond);
                        ChildFirst = branch;
                        SetParent(ChildFirst);
                    }
                    else if (ChildSecond.LeftCode > branch.LeftCode)
                    {
                        ChildExtra = ChildThird;
                        SetParent(ChildExtra);
                        ChildThird = ChildSecond;
                        SetParent(ChildThird);
                        ChildSecond = branch;
                        SetParent(ChildSecond);
                    }
                    else if (ChildThird.LeftCode > branch.LeftCode)
                    {
                        ChildExtra = ChildThird;
                        SetParent(ChildExtra);
                        ChildThird = branch;
                        SetParent(ChildThird);
                    }
                    else
                    {
                        ChildExtra = branch;
                        SetParent(ChildExtra);
                    }
                }
            }
        }

        public int WhichChildren()
        {
            if (Parent == null)
            {
                return 0;
            }
            else if (Parent.ChildFirst == this)
            {
                return 1;
            }
            else if (Parent.ChildSecond == this)
            {
                return 2;
            }
            else if (Parent.ChildThird == this)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
        void SetParent(Branch branch)
        {
            branch.Parent = this;
        }
        public void SplitBranch(ref Branch root)
        {
            if (Parent == null)
            {
                Parent = new Branch(CenterCode);
                Parent.AddChild(this);
                SplitMainPart();
                root = Parent;
            }
            else if (Parent.NeighborEmpty())
            {
                Parent.SetNeighbor(CenterCode);
                Parent.AddChild(this);
                SplitMainPart();
            }
            else
            {
                Parent.SetCenter(CenterCode);
                SplitMainPart();
                Parent.SplitBranch(ref root);
            }
        }

        void SplitMainPart()
        {
            CenterCode = null;
            Branch b1 = new Branch(RightCode);
            Parent.AddChild(b1);
            RightCode = null;
            if (ChildExtra != null)
            {
                b1.AddChild(ChildThird);
                ChildThird = null;
                b1.AddChild(ChildExtra);
                ChildExtra = null;
            }
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
