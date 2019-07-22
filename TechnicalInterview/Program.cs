using System;
using System.Collections.Generic;
using TechnicalInterview.DataStructures;
using TechnicalInterview.Questions;

namespace TechnicalInterview
{
    class Program
    {
        private static List<Question> questions = new List<Question>();

        static void Main(string[] args)
        {
            TestQuestions();
            TestDataStructures();
        }

        private static void TestQuestions()
        {
            questions.Add(new NumberOfIslands());
            questions.Add(new WordLadder());
            questions.Add(new WordLadderII());
            questions.Add(new SetZeroes());
            questions.Add(new UniquePaths());
            questions.Add(new EvaluateReversePolishNotation());
            questions.Add(new GroupAnagrams());
            questions.Add(new WordBreak());
            questions.Add(new InorderTraversal());
            questions.Add(new ZigzagLevelOrderTraversal());
            questions.Add(new IntersectionOfTwoLinkedLists());
            questions.Add(new OddEvenList());
            questions.Add(new SpiralMatrix());
            questions.Add(new FirstMissingPositive());
            questions.Add(new LetterTilePossibilities());
            questions.Add(new CheckIfWordIsValidAfterSubstitutions());
            questions.Add(new CombinationSumII());

            foreach (Question q in questions)
            {
                Console.WriteLine($"Testing {q.GetType().Name}");
                q.Test();
                Console.WriteLine($"");
            }
        }

        private static void TestDataStructures()
        {
            TestLRUCache();
            TestTrie();
        }

        private static void TestLRUCache()
        {
            Console.WriteLine($"Testing LRU Cache");
            LRUCache cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);       // returns 1
            cache.Put(3, 3);    // evicts key 2
            cache.Get(2);       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            cache.Get(1);       // returns -1 (not found)
            cache.Get(3);       // returns 3
            cache.Get(4);       // returns 4
            Console.WriteLine($"");
        }

        private static void TestTrie()
        {
            Console.WriteLine($"Testing Trie");
            Trie trie = new Trie();
            Console.WriteLine($"");
        }
    }

}
