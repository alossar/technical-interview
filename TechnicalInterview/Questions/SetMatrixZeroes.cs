using System;

namespace TechnicalInterview.Questions
{
    /// <summary>
    /// Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in-place.
    /// </summary>
    public class SetZeroes : Question
    {
        public void Solution(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return;

            bool firstRow = false, firstCol = false;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (i == 0) firstRow = true;
                        if (j == 0) firstCol = true;
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            if (firstRow)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[0][j] = 0;
                }
            }
            if (firstCol)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }

        public override void Test()
        {
            int[][] matrix = new int[][] { new int[] { 0, 1, 2, 0 }, new int[] { 3, 4, 5, 2 }, new int[] { 1, 3, 1, 5 } };
            Solution(matrix);
            Console.WriteLine(matrix);

            matrix = new int[][] { new int[] { 1, 1, 1 }, new int[] { 0, 1, 2 } };
            Solution(matrix);
            Console.WriteLine(matrix);
        }
    }
}
