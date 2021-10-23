using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3Tree
{
    class RandomCode
    {
        Random rnd;
        public string Random()
        {
            string code = string.Empty;
            if(rnd.Next(10) < 9)
            {
                code = rnd.Next(10000).ToString();
            }
            else
            {
                int length = rnd.Next(15);
                for (int i=0;i< length;i++)
                {
                    code += Convert.ToChar(rnd.Next(97,123));
                }
            }
            return code;
        }

        public RandomCode()
        {
            rnd = new Random();
        }
    }
}
