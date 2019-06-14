using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalInterview
{
    public partial class Question
    {
        public int NumIslands(char[][] grid)
        {
            bool[][] visited = new bool[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
                visited[i] = new bool[grid[i].Length];

            int islands = 0;
            for (int row = 0; row < grid.Length; row++)
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] == '1' && !visited[row][col])
                    {
                        islands++;
                        TraverseIsland(grid, visited, row, col);
                    }
                }

            return islands;
        }

        private void TraverseIsland(char[][] grid, bool[][] visited, int row, int col)
        {

            if (visited[row][col])
                return;

            visited[row][col] = true;

            List<int[]> neighbors = new List<int[]>();

            if (row + 1 < grid.Length && grid[row + 1][col] == '1' && !visited[row + 1][col])
                neighbors.Add(new int[] { row + 1, col });
            if (row - 1 >= 0 && grid[row - 1][col] == '1' && !visited[row - 1][col])
                neighbors.Add(new int[] { row - 1, col });
            if (col + 1 < grid[row].Length && grid[row][col + 1] == '1' && !visited[row][col + 1])
                neighbors.Add(new int[] { row, col + 1 });
            if (col - 1 >= 0 && grid[row][col - 1] == '1' && !visited[row][col - 1])
                neighbors.Add(new int[] { row, col - 1 });

            for (int i = 0; i < neighbors.Count; i++)
            {
                TraverseIsland(grid, visited, neighbors[i][0], neighbors[i][1]);
            }
        }

    }
}
