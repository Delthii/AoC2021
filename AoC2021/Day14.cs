using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AoC2021
{
    public class Day14
    {
        public long PartA(string[] lines)
        {
            return DoIt(lines, 10);
        }
        public long PartB(string[] lines)
        {
            return DoIt(lines, 40);
        }

        private static long DoIt(string[] lines, int iterations)
        {
            string poly = lines[0];
            Dictionary<string, string> rules = new Dictionary<string, string>();
            foreach (var rule in lines.Skip(2))
            {
                var split = rule.Split(" -> ");
                rules[split[0]] = split[1];
            }

            var multiset = new MultiSet<string>();
            for (int i = 0; i < poly.Length - 1; ++i)
            {
                var pair = poly.Substring(i, 2);
                multiset[pair]++;
            }

            for (int i = 0; i < iterations; i++)
            {
                var newMultiSet = new MultiSet<string>();
                foreach (var pair in multiset.ToArray())
                {
                    var p1 = pair.Key[0] + rules[pair.Key];
                    newMultiSet[p1] += pair.Value;
                    var p2 = rules[pair.Key] + pair.Key[1];
                    newMultiSet[p2] += pair.Value;
                }
                multiset = newMultiSet;
            }

            var counts = new MultiSet<char>();
            foreach (var kv in multiset.ToArray())
            {
                counts[kv.Key[0]] += kv.Value;
            }
            counts[poly[^1]]++;

            var max = counts.Values.Max();
            var min = counts.Values.Min();

            Console.WriteLine(max - min);
            return max - min;
        }
    }
}
