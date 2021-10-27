using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3Tree
{
    class RandomCode
    {
        static Random rnd = new Random();
        public static string Random()
        {
            string code = string.Empty;
            if(rnd.Next(12) < 11)
            {
                code = rnd.Next(1000).ToString();
            }
            else
            {
                int length = rnd.Next(1,12);
                for (int i=0;i< length;i++)
                {
                    code += Convert.ToChar(rnd.Next(97,123));
                }
            }
            return code;
        }
    }
}
