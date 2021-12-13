using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day13
    {
        public void PartA(string[] lines)
        {
            var folds = foldsStr.Split("\r\n").Select(x => x.Split("=")).ToArray();
            List<(int x, int y)> points = ParsePoints(lines);
            points = FoldIt(folds, points, false);

            Console.WriteLine(points.Count);
        }

        public void PartB(string[] lines)
        {
            var folds = foldsStr.Split("\r\n").Select(x => x.Split("=")).ToArray();
            List<(int x, int y)> points = ParsePoints(lines);

            points = FoldIt(folds, points, true);

            for (int j = 0; j < 6; ++j)
            {
                for (int i = 0; i < 40; i++)
                {
                    if (points.Contains((i, j)))
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }

        private static List<(int x, int y)> FoldIt(string[][] folds, List<(int x, int y)> points, bool takeAll)
        {
            var foldsEnu = takeAll ? folds : folds.Take(1).ToArray();
            foreach (var fold in foldsEnu)
            {
                int c = int.Parse(fold[1]);
                if (fold[0] == "y")
                {
                    for (int i = 0; i < points.Count; i++)
                    {
                        var point = points[i];
                        if (point.y > c)
                        {
                            point.y -= (point.y - c) * 2;
                        }
                        points[i] = point;
                    }
                }
                else
                {
                    for (int i = 0; i < points.Count; i++)
                    {
                        var point = points[i];
                        if (point.x > c)
                        {
                            point.x -= (point.x - c) * 2;
                        }
                        points[i] = point;
                    }
                }
                points = points.Distinct().ToList();
            }

            return points;
        }
        private static List<(int x, int y)> ParsePoints(string[] lines)
        {
            List<(int x, int y)> points = new List<(int x, int y)>();
            foreach (var line in lines)
            {
                var split = line.Split(',');
                var p = (int.Parse(split[0]), int.Parse(split[1]));
                points.Add(p);
            }

            return points;
        }

        string foldsStr =
@"x=655
y=447
x=327
y=223
x=163
y=111
x=81
y=55
x=40
y=27
y=13
y=6";
        string foldsTest =
@"y=7
x=5";
    }
}
