using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day08
    {
        public void PartA(string[] lines)
        {
            var inp = lines.Select(line => line.Split(" | ")).Select(split => (input: split[0].Split(' '), output: split[1].Split(' '))).ToArray();
            int ans = 0;
            foreach(var r in inp.Select(i => i.output))
            {
                foreach(var l in r)
                if (l.Length == 7 || l.Length == 4 || l.Length == 3 || l.Length == 2) ans++;
            }
            Console.WriteLine(ans);
        }

        public void PartB(string[] lines)
        {
            var inp = lines.Select(line => line.Split(" | ")).Select(split => (input: split[0].Split(' '), output: split[1].Split(' '))).ToArray();
            int superans = 0;
            foreach (var row in inp)
            {
                foreach (var ddd in Digit.All)
                {
                    ddd.Clear();
                }
                foreach (var digit in row.input.Concat(row.output))
                {
                    if (digit.Length == 2)
                    {
                        foreach (var d in digit) Digit.One.Add(d);
                    }
                    if (digit.Length == 3)
                    {
                        foreach (var d in digit) Digit.Seven.Add(d);
                    }
                    if (digit.Length == 4)
                    {
                        foreach (var d in digit) Digit.Four.Add(d);
                    }
                    if (digit.Length == 5)
                    {
                        foreach (var d in digit)
                        {
                            Digit.Two.Add(d);
                            Digit.Three.Add(d);
                            Digit.Five.Add(d);
                        }

                    }
                    if (digit.Length == 6)
                    {
                        foreach (var d in digit)
                        {
                            Digit.Zero.Add(d);
                            Digit.Six.Add(d);
                            Digit.Nine.Add(d);
                        }

                    }
                    if (digit.Length == 7)
                    {
                        foreach (var d in digit) Digit.Eight.Add(d);
                    }
                }

                var dict = new Dictionary<char, HashSet<char>>();
                dict['a'] = Intersect(0, 2, 3, 5, 6, 7, 8, 9);
                dict['b'] = Intersect(0, 4, 5, 6, 8, 9);
                dict['c'] = Intersect(0, 1, 2, 3, 4, 7, 8, 9);
                dict['d'] = Intersect(2, 3, 4, 5, 6, 8, 9);
                dict['e'] = Intersect(0, 2, 6, 8);
                dict['f'] = Intersect(0, 1, 3, 4, 5, 6, 7, 8, 9);
                dict['g'] = Intersect(0, 2, 3, 5, 6, 8, 9);


                for (char a = 'a'; a <= 'g'; a++)
                {
                    if (a == 'c' || a == 'f') continue;
                    foreach (var c in dict['c'])
                    {
                        dict[a].Remove(c);
                    }
                    foreach (var c in dict['f'])
                    {
                        dict[a].Remove(c);
                    }
                }

                for (char a = 'b'; a <= 'g'; a++)
                {
                    foreach (var c in dict['a'])
                    {
                        dict[a].Remove(c);
                    }
                }

                for (char a = 'a'; a <= 'g'; a++)
                {
                    if (a == 'b' || a == 'd') continue;
                    foreach (var c in dict['b'])
                    {
                        dict[a].Remove(c);
                    }
                    foreach (var c in dict['d'])
                    {
                        dict[a].Remove(c);
                    }
                }
                var correctDict = new Dictionary<char, char>();
                for(int i = 0; i < 8; i++)
                {
                    var a = dict['a'].OrderBy(c => c).ToArray()[0];
                    var b = dict['b'].OrderBy(c => c).ToArray()[(i & 0b001) > 0 ? 1 : 0];
                    var c = dict['c'].OrderBy(c => c).ToArray()[(i & 0b010) > 0 ? 1 : 0];
                    var d = dict['d'].OrderBy(c => c).ToArray()[(i & 0b001) > 0 ? 0 : 1];
                    var e = dict['e'].OrderBy(c => c).ToArray()[(i & 0b100) > 0 ? 1 : 0];
                    var f = dict['f'].OrderBy(c => c).ToArray()[(i & 0b010) > 0 ? 0 : 1];
                    var g = dict['g'].OrderBy(c => c).ToArray()[(i & 0b100) > 0 ? 0 : 1];
                    var valid = true;
                    for(int j = 0; j < row.input.Length; j++)
                    {
                        var temp = row.input[j].ToArray();
                        for (int k = 0; k < temp.Length; k++)
                        {
                            if(temp[k] == a)
                            {
                                temp[k] = 'a';
                            }
                            else if (temp[k] == b)
                            {
                                temp[k] = 'b';
                            }
                            else if (temp[k] == c)
                            {
                                temp[k] = 'c';
                            }
                            else if (temp[k] == d)
                            {
                                temp[k] = 'd';
                            }
                            else if (temp[k] == e)
                            {
                                temp[k] = 'e';
                            }
                            else if (temp[k] == f)
                            {
                                temp[k] = 'f';
                            }
                            else if (temp[k] == g)
                            {
                                temp[k] = 'g';
                            }
                        }
                        if (!ValidDigit(temp))
                        {
                            valid = false;
                            break;
                        }
                        
                    }
                    if (valid)
                    {
                        correctDict['a'] = a;
                        correctDict['b'] = b;
                        correctDict['c'] = c;
                        correctDict['d'] = d;
                        correctDict['e'] = e;
                        correctDict['f'] = f;
                        correctDict['g'] = g;
                        break;
                    }
                }

                var ans = "";
                foreach(var output in row.output)
                {
                    var temp = output.ToArray();
                    for (int k = 0; k < temp.Length; k++)
                    {
                        if (temp[k] == correctDict['a'])
                        {
                            temp[k] = 'a';
                        }
                        else if (temp[k] == correctDict['b'])
                        {
                            temp[k] = 'b';
                        }
                        else if (temp[k] == correctDict['c'])
                        {
                            temp[k] = 'c';
                        }
                        else if (temp[k] == correctDict['d'])
                        {
                            temp[k] = 'd';
                        }
                        else if (temp[k] == correctDict['e'])
                        {
                            temp[k] = 'e';
                        }
                        else if (temp[k] == correctDict['f'])
                        {
                            temp[k] = 'f';
                        }
                        else if (temp[k] == correctDict['g'])
                        {
                            temp[k] = 'g';
                        }
                    }
                    ans += ToDigit(temp);
                }
                superans += int.Parse(ans);
            }
            Console.WriteLine(superans);
        }

        public int ToDigit(params char[] positions)
        {
            if (positions.Length == 7 && positions.Intersect("abcdefg").Count() == 7) return 8;
            if (positions.Length == 6 && positions.Intersect("abcefg").Count() == 6) return 0;
            if (positions.Length == 6 && positions.Intersect("abdefg").Count() == 6) return 6;
            if (positions.Length == 2 && positions.Intersect("cf").Count() == 2) return 1;
            if (positions.Length == 5 && positions.Intersect("acdeg").Count() == 5) return 2;
            if (positions.Length == 5 && positions.Intersect("acdfg").Count() == 5) return 3;
            if (positions.Length == 4 && positions.Intersect("bcdf").Count() == 4) return 4;
            if (positions.Length == 5 && positions.Intersect("abdfg").Count() == 5) return 5;
            if (positions.Length == 3 && positions.Intersect("acf").Count() == 3) return 7;
            if (positions.Length == 6 && positions.Intersect("abcdfg").Count() == 6) return 9;

            throw new Exception("Not a digit");
        }

        public bool ValidDigit(params char[] positions)
        {
            if (positions.Length == 6 && positions.Intersect("abcefg").Count() == 6) return true;
            if (positions.Length == 2 && positions.Intersect("cf").Count() == 2) return true;
            if (positions.Length == 5 && positions.Intersect("acdeg").Count() == 5) return true;
            if (positions.Length == 5 && positions.Intersect("acdfg").Count() == 5) return true;
            if (positions.Length == 4 && positions.Intersect("bcdf").Count() == 4) return true;
            if (positions.Length == 5 && positions.Intersect("abdfg").Count() == 5) return true;
            if (positions.Length == 6 && positions.Intersect("abdefg").Count() == 6) return true;
            if (positions.Length == 3 && positions.Intersect("acf").Count() == 3) return true;
            if (positions.Length == 7 && positions.Intersect("abcdefg").Count() == 7) return true;
            if (positions.Length == 6 && positions.Intersect("abcdfg").Count() == 6) return true;
            return false;
        }

        public HashSet<char> Intersect(params int[] digits)
        {
            var hs = Digit.All.SelectMany(x => x).ToHashSet();
            foreach (var digit in digits)
            {
                hs.IntersectWith(Digit.All[digit]);
            }
            return hs;
        }

        public static class Digit
        {
            public static HashSet<char> Zero { get; set; } = new();
            public static HashSet<char> One { get; set; } = new();
            public static HashSet<char> Two { get; set; } = new();
            public static HashSet<char> Three { get; set; } =    new();
            public static HashSet<char> Four { get; set; } =     new();
            public static HashSet<char> Five { get; set; } = new();
            public static HashSet<char> Six { get; set; } = new();
            public static HashSet<char> Seven { get; set; } = new();
            public static HashSet<char> Eight { get; set; } = new();
            public static HashSet<char> Nine { get; set; } =     new();
            public static List<HashSet<char>> All => new List<HashSet<char>> {Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine};
        }
    }
}
