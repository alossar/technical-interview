using System;
using System.Collections.Generic;

namespace TechnicalInterview
{
    class Program
    {
        private static Question q = new Question();

        static void Main(string[] args)
        {
            TestNumIslands();
            TestWordLadder();
            TestWordLadderII();
            TestSetMatrixZeroes();
            TestUniquePaths();
            TestEvalReversePolishNotation();
            TestGroupAnagrams();
            TestWordBreak();
        }

        static void TestNumIslands()
        {
            char[][] grid = new char[][] {
                new char[] { '1', '1', '1' },
                new char[] { '0', '1', '0' },
                new char[] { '1', '1', '1' }
            };
            q.NumIslands(grid);
        }

        static void TestWordLadderII()
        {
            string beginWord = "hit";
            string endWord = "cog";
            IList<string> dictionary = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            IList<IList<string>> result = q.FindLadders(beginWord, endWord, dictionary);
            Console.WriteLine(result);
        }

        static void TestWordLadder()
        {
            string beginWord = "hit";
            string endWord = "cog";
            IList<string> dictionary = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            int result = q.LadderLength(beginWord, endWord, dictionary);

            beginWord = "qa";
            endWord = "sq";
            dictionary = new List<string>() { "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm", "ar", "ci", "ca", "br", "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe", "ho", "ma", "re", "or", "rn", "au", "ur", "rh", "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb", "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz", "no", "bi", "di", "hi", "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi", "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye" };
            result = q.LadderLength(beginWord, endWord, dictionary);
            Console.WriteLine(result);
        }

        static void TestSetMatrixZeroes()
        {
            int[][] matrix = new int[][] { new int[] { 0, 1, 2, 0 }, new int[] { 3, 4, 5, 2 }, new int[] { 1, 3, 1, 5 } };
            q.SetZeroes(matrix);
            Console.WriteLine(matrix);

            matrix = new int[][] { new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 } };
            q.SetZeroes(matrix);
            Console.WriteLine(matrix);
        }

        static void TestUniquePaths()
        {
            int result = q.UniquePaths(3, 2);
            Console.WriteLine(result);

            result = q.UniquePaths(7, 3);
            Console.WriteLine(result);
        }

        static void TestEvalReversePolishNotation()
        {
            string[] tokens = new string[] { "2", "1", "+", "3", "*" };
            int result = q.EvalRPN(tokens);
            Console.WriteLine(result);

            tokens = new string[] { "4", "13", "5", "/", "+" };
            result = q.EvalRPN(tokens);
            Console.WriteLine(result);

            tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            result = q.EvalRPN(tokens);
            Console.WriteLine(result);
        }

        static void TestGroupAnagrams()
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            IList<IList<string>> result = q.GroupAnagrams(strs);
            Console.WriteLine(result);
        }


        static void TestWordBreak()
        {
            IList<string> dict = new List<string> { "leet", "code" };
            string word = "leetcode";
            bool result = q.WordBreak(word, dict);
            Console.WriteLine(result);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    public class Trie
    {
        Dictionary<char, Trie> children;

        public Trie()
        {
            children = new Dictionary<char, Trie>();
        }

        private bool ContainsKey(char letter)
        {
            return children.ContainsKey(letter);
        }

        public void Add(string word)
        {
            Trie current = this;
            for (int i = 0; i < word.Length; i++)
            {
                if (!current.ContainsKey(word[i]))
                {
                    current.children[word[i]] = new Trie();
                }
                current = current.children[word[i]];
            }
        }

        public bool Contains(string word)
        {
            Trie current = this;
            int wordIndex = 0;
            while (current != null)
            {
                if (current.ContainsKey(word[wordIndex]))
                {
                    current = current.children[word[wordIndex]];
                    wordIndex++;
                }
                else
                    break;
            }
            return wordIndex == word.Length - 1;
        }
    }
}
