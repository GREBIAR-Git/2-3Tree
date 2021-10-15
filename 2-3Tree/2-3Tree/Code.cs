using System;
using System.Linq;

namespace _2_3Tree
{
    class Code
    {
        public string str { get; set; }
        public int[] code { get; set; }
        bool digit;
        public Code(string str)
        {
            this.str = str;
            digit = Int32.TryParse(str, out code[0]);
            if (!digit)
            {
                code = str.ToCharArray().Select(x => (int)x).ToArray();
            }
        }
    }
}