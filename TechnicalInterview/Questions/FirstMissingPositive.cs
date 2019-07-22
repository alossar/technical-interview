using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview.Questions
{
    class FirstMissingPositive : Question
    {
        public int Solution(int[] nums)
        {
            int lower = 1;
            int upper = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums[i] < lower) lower = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > lower && nums[i] < upper) upper = nums[i];
            }
            return lower + 1;
        }

        public override void Test()
        {
            int[] input = new int[] { 7, 8, 9, 11, 12 };
            Console.WriteLine(Solution(input));
            input = new int[] { 3, 4, -1, 1 };
            Console.WriteLine(Solution(input));
            input = new int[] { 1, 2, 0 };
            Console.WriteLine(Solution(input));
        }
    }
}
