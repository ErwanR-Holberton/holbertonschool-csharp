using System;

namespace Text
{
    public class Str
    {
        public static bool IsPalindrome(string s)
        {
            int end = s.Length - 1;
            int start = 0;

            return recursive_palindrome(s, start, end);
        }
        private static bool is_not_letter(char c)
        {
            if (c < 65 )
                return true;
            if (c > 90 && c < 97)
                return true;
            if (c > 122)
                return true;
            return false;
        }
        private static bool recursive_palindrome(string s, int start, int end)
        {
            if (start >= end)
                return true;
            if (is_not_letter(s[start]))
                return recursive_palindrome(s, start + 1, end);
            if (is_not_letter(s[end]))
                return recursive_palindrome(s, start, end - 1);
            if (s[start] == s[end])
                return recursive_palindrome(s, start + 1, end - 1);
            if (s[start] == s[end] + 32)
                return recursive_palindrome(s, start + 1, end - 1);
            if (s[start] == s[end] - 32)
                return recursive_palindrome(s, start + 1, end - 1);
            return false;
        }
    }
}
