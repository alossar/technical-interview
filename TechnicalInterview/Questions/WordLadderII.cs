using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview.Questions
{
    public class WordLadderII : Question
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            // Create a hashmap to check in O(1) if a word belongs to the dictionary.
            // Change letters in beginWord from (a,z) and check if the new word exists.
            // Check if words has already been generated in list.

            HashSet<string> dictionary = new HashSet<string>();
            HashSet<string> visited = new HashSet<string>();
            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> parents = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < wordList.Count; i++)
                dictionary.Add(wordList[i]);

            if (!dictionary.Contains(endWord)) return new List<IList<string>>();

            dictionary.Add(beginWord);
            foreach (string word in dictionary)
                graph[word] = FindNeighbors(word, dictionary);


            Queue<string> toVisit = new Queue<string>();
            toVisit.Enqueue(beginWord);

            while (toVisit.Count > 0)
            {
                string node = toVisit.Dequeue();
                visited.Add(node);
                if (node == endWord) break;

                foreach (string neighbor in graph[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        toVisit.Enqueue(neighbor);
                        if (!parents.ContainsKey(neighbor))
                        {
                            parents[neighbor] = new HashSet<string>();
                        }
                        parents[neighbor].Add(node);
                    }
                }
            }

            if (!parents.ContainsKey(endWord)) return new List<IList<string>>();

            string current = endWord;
            IList<IList<string>> ladders = BuildLadders(beginWord, endWord, current, parents);
            return ladders;
        }

        public override void Test()
        {
            string beginWord = "hit";
            string endWord = "cog";
            IList<string> dictionary = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            IList<IList<string>> result = FindLadders(beginWord, endWord, dictionary);
            Console.WriteLine(result);
        }

        private IList<IList<string>> BuildLadders(string beginWord, string endWord, string currentWord, Dictionary<string, HashSet<string>> parents)
        {
            if (beginWord == currentWord)
                return new List<IList<string>>() { new List<string> { currentWord } };

            IList<IList<string>> result = new List<IList<string>>();
            foreach (string neighbor in parents[currentWord])
            {
                IList<IList<string>> paths = BuildLadders(beginWord, endWord, neighbor, parents);
                foreach (IList<string> path in paths)
                {
                    path.Add(neighbor);
                    result.Add(path);
                }
            }

            return result;
        }

        private HashSet<string> FindNeighbors(string beginWord, HashSet<string> dictionary)
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
