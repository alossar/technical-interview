﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview.Questions
{
    /// <summary>
    /// We are given that the string "abc" is valid.
    /// From any valid string V, we may split V into two pieces X and Y such that X + Y(X concatenated with Y) is equal to V.  (X or Y may be empty.)  Then, X + "abc" + Y is also valid.
    /// If for example S = "abc", then examples of valid strings are: "abc", "aabcbc", "abcabc", "abcabcababcc".  Examples of invalid strings are: "abccba", "ab", "cababc", "bac".
    /// Return true if and only if the given string S is valid.
    /// Example 1:
    ///     Input: "aabcbc"
    ///     Output: true
    ///     Explanation: 
    ///     We start with the valid string "abc".
    ///     Then we can insert another "abc" between "a" and "bc", resulting in "a" + "abc" + "bc" which is "aabcbc".
    /// Example 2:
    ///     Input: "abcabcababcc"
    ///     Output: true
    ///     Explanation: 
    ///     "abcabcabc" is valid after consecutive insertings of "abc".
    ///     Then we can insert "abc" before the last letter, resulting in "abcabcab" + "abc" + "c" which is "abcabcababcc".
    /// Example 3:
    ///     Input: "abccba"
    ///     Output: false
    /// Example 4:
    ///     Input: "cababc"
    ///     Output: false
    /// Note:
    ///     1 <= S.length <= 20000
    ///     S[i] is 'a', 'b', or 'c'
    /// </summary>
    class CheckIfWordIsValidAfterSubstitutions : Question
    {
        public bool IsValid(string S)
        {
            Stack<char> letters = new Stack<char>();
            for (int i = 0; i < S.Length; i++)
            {
                switch (S[i])
                {
                    case 'a':
                        letters.Push(S[i]);
                        break;
                    case 'b':
                        if (letters.Count == 0 || letters.Peek() != 'a')
                            return false;
                        else
                            letters.Push(S[i]);
                        break;
                    case 'c':
                        if (letters.Count == 0 || letters.Peek() != 'b')
                            return false;
                        else
                        {
                            letters.Pop();
                            letters.Pop();
                        }
                        break;
                }
            }
            return letters.Count == 0;
        }

        public override void Test()
        {
            Console.WriteLine(IsValid("abcabc"));
            Console.WriteLine(IsValid("aabcbc"));
            Console.WriteLine(IsValid("abccba"));
        }
    }
}
