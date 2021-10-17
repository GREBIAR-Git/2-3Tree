﻿namespace _2_3Tree
{
    class Branch
    {
        public Code LeftCode { get; set; }
        public Code CenterCode { get; set; }
        public Code RightCode { get; set; }

        public Branch ChildFirst { get; set; }
        public Branch ChildSecond { get; set; }
        public Branch ChildThird { get; set; }
        public Branch ChildExtra { get; set; }
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
        void AddChild(Branch branch)
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
                else if (ChildExtra == null && CenterCode!=null)
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
        void SetParent(Branch branch)
        {
            branch.Parent = this;
        }
        public Branch SplitBranch(Branch root)
        {
            if (Parent == null)
            {
                Parent = new Branch(CenterCode);
                CenterCode = null;
                Parent.AddChild(this);
                Branch b1 = new Branch(RightCode);
                Parent.AddChild(b1);
                RightCode = null;
                if(ChildExtra!=null)
                {
                    b1.AddChild(ChildThird);
                    ChildThird = null;
                    b1.AddChild(ChildExtra);
                    ChildExtra = null;
                }
                return Parent;
            }
            else if (Parent.NeighborEmpty())
            {
                Parent.SetNeighbor(CenterCode);
                CenterCode = null;
                Parent.AddChild(this);
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
                return root;
            }
            else
            {
                Parent.SetCenter(CenterCode);
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
                return Parent.SplitBranch(root);
            }
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
