using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day11
    {
        public void PartA(string[] lines)
        {
            var grid = lines.Select(str => str.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            var ans = 0;


            for (int T = 0; T < 100; ++T) {
                List<(int x, int y)> kaboom = new();
                HashSet<(int x, int y)> flashed = new();

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[0].Length; j++)
                    {
                        grid[i][j]++;
                        if (grid[i][j] > 9)
                        {
                            kaboom.Add((i, j));
                            grid[i][j] = 0;
                        }
                    }
                }

                while (kaboom.Count > 0)
                {
                    kaboom = kaboom.Distinct().ToList();
                    var todo = kaboom[^1];
                    kaboom.RemoveAt(kaboom.Count - 1);
                    flashed.Add(todo);
                    IncN(grid, todo, kaboom, flashed);
                }

                foreach(var (x,y) in flashed)
                {
                    grid[x][y] = 0;
                }

                ans += flashed.Count;
            }
        }

        public void IncN(int[][] grid, (int, int) cell, List<(int x, int y)> kaboom, HashSet<(int x, int y)> flashed)
        {
            var (x, y) = cell;
            for(int i = -1; i <= 1; ++i)
            {
                for(int j = -1; j <= 1; ++j)
                {
                    if (i == 0 && i == j) continue;

                    if (x + i < 0) continue;
                    if (y + j < 0) continue;
                    if (y + j >= grid.Length) continue;
                    if (x + i >= grid.Length) continue;
                    var (nx, ny) = (x + i, y + j);
                    grid[nx][ny]++;
                    if(grid[nx][ny] > 9 && !flashed.Contains((nx, ny)))
                    {
                        kaboom.Add((nx, ny));
                    }
                }
            }
        }

        public void PartB(string[] lines)
        {
            var grid = lines.Select(str => str.ToCharArray().Select(c => c - '0').ToArray()).ToArray();

            for (int T = 0;; ++T)
            {
                List<(int x, int y)> kaboom = new();
                HashSet<(int x, int y)> flashed = new();

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[0].Length; j++)
                    {
                        grid[i][j]++;
                        if (grid[i][j] > 9)
                        {
                            kaboom.Add((i, j));
                            grid[i][j] = 0;
                        }
                    }
                }

                while (kaboom.Count > 0)
                {
                    kaboom = kaboom.Distinct().ToList();
                    var todo = kaboom[^1];
                    kaboom.RemoveAt(kaboom.Count - 1);
                    flashed.Add(todo);
                    IncN(grid, todo, kaboom, flashed);
                }

                foreach (var (x, y) in flashed)
                {
                    grid[x][y] = 0;
                }

                if(flashed.Count == 100)
                {
                    Console.WriteLine(T+1);
                    break;
                }
            }
        }

    }
}
