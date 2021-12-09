using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day09
    {
        public void PartA(string[] lines)
        {
            var map = lines.Select(x => x.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            var lowpoints = FindLowPoints(lines, map);
            Console.WriteLine(lowpoints.Sum(pos => map[pos.x][pos.y] + 1));
        }

        public void PartB(string[] lines)
        {
            var map = lines.Select(x => x.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            List<(int x, int y)> lowpoints = FindLowPoints(lines, map);

            var ans = lowpoints
                .Select(lp => FloodFill(lp, map).Count)
                .OrderByDescending(x => x)
                .Take(3)
                .Aggregate(1, (acc, x) => acc * x);

            Console.WriteLine(ans);
        }

        private static List<(int x, int y)> FindLowPoints(string[] lines, int[][] map)
        {
            var lowpoints = new List<(int x, int y)>();
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    var cell = map[i][j];
                    var n1 = 99;
                    var n2 = 99;
                    var n3 = 99;
                    var n4 = 99;
                    if (i > 0)
                        n1 = map[i - 1][j];
                    if (j > 0)
                        n2 = map[i][j - 1];
                    if (j < map[0].Length - 1)
                        n3 = map[i][j + 1];
                    if (i < map.Length - 1)
                        n4 = map[i + 1][j];

                    if (cell < n1 && cell < n2 && cell < n3 && cell < n4)
                    {
                        lowpoints.Add((i, j));
                    }
                }
            }

            return lowpoints;
        }

        public HashSet<(int x, int y)> FloodFill((int x, int y) pos, int[][] map)
        {
            var hs = new HashSet<(int x,int y)>();
            FloodFill(pos, map, hs);
            return hs;
        }

        public void FloodFill((int x, int y) pos, int[][] map, HashSet<(int x, int y)> visited)
        {
            var (x, y) = pos;

            if (visited.Contains(pos)) return;
            if (x < 0 || y < 0 || y > map[0].Length - 1 || x > map.Length - 1 || map[x][y] == 9) return;

            visited.Add(pos);

            FloodFill((x + 1, y), map, visited);
            FloodFill((x - 1, y), map, visited);
            FloodFill((x, y + 1), map, visited);
            FloodFill((x, y - 1), map, visited);
        }
    }
}