namespace _2_3Tree
{
    class Branch
    {
        public Code LeftCode { get; set; }
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
            if (RightCode.str==null)
            {
                return true;
            }
            return false;
        }

        public void SetNeighbor(string code)
        {
            Code newCode = new Code(code);

            if (LeftCode <= newCode)
            {
                RightCode = newCode;
            }
            else
            {
                RightCode = LeftCode;
                LeftCode = newCode;
            }
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

        public Branch()
        {
            LeftCode.str = null;
            RightCode.str = null;
        }
        public Branch(string code)
        {
            this.LeftCode = new Code(code);
        }
    }
}
