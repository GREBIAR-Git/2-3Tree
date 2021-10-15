using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3Tree
{
    class Tree
    {
        Branch root;

        public void Insert(int code)
        {
            Branch currentBranch = SearchInsertionPoint(root, code);

            if (currentBranch == null)
            {
                root = new Branch(code);
            }
            else if (currentBranch.IsLeaf() && currentBranch.NeighborEmpty())
            {
                if (currentBranch.LeftCode. <= code)
                {
                    currentBranch.RightCode = code;
                }
                else
                {
                    currentBranch.RightCode = currentBranch.LeftCode;
                    currentBranch.LeftCode = code;
                }    
            }
            else if (false)
            {

            }
            else if(false)
            {

            }
        }

        Branch SearchInsertionPoint(Branch branch, int code)
        {
            if(branch.IsLeaf())
            {
                return branch;
            }
            else if(branch.RightCode.str == null)
            {
                if(code < branch.LeftCode.code)
                {
                    SearchInsertionPoint(branch.ChildFirst, code);
                }
                else
                {
                    SearchInsertionPoint(branch.ChildSecond, code);
                }
            }
            else
            {
                if (code < branch.LeftCode)
                {
                    SearchInsertionPoint(branch.ChildFirst, code);
                }
                else if (code > branch.LeftCode && code <= branch.RightCode)
                {
                    SearchInsertionPoint(branch.ChildSecond, code);
                }
                else
                {
                    SearchInsertionPoint(branch.ChildThird, code);
                }
            }
            return null;
        }

        public void PrintRoot()
        {
            int i = root.RightCode;
            int f = root.LeftCode;
            int jfg = 93;
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
