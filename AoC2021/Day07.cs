using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day07
    {
        public void PartA(string[] lines)
        {
            Solve(lines, (x) => x);
        }
        public void PartB(string[] lines)
        {
            Solve(lines, CalcFuel);
        }

        private static void Solve(string[] lines, Func<int, int> calcFuel)
        {
            var input = lines[0].Split(',').Select(str => int.Parse(str)).ToArray();
            var max = input.Max();
            var min = input.Min();
            var ans = int.MaxValue;
            for (int i = min; i <= max; i++)
            {
                int fuel = 0;
                foreach (var crab in input)
                {
                    fuel += calcFuel(Math.Abs(i - crab));
                }
                ans = Math.Min(ans, fuel);
            }
            Console.WriteLine(ans);
        }

        private int CalcFuel(int dist)
        {
            return (dist * (dist + 1)) / 2;
        }
    }
}
