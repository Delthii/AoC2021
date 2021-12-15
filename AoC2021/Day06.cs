using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day06
    {
        public int PartA(string[] lines)
        {
            var fishes = lines[0].Split(',').Select(l => int.Parse(l)).ToList();
            for(int i = 0; i < 80; ++i)
            {
                for(int j = 0; j < fishes.Count; ++j)
                {
                    if(fishes[j] == 0)
                    {
                        fishes[j] = 6;
                        fishes.Add(9);
                    }
                    else
                    {
                        --fishes[j];
                    }
                }
            }

            Console.WriteLine(fishes.Count);
            return fishes.Count;
        }

        public long PartB(string[] lines)
        {
            var fishes = lines[0].Split(',').Select(l => long.Parse(l)).ToList();

            var dict = new Dictionary<long, long>();
            for(int i = 0; i < 9; ++i)
            {
                dict[i] = 0;
            }

            foreach(var fish in fishes)
            {
                dict[fish]++;
            }

            for(int i = 0; i < 256; ++i)
            {
                var oldState = dict.ToDictionary(x => x.Key, x => x.Value);
                dict[8] = oldState[0];
                dict[7] = oldState[8];
                dict[6] = oldState[7] + oldState[0];
                dict[5] = oldState[6];
                dict[4] = oldState[5];
                dict[3] = oldState[4];
                dict[2] = oldState[3];
                dict[1] = oldState[2];
                dict[0] = oldState[1];
            }

            Console.WriteLine(dict.Values.Sum());
            return dict.Values.Sum();
        }

        
    }
}
