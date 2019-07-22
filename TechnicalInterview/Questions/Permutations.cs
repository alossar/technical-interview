using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview.Questions
{
    class Permutations : Question
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            backtrack(list, new List<int>(), nums);
            return list;
        }

        private void backtrack(IList<IList<int>> list, List<int> tempList, int[] nums)
        {
            if (tempList.Count == nums.Length)
            {
                list.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (tempList.Contains(nums[i])) continue; // element already exists, skip
                    tempList.Add(nums[i]);
                    backtrack(list, tempList, nums);
                    tempList.Remove(tempList.Count - 1);
                }
            }
        }
        public override void Test()
        {
            throw new NotImplementedException();
        }
    }
}
