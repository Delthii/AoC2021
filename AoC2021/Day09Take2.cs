using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AoC2021
{
    public  class Day09Take2
    {
        public void PartA(string[] lines)
        {
            var map = lines.Select(x => x.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            var grid = new Grid<int>(map);
            List<IGridNode<int>> lowPoints = GetLowPoints(grid);

            Console.WriteLine(lowPoints.Sum(lp => lp.Value + 1));
        }
        
        public void PartB(string[] lines)
        {
            var map = lines.Select(x => x.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            var grid = new Grid<int>(map);
            List<IGridNode<int>> lowPoints = GetLowPoints(grid);

            var ans = lowPoints
                .Select(lp => grid.GetConnectedComponent(lp.X, lp.Y, x => x  < 9).Count())
                .OrderByDescending(x => x)
                .Take(3)
                .Aggregate(1, (a, b) => a * b);

        }

        private static List<IGridNode<int>> GetLowPoints(Grid<int> grid)
        {
            var lowPoints = new List<IGridNode<int>>();

            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    var cell = grid.GetNode(x, y);
                    var temp = grid.GetN4(x, y).ToArray();
                    var isLowPoint = grid.GetN4(x, y).All(x => x.Value > cell.Value);
                    if (isLowPoint)
                    {
                        lowPoints.Add(cell);
                    }
                }
            }

            return lowPoints;
        }

    }
}
