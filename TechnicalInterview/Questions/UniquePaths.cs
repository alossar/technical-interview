﻿using System;

namespace TechnicalInterview.Questions
{
    public class UniquePaths : Question
    {
        /// <summary>
        /// A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        /// The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
        /// How many possible unique paths are there?
        /// </summary>
        /// <param name="m">rows</param>
        /// <param name="n">cols</param>
        /// <returns>unique paths</returns>
        public int Solution(int m, int n)
        {
            int[][] visited = new int[m][];
            for (int i = 0; i < m; i++) visited[i] = new int[n];
            return Solution(0, 0, m, n, visited);
        }

        public int Solution(int currentRow, int currentCol, int goalRow, int goalCol, int[][] visited)
        {
            if (currentCol == goalCol - 1 && currentRow == goalRow - 1)
                return 1;

            if (visited[currentRow][currentCol] != 0)
            {
                return visited[currentRow][currentCol] < 0 ? 0 : visited[currentRow][currentCol];
            }
            visited[currentRow][currentCol] = -1;

            int paths = 0;
            if (currentRow + 1 < goalRow)
                paths += Solution(currentRow + 1, currentCol, goalRow, goalCol, visited);
            if (currentCol + 1 < goalCol)
                paths += Solution(currentRow, currentCol + 1, goalRow, goalCol, visited);

            if (paths > 0)
                visited[currentRow][currentCol] = paths;

            return paths;
        }

        public override void Test()
        {
            int result = Solution(3, 2);
            Console.WriteLine(result);

            result = Solution(7, 3);
            Console.WriteLine(result);
        }
    }
}
