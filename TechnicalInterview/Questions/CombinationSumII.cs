using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview.Questions
{
    class CombinationSumII : Question
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSum2(candidates, result, new List<int>(), target, 0);
            return result;
        }

        private void CombinationSum2(int[] candidates, IList<IList<int>> list, IList<int> sequence, int remain, int start)
        {
            if (remain < 0) return; /** no solution */
            else if (remain == 0) list.Add(new List<int>(sequence));
            else
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    if (i > start && candidates[i] == candidates[i - 1]) continue; /** skip duplicates */
                    sequence.Add(candidates[i]);
                    CombinationSum2(candidates, list, sequence, remain - candidates[i], i + 1);
                    sequence.RemoveAt(sequence.Count - 1);
                }
            }
        }

        public override void Test()
        {
            IList<IList<int>> result = CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            PrintResult(result);
            result = CombinationSum2(new int[] { 4, 4, 2, 1, 4, 2, 2, 1, 3 }, 6);
            PrintResult(result);
        }

        private void PrintResult(IList<IList<int>> result)
        {
            Console.WriteLine("Printing result");
            foreach (IList<int> sequence in result)
            {
                foreach (int number in sequence)
                {
                    Console.Write(number + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
