using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day04
    {
        public void PartA(string[] lines)
        {
            var draws = lines[0].Split(",").Select(x => int.Parse(x)).ToArray();
            List<Brick> bricks = InitBricks(lines);

            for(int i = 0; i < draws.Length; i++)
            {
                foreach(var b in bricks)
                {
                    if (b.Mark(draws[i]))
                    {
                        Console.WriteLine(b.Calc(draws[i]));
                        return;
                    }
                }
            }

        }

        public void PartB(string[] lines)
        {
            var draws = lines[0].Split(",").Select(x => int.Parse(x)).ToArray();
            List<Brick> bricks = InitBricks(lines);

            int ans = 0;
            for (int i = 0; i < draws.Length; i++)
            {
                List<Brick> temp = new();
                foreach (var b in bricks)
                {
                    if (b.Mark(draws[i]))
                    {
                        ans = b.Calc(draws[i]);
                    }
                    else
                    {
                        temp.Add(b);
                    }
                }
                bricks = temp;
            }
            Console.WriteLine(ans);
        }

        private static List<Brick> InitBricks(string[] lines)
        {
            var bingoBricks = lines.Skip(2).Where(line => !string.IsNullOrEmpty(line)).ToArray();
            List<Brick> bricks = new();
            for (int i = 0; i < bingoBricks.Length;)
            {
                List<List<int>> numbers = new();
                for (int j = 0; j < 5; j++, i++)
                {
                    numbers.Add(bingoBricks[i].Split(" ").Where(e => !string.IsNullOrEmpty(e)).Select(s => int.Parse(s)).ToList());
                }
                bricks.Add(new Brick(numbers));
            }

            return bricks;
        }

        public class Brick
        {
            List<List<int>> brick;

            public Brick(List<List<int>> numbers)
            {
                brick = numbers;
            }

            public bool Mark(int number)
            {
                for(int i = 0; i < 5; ++i)
                {
                    for(int j = 0; j < 5; j++)
                    {
                        if(brick[i][j] == number)
                        {
                            brick[i][j] = -1;

                            int marks = 0;
                            for(int r = 0; r < 5; ++r)
                            {
                                marks += brick[i][r];
                            }

                            if (marks == -5)
                            {
                                return true;
                            }

                            marks = 0;
                            for (int r = 0; r < 5; ++r)
                            {
                                marks += brick[r][j];
                            }
                            if (marks == -5)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            public int Calc(int draw)
            {
                int sum = 0;
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if(brick[i][j] >= 0)
                        {
                            sum += brick[i][j];
                        }
                    }
                }

                return sum * draw;
            }
        }
    }
}
