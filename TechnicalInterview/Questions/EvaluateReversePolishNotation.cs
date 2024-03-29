﻿using System;
using System.Collections.Generic;

namespace TechnicalInterview.Questions
{
    /// <summary>
    /// Evaluate the value of an arithmetic expression in Reverse Polish Notation.
    /// Valid operators are +, -, *, /. Each operand may be an integer or another expression.
    /// Note:
    ///     Division between two integers should truncate toward zero.
    ///     The given RPN expression is always valid. That means the expression would always evaluate to a result and there won't be any divide by zero operation.

    /// Example 1:
    ///     Input: ["2", "1", "+", "3", "*"]
    ///     Output: 9
    ///     Explanation: ((2 + 1) * 3) = 9
    /// </summary>
    public class EvaluateReversePolishNotation : Question
    {
        public int Solution(string[] tokens)
        {
            Stack<int> operands = new Stack<int>();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (IsOperator(tokens[i]))
                {
                    int a = operands.Pop();
                    int b = operands.Pop();
                    switch (tokens[i])
                    {
                        case "+": operands.Push(a + b); break;
                        case "-": operands.Push(b - a); break;
                        case "*": operands.Push(b * a); break;
                        case "/": operands.Push(b / a); break;
                    }
                }
                else
                {
                    operands.Push(int.Parse(tokens[i]));
                }
            }
            return operands.Pop();
        }

        public override void Test()
        {
            string[] tokens = new string[] { "2", "1", "+", "3", "*" };
            int result = Solution(tokens);
            Console.WriteLine(result);

            tokens = new string[] { "4", "13", "5", "/", "+" };
            result = Solution(tokens);
            Console.WriteLine(result);

            tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            result = Solution(tokens);
            Console.WriteLine(result);
        }

        private bool IsOperator(string item)
        {
            return item == "+" || item == "-" || item == "/" || item == "*";
        }
    }
}
