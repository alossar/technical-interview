using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview.Questions
{
    public class WordLadder : Question
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            // Create a hashmap to check in O(1) if a word belongs to the dictionary.
            // Change letters in beginWord from (a,z) and check if the new word exists.
            // Check if words has already been generated in list.

            HashSet<string> dictionary = new HashSet<string>();
            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();
            Dictionary<string, string> parents = new Dictionary<string, string>();

            for (int i = 0; i < wordList.Count; i++)
                dictionary.Add(wordList[i]);

            if (!dictionary.Contains(endWord))
                return 0;

            dictionary.Add(beginWord);
            foreach (string word in dictionary)
                graph[word] = FindLadderNeighbors(word, dictionary);


            Queue<string> toVisit = new Queue<string>();
            toVisit.Enqueue(beginWord);

            while (toVisit.Count > 0)
            {
                string node = toVisit.Dequeue();
                if (node == endWord) break;

                foreach (string neighbor in graph[node])
                {
                    if (!parents.ContainsKey(neighbor))
                    {
                        toVisit.Enqueue(neighbor);
                        parents[neighbor] = node;
                    }
                }
            }

            if (!parents.ContainsKey(endWord)) return 0;

            string current = endWord;
            int steps = 1;
            while (beginWord != current)
            {
                steps++;
                current = parents[current];
            }

            return steps;
        }

        public override void Test()
        {
            string beginWord = "hit";
            string endWord = "cog";
            IList<string> dictionary = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            int result = LadderLength(beginWord, endWord, dictionary);

            beginWord = "qa";
            endWord = "sq";
            dictionary = new List<string>() { "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm", "ar", "ci", "ca", "br", "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe", "ho", "ma", "re", "or", "rn", "au", "ur", "rh", "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb", "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz", "no", "bi", "di", "hi", "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi", "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye" };
            result = LadderLength(beginWord, endWord, dictionary);
            Console.WriteLine(result);
        }

        private HashSet<string> FindLadderNeighbors(string beginWord, HashSet<string> dictionary)
        {
            HashSet<string> neighbors = new HashSet<string>();
            for (int i = 0; i <= 'z' - 'a'; i++)
            {
                for (int j = 0; j < beginWord.Length; j++)
                {
                    StringBuilder sb = new StringBuilder(beginWord);
                    sb[j] = (char)('a' + i);
                    string newWord = sb.ToString();
                    if (dictionary.Contains(newWord) && newWord != beginWord)
                    {
                        neighbors.Add(newWord);
                    }
                }
            }
            return neighbors;
        }

    }
}
