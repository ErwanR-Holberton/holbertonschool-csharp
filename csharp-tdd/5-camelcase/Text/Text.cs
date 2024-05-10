using System;

namespace Text
{
    public class Str
    {
        public static int CamelCase(string s)
        {
            if (s.Length == 0)
                return 0;
            int result = 1;
            foreach (char letter in s)
                if (letter >= 'A' && letter <= 'Z')
                    result++;

            return result;
        }
    }
}
