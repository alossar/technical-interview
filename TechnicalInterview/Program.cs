using System;
using System.Collections.Generic;

namespace TechnicalInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            Question q = new Question();
            TestNumIslands(q);
            TestWordLadder(q);
            TestWordLadderII(q);
        }

        static void TestNumIslands(Question q)
        {
            char[][] grid = new char[][] {
                new char[] { '1', '1', '1' },
                new char[] { '0', '1', '0' },
                new char[] { '1', '1', '1' }
            };
            q.NumIslands(grid);
        }

        static void TestWordLadderII(Question q)
        {
            string beginWord = "hit";
            string endWord = "cog";
            IList<string> dictionary = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            IList<IList<string>> result = q.FindLadders(beginWord, endWord, dictionary);
        }

        static void TestWordLadder(Question q)
        {
            string beginWord = "hit";
            string endWord = "cog";
            IList<string> dictionary = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            int result = q.LadderLength(beginWord, endWord, dictionary);

            beginWord = "qa";
            endWord = "sq";
            dictionary = new List<string>() { "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm", "ar", "ci", "ca", "br", "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe", "ho", "ma", "re", "or", "rn", "au", "ur", "rh", "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb", "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz", "no", "bi", "di", "hi", "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi", "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye" };
            result = q.LadderLength(beginWord, endWord, dictionary);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
