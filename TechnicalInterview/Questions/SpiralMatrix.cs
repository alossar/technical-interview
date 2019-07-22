using System;
using System.Collections.Generic;

namespace TechnicalInterview.Questions
{
    public class SpiralMatrix : Question
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> res = new List<int>();
            if (matrix == null || matrix.Length == 0) return res;
            int rows = matrix.Length, cols = matrix[0].Length;
            int minRow = 0, maxRow = rows - 1;
            int minCol = 0, maxCol = cols - 1;
            while (res.Count < rows * cols)
            {
                for (int col = minCol; col <= maxCol && res.Count < rows * cols; col++)
                    res.Add(matrix[minRow][col]);

                for (int row = minRow + 1; row <= maxRow - 1 && res.Count < rows * cols; row++)
                    res.Add(matrix[row][maxCol]);

                for (int col = maxCol; col >= minCol && res.Count < rows * cols; col--)
                    res.Add(matrix[maxRow][col]);

                for (int row = maxRow - 1; row >= minRow + 1 && res.Count < rows * cols; row--)
                    res.Add(matrix[row][minCol]);

                minCol++; maxCol--; minRow++; maxRow--;
            }
            return res;
        }

        public override void Test()
        {
            int[][] matrix = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };
            IList<int> result = SpiralOrder(matrix);
            Console.WriteLine(result);
        }
    }
}
