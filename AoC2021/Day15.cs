using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AoC2021
{
    public class Day15
    {
        public void PartA(string[] lines)
        {
            var grid = new Grid<int>(lines.Select(line => line.Select(c => c - '0').ToArray()).ToArray());
            var dist = new Dictionary<(int x, int y), int>();
            var prev = new Dictionary<(int x, int y), (int x, int y)?>();
            var prioQ = new PriorityQueue<(int x, int y), int>();
            dist[(0, 0)] = 0;
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    var t = (x, y);
                    if (x != 0 || y != 0)
                    {
                        dist[t] = int.MaxValue;
                        prev[t] = null;
                    }

                    prioQ.Enqueue(t, dist[t]);
                }
            }

            while(prioQ.Count > 0)
            {
                var u = prioQ.Dequeue();
                foreach (var n in grid.GetN4(u.x, u.y))
                {
                    var (x, y) = (n.X, n.Y);
                    var alt = dist[u] + grid.Get(x, y);
                    if(alt < dist[(x, y)])
                    {
                        dist[(x, y)] = alt;
                        prev[(x, y)] = u;
                        prioQ.Enqueue((x, y), alt);
                    }
                }
            }

            Console.WriteLine(dist[(grid.Width - 1, grid.Height - 1)]);
        }

        public void PartB(string[] lines)
        {
            var map = lines.Select(line => line.Select(c => c - '0').ToArray()).ToArray();
            var temp = map.Select(row => Duplicate(row)).ToArray();
            List<int[][]> tempList = new();
            for(int i = 0; i < 5; i++)
            {
                tempList.Add(temp.Select(row => row.Select(c => Inc(c, i)).ToArray()).ToArray());
            }
            var temp2 = tempList.SelectMany(list => list).ToArray();
            var grid = new Grid<int>(tempList.SelectMany(list => list).ToArray());
            var dist = new Dictionary<(int x, int y), int>();
            var prev = new Dictionary<(int x, int y), (int x, int y)?>();
            var prioQ = new PriorityQueue<(int x, int y), int>();
            dist[(0, 0)] = 0;
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    var t = (x, y);
                    if (x != 0 || y != 0)
                    {
                        dist[t] = int.MaxValue;
                        prev[t] = null;
                    }

                    prioQ.Enqueue(t, dist[t]);
                }
            }

            while (prioQ.Count > 0)
            {
                var u = prioQ.Dequeue();
                foreach (var n in grid.GetN4(u.x, u.y))
                {
                    var (x, y) = (n.X, n.Y);
                    var alt = dist[u] + grid.Get(x, y);
                    if (alt < dist[(x, y)])
                    {
                        dist[(x, y)] = alt;
                        prev[(x, y)] = u;
                        prioQ.Enqueue((x, y), alt);
                    }
                }
            }

            Console.WriteLine(dist[(grid.Width - 1, grid.Height - 1)]);
        }

        private int Inc(int c, int i)
        {
            var temp = c + i;
            if(temp > 9) temp -= 9;
            return temp;
        }

        private int[] Duplicate(int[] row)
        {
            var arr = new int[row.Length * 5];
            for(int i = 0; i < 5; ++i)
            {
                for(int j = 0; j < row.Length; ++j)
                {
                    var index = i * row.Length + j;
                    arr[index] = (row[j] + i);
                    if (arr[index] > 9) arr[index] -= 9;
                }
            }

            return arr;
        }
    }
}
