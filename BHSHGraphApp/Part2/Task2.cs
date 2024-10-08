using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHSHGraphApp.Part2
{
    internal class Task2
    {
        public static void Main()
        {
            char[][] grid = new char[][]
            {
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'0', '0', '1', '0', '0'},
                new char[] {'0', '0', '0', '1', '1'}
            };

            int result = NumIslands(grid);
            Console.WriteLine("Количество островов: " + result);
        }

        static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int numIslands = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        numIslands++;
                        DFS(grid, r, c);
                    }
                }
            }

            return numIslands;
        }

        static void DFS(char[][] grid, int r, int c)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            if (r < 0 || c < 0 || r >= rows || c >= cols || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0';

            DFS(grid, r - 1, c);
            DFS(grid, r + 1, c);
            DFS(grid, r, c - 1);
            DFS(grid, r, c + 1);
        }

    }
}
