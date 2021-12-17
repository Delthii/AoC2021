using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AoC2021
{
    public class Day17
    {
        public long PartA(string[] lines)
        {
            // target area: x = 192..251, y = -89..-59
            int x1 = 192, x2 = 251;
            int y1 = -89, y2 = -59;
            int ans = y1;
            return ans * (ans + 1) / 2;
        }

        private int PosWhenStopped(int value)
        {
            var untilStopped = value * (value + 1) / 2;
            return untilStopped;
        }

        public long PartB(string[] lines)
        {
            int x1 = 20, x2 = 30;
            int y1 = -10, y2 = -5;
            
            for(int x = 1; x <= x2; x++)
            {
                for(int y = y1; y <= -y1; ++y)
                {

                }
            }
        }
    }
}