using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview.Questions
{
    public class GroupAnagrams : Question
    {
        public IList<IList<string>> Solution(string[] strs)
        {
            Dictionary<string, IList<string>> groups = new Dictionary<string, IList<string>>();
            HashSet<string> xors = new HashSet<string>();
            for (int i = 0; i < strs.Length; i++)
            {
                int[] xor = new int[26];
                for (int j = 0; j < strs[i].Length; j++)
                    xor[strs[i][j] - 'a'] += 1;
                string hash = GetXORHash(xor);
                if (!groups.ContainsKey(hash))
                    groups[hash] = new List<string>();
                groups[hash].Add(strs[i]);

                if (!xors.Contains(hash))
                    xors.Add(hash);
            }
            IList<IList<string>> result = new List<IList<string>>();
            foreach (string hash in xors)
            {
                result.Add(groups[hash]);
            }
            return result;
        }

        public override void Test()
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            IList<IList<string>> result = Solution(strs);
            Console.WriteLine(result);
        }

        private string GetXORHash(int[] xor)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < xor[i]; j++) builder.Append((char)('a' + i));
            }
            return builder.ToString();
        }
    }
}
