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
            var (path, cost) = grid.GetClosestPath((0, 0), (grid.Width - 1, grid.Height - 1), Distance, Hueristic);

            Console.WriteLine(cost);
        }

        public void PartB(string[] lines)
        {
            var map = lines.Select(line => line.Select(c => c - '0').ToArray()).ToArray();
            var temp = map.Select(row => X5(row)).ToArray();
            List<int[][]> tempList = new();

            for(int i = 0; i < 5; i++)
            {
                tempList.Add(temp.Select(row => row.Select(c => Inc(c, i)).ToArray()).ToArray());
            }

            var grid = new Grid<int>(tempList.SelectMany(list => list).ToArray());
            var (path, cost) = grid.GetClosestPath((0, 0), (grid.Width - 1, grid.Height - 1), Distance, Hueristic);
            
            Console.WriteLine(cost);
        }

        private int Distance((int X, int Y) start, (int X, int Y) end, Grid<int> grid)
        {
            return grid.Get(end.X, end.Y);
        }

        private int Hueristic((int X, int Y) node, Grid<int> grid)
        {
            return grid.Width - node.X + grid.Height - node.Y;
        }

        private int[] X5(int[] row)
        {
            var arr = new int[row.Length * 5];
            for(int i = 0; i < 5; ++i)
            {
                for(int j = 0; j < row.Length; ++j)
                {
                    var index = i * row.Length + j;
                    arr[index] = Inc(row[j], i);
                }
            }

            return arr;
        }
        private int Inc(int c, int i) => c + i > 9 ? c + i - 9 : c + i;
    }
}
