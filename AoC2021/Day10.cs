using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day10
    {
        public void PartA(string[] lines)
        {
            Dictionary<char, char> lookup = new Dictionary<char, char>();
            lookup[')'] = '(';
            lookup[']'] = '[';
            lookup['}'] = '{';
            lookup['>'] = '<';
            List<char> incorrect = new List<char>();
            foreach (var line in lines)
            {
                var stack = new Stack<char>();
                var correct = true;
                foreach(var c in line)
                {
                    if (!IsClosing(c, lookup))
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        correct = lookup[c] == stack.Peek();
                        if (correct)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            incorrect.Add(c);
                            break;
                        }
                    }
                }
                
            }
            Console.WriteLine(incorrect.Sum(x => ToInt(x)));
        }

        public void PartB(string[] lines)
        {
            Dictionary<char, char> lookup = new Dictionary<char, char>();
            lookup[')'] = '(';
            lookup[']'] = '[';
            lookup['}'] = '{';
            lookup['>'] = '<';
            List<char> incorrect = new List<char>();
            var ans = new List<long>();
            foreach (var line in lines)
            {
                var stack = new Stack<char>();
                var correct = true;
                foreach (var c in line)
                {
                    if (!IsClosing(c, lookup))
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        correct = lookup[c] == stack.Peek();
                        if (correct)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            incorrect.Add(c);
                            break;
                        }
                    }
                }
                if (correct)
                {
                    var reverseLookup = new Dictionary<char, char>();
                    var sum = 0L;
                    reverseLookup['('] = ')';
                    reverseLookup['['] = ']';
                    reverseLookup['{'] = '}';
                    reverseLookup['<'] = '>';
                    while (stack.Count > 0)
                    {
                        sum = sum * 5 + ToIntB(stack.Pop());
                    }
                    ans.Add(sum);
                }
            }
            ans.Sort();
            Console.WriteLine(ans[ans.Count / 2]);
        }

        private int ToInt(char c)
        {
            switch (c)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
                default:
                    throw new ArgumentException();
            }
        }

        private int ToIntB(char c)
        {
            switch (c)
            {
                case '(':
                    return 1;
                case '[':
                    return 2;
                case '{':
                    return 3;
                case '<':
                    return 4;
                default:
                    throw new ArgumentException();
            }
        }

        private bool IsClosing(char c, Dictionary<char, char> lookup)
        {
            return lookup.Keys.Contains(c);
        }
    }
}
