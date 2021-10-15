using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3Tree
{
    class Code
    {
        string str;
        int[] code;
        bool digit;
        public Code(string str)
        {
            this.str = str;
            digit = Int32.TryParse(str, out code);
            if (digit)
            {
            }
            else
            { 
                foreach(char ch in str)
                {
                    code[]
                }
                
            }
        }
    }
}

//a aa b 7 15 3

//  a b aa
// 49 49  49 