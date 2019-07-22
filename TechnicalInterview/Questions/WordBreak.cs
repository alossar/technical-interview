using System;
using System.Collections.Generic;
using TechnicalInterview.DataStructures;

namespace TechnicalInterview.Questions
{
    public class WordBreak : Question
    {
        public bool Solution(string s, IList<string> wordDict)
        {
            Trie trie = new Trie();
            for (int i = 0; i < wordDict.Count; i++)
                trie.Insert(wordDict[i]);

            return false;
        }

        public override void Test()
        {
            IList<string> dict = new List<string> { "leet", "code" };
            string word = "leetcode";
            bool result = Solution(word, dict);
            Console.WriteLine(result);
        }
    }
}
