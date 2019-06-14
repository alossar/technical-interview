using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview
{
    public partial class Question
    {
        /// <summary>
        /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// Example:
        ///     Given nums = [2, 7, 11, 15], target = 9,
        ///     Because nums[0] + nums[1] = 2 + 7 = 9,
        ///     return [0, 1].         
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }
            throw new ArgumentException("No two sum solution");
        }
    }
}
