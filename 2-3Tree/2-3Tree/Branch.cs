namespace _2_3Tree
{
    public class Branch
    {
        public Branch(string code)
        {
            LeftKey = new Key(code);
        }

        public Branch(Key key)
        {
            LeftKey = key;
        }

        public Key LeftKey { get; set; }
        Key CenterKey { get; set; }
        public Key RightKey { get; set; }

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
            if (RightKey == null)
            {
                return true;
            }

            return false;
        }

        public void SetNeighbor(Key key)
        {
            if (LeftKey <= key)
            {
                RightKey = key;
            }
            else
            {
                RightKey = LeftKey;
                LeftKey = key;
            }
        }

        public void SetCenter(Key key)
        {
            if (LeftKey >= key)
            {
                CenterKey = LeftKey;
                LeftKey = key;
            }
            else if (RightKey >= key)
            {
                CenterKey = key;
            }
            else
            {
                CenterKey = RightKey;
                RightKey = key;
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
                    if (ChildFirst.LeftKey < branch.LeftKey)
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
                    if (ChildFirst.LeftKey > branch.LeftKey)
                    {
                        ChildThird = ChildSecond;
                        SetParent(ChildThird);
                        ChildSecond = ChildFirst;
                        SetParent(ChildSecond);
                        ChildFirst = branch;
                        SetParent(ChildFirst);
                    }
                    else if (ChildSecond.LeftKey > branch.LeftKey)
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
                else if (ChildExtra == null && CenterKey != null)
                {
                    if (ChildFirst.LeftKey > branch.LeftKey)
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
                    else if (ChildSecond.LeftKey > branch.LeftKey)
                    {
                        ChildExtra = ChildThird;
                        SetParent(ChildExtra);
                        ChildThird = ChildSecond;
                        SetParent(ChildThird);
                        ChildSecond = branch;
                        SetParent(ChildSecond);
                    }
                    else if (ChildThird.LeftKey > branch.LeftKey)
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

            if (Parent.ChildFirst == this)
            {
                return 1;
            }

            if (Parent.ChildSecond == this)
            {
                return 2;
            }

            if (Parent.ChildThird == this)
            {
                return 3;
            }

            return 0;
        }

        void SetParent(Branch branch)
        {
            branch.Parent = this;
        }

        public void SplitBranch(ref Branch root)
        {
            if (Parent == null)
            {
                Parent = new Branch(CenterKey);
                Parent.AddChild(this);
                SplitMainPart();
                root = Parent;
            }
            else if (Parent.NeighborEmpty())
            {
                Parent.SetNeighbor(CenterKey);
                Parent.AddChild(this);
                SplitMainPart();
            }
            else
            {
                Parent.SetCenter(CenterKey);
                SplitMainPart();
                Parent.SplitBranch(ref root);
            }
        }

        void SplitMainPart()
        {
            CenterKey = null;
            Branch b1 = new Branch(RightKey);
            Parent.AddChild(b1);
            RightKey = null;
            if (ChildExtra != null)
            {
                b1.AddChild(ChildThird);
                ChildThird = null;
                b1.AddChild(ChildExtra);
                ChildExtra = null;
            }
        }
    }
}