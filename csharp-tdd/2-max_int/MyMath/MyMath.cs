using System;
using System.Collections.Generic;

namespace MyMath
{
    public class Operations
    {
        public static int Max(List<int> nums)
        {
            if (nums.Count == 0)
                return 0;

            int result = nums[0];

            foreach (int number in nums)
            {
                if (number > result)
                    result = number;
            }
            return result;
        }
    }
}
