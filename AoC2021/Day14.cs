using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day14
    {
        public void PartA(string[] lines)
        {
            string poly = lines[0];
            Dictionary<string, string> rules = new Dictionary<string, string>();
            foreach (var rule in lines.Skip(2))
            {
                var split = rule.Split(" -> ");
                rules[split[0]] = split[1];
            }

            var dict = new Dictionary<string, long>();
            for (int i = 0; i < poly.Length - 1; ++i)
            {
                var pair = poly.Substring(i, 2);
                if (!dict.ContainsKey(pair))
                {
                    dict[pair] = 1;
                }
                else
                {
                    dict[pair]++;
                }
            }
            DoIt(poly, rules, dict, 10);
        }

        public void PartB(string[] lines)
        {

            string poly = lines[0];
            Dictionary<string, string> rules = new Dictionary<string, string>();
            foreach (var rule in lines.Skip(2))
            {
                var split = rule.Split(" -> ");
                rules[split[0]] = split[1];
            }

            var dict = new Dictionary<string, long>();
            for (int i = 0; i < poly.Length - 1; ++i)
            {
                var pair = poly.Substring(i, 2);
                if (!dict.ContainsKey(pair))
                {
                    dict[pair] = 1;
                }
                else
                {
                    dict[pair]++;
                }
            }
            DoIt(poly, rules, dict, 40);
        }

        private static void DoIt(string poly, Dictionary<string, string> rules, Dictionary<string, long> dict, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                var newDict = new Dictionary<string, long>();
                foreach (var pair in dict.ToArray())
                {
                    var p1 = pair.Key[0] + rules[pair.Key];
                    if (!newDict.ContainsKey(p1))
                    {
                        newDict[p1] = pair.Value;
                    }
                    else
                    {
                        newDict[p1] += pair.Value;
                    }
                    var p2 = rules[pair.Key] + pair.Key[1];
                    if (!newDict.ContainsKey(p2))
                    {
                        newDict[p2] = pair.Value;
                    }
                    else
                    {
                        newDict[p2] += pair.Value;
                    }
                }
                dict = newDict;
            }
            var counts = new Dictionary<char, long>();
            foreach (var kv in dict.ToArray())
            {
                if (!counts.ContainsKey(kv.Key[0]))
                {
                    counts[kv.Key[0]] = kv.Value;
                }
                else
                {
                    counts[kv.Key[0]] += kv.Value;
                }

                if (!counts.ContainsKey(kv.Key[1]))
                {
                    counts[kv.Key[1]] = kv.Value;
                }
                else
                {
                    counts[kv.Key[1]] += kv.Value;
                }
            }
            counts[poly[^1]]++;

            var max = counts.Values.Max();
            var min = counts.Values.Min();

            Console.WriteLine(max / 2 - min / 2);
        }
    }
}
