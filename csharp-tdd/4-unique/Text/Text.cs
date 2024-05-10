using System;
using System.Collections.Generic;

namespace Text
{
    public class Str
    {
        public static int UniqueChar(string s)
        {
            int[] alphabet = new int[26];

            foreach (char c in s)
                alphabet[c - 'a']++;

            for(int i = 0; i < s.Length ; i++)
                if (alphabet[s[i] - 'a'] == 1)
                    return i;

            return -1;
        }
    }
}
