using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day05
    {
        public void PartA(string[] lines)
        {
            List<Segment> segments = CreateSegments(lines);
            List<List<int>> map = InitMap(1000);

            int ans = 0;
            foreach(var s in segments)
            {
                int startX = Math.Min(s.Start.X, s.End.X);
                int startY = Math.Min(s.Start.Y, s.End.Y);
                int endX = Math.Max(s.Start.X, s.End.X);
                int endY = Math.Max(s.Start.Y, s.End.Y);

                if (startX != endX && startY != endY) continue;
                for (int x = startX; x <= endX; x++)
                {
                    for (int y = startY; y <= endY; y++)
                    {
                        if (++map[x][y] == 2) ans++;
                    }
                }
            }

            Console.WriteLine(ans);
        }

        public void PartB(string[] lines)
        {
            List<Segment> segments = CreateSegments(lines);
            List<List<int>> map = InitMap(1000);

            int ans = 0;
            foreach (var s in segments)
            {

                int startX = Math.Min(s.Start.X, s.End.X);
                int startY = Math.Min(s.Start.Y, s.End.Y);
                int endX = Math.Max(s.Start.X, s.End.X);
                int endY = Math.Max(s.Start.Y, s.End.Y);
                if (startX != endX && startY != endY)
                {
                    int incX = s.Start.X > s.End.X ? -1 : 1;
                    int incY = s.Start.Y > s.End.Y ? -1 : 1;

                    for (int x = s.Start.X, y = s.Start.Y; x != s.End.X + incX; x += incX, y += incY)
                    {
                        if (++map[x][y] == 2) ans++;
                    }
                }
                else
                {
                    for (int x = startX; x <= endX; x++)
                    {
                        for (int y = startY; y <= endY; y++)
                        {
                            if (++map[x][y] == 2) ans++;
                        }
                    }
                }
            }

            Console.WriteLine(ans);
        }

        private static List<List<int>> InitMap(int size)
        {
            List<List<int>> map = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                List<int> row = new();
                for (int j = 0; j < size; j++)
                {
                    row.Add(0);
                }
                map.Add(row);
            }

            return map;
        }

        private static List<Segment> CreateSegments(string[] lines)
        {
            var segments = new List<Segment>();
            var points = lines.Select(line => line.Split(" -> ").Select(p => p.Split(",").Select(n => int.Parse(n)).ToArray()).ToArray()).ToArray();
            foreach (var seg in points)
            {
                segments.Add(new Segment(new Point(seg[0][0], seg[0][1]), new Point(seg[1][0], seg[1][1])));
            }

            return segments;
        }

        public struct Segment
        {
            public Segment(Point p1, Point p2)
            {
                Start = p1;
                End = p2;
            }
            public Point Start;
            public Point End;
        }

        public struct Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public int X, Y;
        }
    }
}
