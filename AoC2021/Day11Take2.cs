using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AoC2021
{
    public class Day11Take2
    {
        public int PartA(string[] lines)
        {
            var gridArr = lines.Select(str => str.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            var grid = new Grid<int>(gridArr, NeighbourSelectionTypes.N8);
            var ans = 0;

            for (int T = 0; T < 100; ++T) {
                List<(int x, int y)> kaboom = new();
                HashSet<(int x, int y)> flashed = new();

                for (int i = 0; i < grid.Width; i++)
                {
                    for (int j = 0; j < grid.Height; j++)
                    {
                        grid[i, j]++;
                        if (grid[i, j] > 9)
                        {
                            kaboom.Add((i, j));
                            grid[i, j] = 0;
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
                    grid[x, y] = 0;
                }

                ans += flashed.Count;
            }

            Console.WriteLine(ans);
            return ans;
        }

        public int PartB(string[] lines)
        {
            var gridArr = lines.Select(str => str.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            var grid = new Grid<int>(gridArr, NeighbourSelectionTypes.N8);

            for (int T = 0;; ++T)
            {
                List<(int x, int y)> kaboom = new();
                HashSet<(int x, int y)> flashed = new();
                
                for (int i = 0; i < grid.Width; i++)
                {
                    for (int j = 0; j < grid.Height; j++)
                    {
                        grid[i,j]++;
                        if (grid[i,j] > 9)
                        {
                            kaboom.Add((i, j));
                            grid[i,j] = 0;
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
                    grid[x,y] = 0;
                }

                if (flashed.Count == 100)
                {
                    Console.WriteLine(T+1);
                    return T + 1;
                }
            }
        }

        private void IncN(Grid<int> grid, (int, int) cell, List<(int x, int y)> kaboom, HashSet<(int x, int y)> flashed)
        {
            var (x, y) = cell;
            foreach (var node in grid.GetN(x, y))
            {
                node.Value++;
                if (node.Value > 9 && !flashed.Contains((node.X, node.Y)))
                {
                    kaboom.Add((node.X, node.Y));
                }
            }
        }

    }
}
