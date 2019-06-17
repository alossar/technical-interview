using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview
{
    public partial class Question
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            Trie trie = new Trie();
            for (int i = 0; i < wordDict.Count; i++)
                trie.Add(wordDict[i]);

            return false;
        }
    }
}
