using System.Linq;

namespace _2_3Tree
{
#pragma warning disable CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
#pragma warning disable CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
    public class Key
    {
        readonly bool digit;

        public Key(string key)
        {
            ToString = key;
            digit = int.TryParse(key, out int result);
            Code = digit ? new[] { result } : key.ToCharArray().Select(x => (int)x).ToArray();
        }

        public new string ToString { get; private set; }
        int[] Code { get; }

        public static bool operator <=(Key a, Key b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.Code[0] <= b.Code[0])
                    {
                        return true;
                    }

                    return false;
                }

                return true;
            }

            if (b.digit)
            {
                return false;
            }

            int length = a.Code.Length <= b.Code.Length ? a.Code.Length : b.Code.Length;

            for (int i = 0; i < length; i++)
            {
                if (a.Code[i] > b.Code[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator >=(Key a, Key b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.Code[0] >= b.Code[0])
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }

            if (b.digit)
            {
                return true;
            }

            int length = a.Code.Length <= b.Code.Length ? a.Code.Length : b.Code.Length;

            for (int i = 0; i < length; i++)
            {
                if (a.Code[i] < b.Code[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator <(Key a, Key b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.Code[0] < b.Code[0])
                    {
                        return true;
                    }

                    return false;
                }

                return true;
            }

            if (b.digit)
            {
                return false;
            }

            int length = a.Code.Length <= b.Code.Length ? a.Code.Length : b.Code.Length;

            for (int i = 0; i < length; i++)
            {
                if (a.Code[i] >= b.Code[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator >(Key a, Key b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.Code[0] > b.Code[0])
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }

            if (b.digit)
            {
                return true;
            }

            int length = a.Code.Length <= b.Code.Length ? a.Code.Length : b.Code.Length;

            for (int i = 0; i < length; i++)
            {
                if (a.Code[i] <= b.Code[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator ==(Key a, Key b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.Code[0] == b.Code[0])
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }

            if (b.digit)
            {
                return false;
            }

            if (a.Code.Length != b.Code.Length)
            {
                return false;
            }

            int length = a.Code.Length;
            for (int i = 0; i < length; i++)
            {
                if (a.Code[i] != b.Code[i])
                {
                    return false;
                }
            }

            if (a.Code.Length == b.Code.Length)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Key a, Key b)
        {
            if ((a is object && b is null) || (a is null && b is object))
            {
                return true;
            }

            if (a is null)
            {
                return false;
            }

            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.Code[0] != b.Code[0])
                    {
                        return true;
                    }

                    return false;
                }

                return true;
            }

            if (b.digit)
            {
                return true;
            }

            int length = a.Code.Length <= b.Code.Length ? a.Code.Length : b.Code.Length;

            for (int i = 0; i < length; i++)
            {
                if (a.Code[i] != b.Code[i])
                {
                    return true;
                }
            }

            if (a.Code.Length != b.Code.Length)
            {
                return true;
            }

            return false;
        }
    }
}