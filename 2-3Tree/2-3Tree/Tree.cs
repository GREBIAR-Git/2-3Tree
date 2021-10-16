using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            else if(branch.RightCode.str == null)
            {
                if(code < branch.LeftCode)
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
            string i = root.LeftCode.str;
            string g = root.RightCode.str;
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
