using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview.Questions
{
    /// <summary>
    /// You have a set of tiles, where each tile has one letter tiles[i] printed on it. 
    /// Return the number of possible non-empty sequences of letters you can make.
    /// Example 1:
    ///     Input: "AAB"
    ///     Output: 8
    ///     Explanation: The possible sequences are "A", "B", "AA", "AB", "BA", "AAB", "ABA", "BAA".
    /// Example 2:
    ///     Input: "AAABBC"
    ///     Output: 188
    /// Note:
    ///     1 <= tiles.length <= 7
    ///     tiles consists of uppercase English letters.
    /// </summary>
    class LetterTilePossibilities : Question
    {
        public int NumTilePossibilities(string tiles)
        {
            HashSet<string> words = new HashSet<string>();
            int[] lettersCount = new int[26];
            for (int i = 0; i < tiles.Length; i++)
            {
                lettersCount[tiles[i] - 'A'] += 1;
            }
            NumTilePossibilities(tiles, "", 0, words, lettersCount, new int[26]);
            return words.Count;
        }

        private void NumTilePossibilities(string tiles, string word, int iteration, HashSet<string> words, int[] lettersCount, int[] wordLettersCount)
        {
            if (iteration == tiles.Length)
            {
                if (!string.IsNullOrEmpty(word) && !words.Contains(word)) words.Add(word);
            }
            else
            {
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (wordLettersCount[tiles[i] - 'A'] == lettersCount[tiles[i] - 'A']) continue;
                    wordLettersCount[tiles[i] - 'A'] += 1;
                    NumTilePossibilities(tiles, word + tiles[i], iteration + 1, words, lettersCount, wordLettersCount);
                    wordLettersCount[tiles[i] - 'A'] -= 1;
                    NumTilePossibilities(tiles, word, iteration + 1, words, lettersCount, wordLettersCount);
                }
            }
        }

        public int NumTilePossibilitiesI(string tiles)
        {
            HashSet<string> words = new HashSet<string>();
            bool[] seen = new bool[tiles.Length];
            NumTilePossibilities(tiles, new StringBuilder(), 0, words, seen);
            return words.Count;
        }

        private void NumTilePossibilities(string tiles, StringBuilder word, int iteration, HashSet<string> words, bool[] seen)
        {
            if (word.Length > 0) words.Add(word.ToString());
            if (iteration == tiles.Length) return;
            else
            {
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (seen[i]) continue;
                    seen[i] = true;
                    word.Append(tiles[i]);
                    NumTilePossibilities(tiles, word, iteration + 1, words, seen);
                    word.Remove(word.Length - 1, 1);
                    seen[i] = false;
                }
            }
        }

        public override void Test()
        {
            Console.WriteLine(NumTilePossibilities("AAB"));
            Console.WriteLine(NumTilePossibilities(""));
            Console.WriteLine(NumTilePossibilities("ABC"));
            Console.WriteLine(NumTilePossibilities("AAA"));
            Console.WriteLine(NumTilePossibilities("AAAB"));
            Console.WriteLine(NumTilePossibilitiesI("WOKKSK"));
        }
    }
}
