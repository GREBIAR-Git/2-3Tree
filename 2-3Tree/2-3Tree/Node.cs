namespace _2_3Tree
{
    class Branch
    {
        public string sCode { get; set; }
        public int LeftCode { get; set; }
        public int RightCode { get; set; }
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
            if (RightCode==0)
            {
                return true;
            }
            return false;
        }

        public Branch()
        {
            int NullInt = 0;
            LeftCode = NullInt;
            RightCode = NullInt;
        }

        public Branch(int code)
        {
            this.LeftCode = code;
        }
    }
}
