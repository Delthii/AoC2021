using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day03
    {
        public int PartA(string[] lines)
        {
            int[] bitCounts = new int[lines[0].Length];
            for(int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    if(lines[i][j] == '1')
                    {
                        bitCounts[j]++;
                    }
                }
            }
            var gammaStr = "";
            var epsilonStr = "";
            var maxBits = lines.Length;
            for(int i = 0; i < bitCounts.Length; i++)
            {
                if(bitCounts[i] > maxBits / 2)
                {
                    gammaStr += "1";
                    epsilonStr += "0";
                }
                else
                {
                    gammaStr += "0";
                    epsilonStr += "1";
                }
            }

            Console.WriteLine(Convert.ToInt32(gammaStr, 2) * Convert.ToInt32(epsilonStr, 2));
            return Convert.ToInt32(gammaStr, 2) * Convert.ToInt32(epsilonStr, 2);
        }

        public int PartB(string[] lines)
        {
            var numbers = DoStuff(lines.ToList(), true);
            var oxygen = Convert.ToInt32(numbers[0], 2);

            numbers = DoStuff(lines.ToList(), false);
            var co2 = Convert.ToInt32(numbers[0], 2);

            Console.WriteLine(oxygen * co2);
            return oxygen * co2;
        }

        private static List<string> DoStuff(List<string> numbers, bool oxygen)
        {
            for (int i = 0; numbers.Count > 1 && i < numbers[0].Length; i++)
            {
                var ones = 0;
                var zeroes = 0;

                for (int j = 0; j < numbers.Count; j++)
                {

                    if (numbers[j][i] == '1')
                    {
                        ones++;
                    }
                    else
                    {
                        zeroes++;
                    }
                }

                char bit = oxygen ? (ones >= zeroes ? '1' : '0') : (zeroes <= ones ? '0' : '1');
                var newList = new List<string>();

                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j][i] == bit)
                    {
                        newList.Add(numbers[j]);
                    }
                }
                numbers = newList;
            }

            return numbers;
        }
    }
}
