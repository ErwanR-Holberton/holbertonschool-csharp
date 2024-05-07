using System;
using System.Collections.Generic;

namespace MyMath
{
    public class Operations
    {
        public static int Max(List<int> nums)
        {
            int result = 0;

            foreach (int number in nums)
            {
                if (number > result)
                    result = number;
            }
            return result;
        }
    }
}
