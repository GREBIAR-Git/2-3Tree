using System;
using System.Linq;

namespace _2_3Tree
{
    class Code
    {
        public string str { get; set; }
        public int[] code { get; set; }
        bool digit;

        public static bool operator <=(Code a, Code b)
        {
            if(a.digit)
            {
                if(b.digit)
                {
                    if(a.code[0]<=b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (b.digit)
                {
                    return false;
                }
                else
                {
                    int length;
                    if (a.code.Length<=b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for(int i=0;i<length;i++)
                    {
                        if(a.code[i]<=b.code[i])
                        {
                            return true;
                        }
                    }
                    return true;
                }
            }
        }

        public static bool operator >=(Code a, Code b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] >= b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (b.digit)
                {
                    return true;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] >= b.code[i])
                        {
                            return true;
                        }
                    }
                    return true;
                }
            }
        }

        public static bool operator <(Code a, Code b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] < b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (b.digit)
                {
                    return false;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] < b.code[i])
                        {
                            return true;
                        }
                    }
                    return true;
                }
            }
        }

        public static bool operator >(Code a,Code b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] > b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (b.digit)
                {
                    return true;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] > b.code[i])
                        {
                            return true;
                        }
                    }
                    return true;
                }
            }
        }

        public static bool operator ==(Code a, Code b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] == b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (b.digit)
                {
                    return false;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] != b.code[i])
                        {
                            return false;
                        }
                    }
                    if(a.code.Length== b.code.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool operator !=(Code a, Code b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] != b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (b.digit)
                {
                    return true;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] != b.code[i])
                        {
                            return true;
                        }
                    }
                    if (a.code.Length != b.code.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

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