using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day08Take2
    {
        public void PartA(string[] lines)
        {
        }

        public void PartB(string[] lines)
        {
            var inp = lines.Select(line => line.Split(" | ")).Select(split => (input: split[0].Split(' '), output: split[1].Split(' '))).ToArray();
            var sum = 0;
            foreach(var (input, output) in inp)
            {
                var strToInt = new Dictionary<string, int>();
                var intToStr = new Dictionary<int, string>();
                Calc1478(input, strToInt, intToStr);
                CalcLen5(input, strToInt, intToStr);
                CalcLen6(input, strToInt, intToStr);

                var ans = output
                    .Select(digit => strToInt.Keys.Where(str => str.Length == digit.Length && str.Intersect(digit).Count() == digit.Length)
                        .Single())
                    .Select(digit => strToInt[digit])
                    .Aggregate("", (acc, c) => acc + c);

                sum += int.Parse(ans);
            }
            Console.WriteLine(sum);
        }

        private static void CalcLen6(string[] input, Dictionary<string, int> strToInt, Dictionary<int, string> intToStr)
        {
            var len6 = input.Where(x => x.Length == 6).ToList();

            var nine = len6.Where(x => x.Intersect(intToStr[4]).Count() == intToStr[4].Length).Single();
            strToInt[nine] = 9;
            intToStr[9] = nine;
            len6.Remove(nine);

            var zero = len6.Where(x => x.Intersect(intToStr[7]).Count() == intToStr[7].Length).Single();
            strToInt[zero] = 0;
            intToStr[0] = zero;
            len6.Remove(zero);

            var six = len6.Single();
            strToInt[six] = 6;
            intToStr[6] = six;
        }

        private static void CalcLen5(string[] input, Dictionary<string, int> strToInt, Dictionary<int, string> intToStr)
        {
            var len5 = input.Where(x => x.Length == 5).ToList();

            var three = len5.Where(x => x.Intersect(intToStr[1]).Count() == 2).Single();
            len5.Remove(three);
            strToInt[three] = 3;
            intToStr[3] = three;

            var diff = new string(intToStr[8].Where(c => !intToStr[4].Contains(c)).ToArray());

            var two = input.Where(x => x.Length == 5 && x.Intersect(diff).Count() == diff.Length).Single();
            len5.Remove(two);
            strToInt[two] = 2;
            intToStr[2] = two;

            var five = len5.Single();
            strToInt[five] = 5;
            intToStr[5] = five;
        }

        private static void Calc1478(string[] input, Dictionary<string, int> strToInt, Dictionary<int, string> intToStr)
        {
            foreach (var digit in input)
            {
                switch (digit.Length)
                {
                    case (2):
                        strToInt[digit] = 1;
                        intToStr[1] = digit;
                        break;
                    case (3):
                        strToInt[digit] = 7;
                        intToStr[7] = digit;
                        break;
                    case (4):
                        strToInt[digit] = 4;
                        intToStr[4] = digit;
                        break;
                    case (7):
                        strToInt[digit] = 8;
                        intToStr[8] = digit;
                        break;
                }
            }
        }
    }
}