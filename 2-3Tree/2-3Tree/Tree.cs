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

        public void Insert(string code)
        {
            Code newCode = new Code(code);
            Branch currentBranch = SearchInsertionPoint(root, newCode);

            if (currentBranch == null)
            {
                root = new Branch(code);
            }
            else if (currentBranch.IsLeaf() && currentBranch.NeighborEmpty())
            {
                currentBranch.SetNeighbor(newCode);
            }
            else if (false)
            {

            }
            else if(false)
            {

            }
        }

        Branch SearchInsertionPoint(Branch branch, Code code)
        {
            if(branch.IsLeaf())
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
