using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day01
    {
        public int PartA(string[] input)
        {
            var numbers = input.Select(x => int.Parse(x)).ToArray();
            int cnt = 0;

            for(int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1]) cnt++;
            }

            Console.WriteLine(cnt);
            return cnt;
        }

        public int PartB(string[] input)
        {
            var numbers = input.Select(x => int.Parse(x)).ToArray();
            int cnt = 0;

            for (int i = 3; i < numbers.Length; i++)
            {
                int sum1 = numbers[i - 3] + numbers[i - 2] + numbers[i - 1];
                int sum2 = numbers[i - 2] + numbers[i - 1] + numbers[i];
                if (sum2 > sum1) cnt++;
            }

            Console.WriteLine(cnt);
            return cnt;
        }
    }
}
