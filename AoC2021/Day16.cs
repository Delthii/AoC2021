using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AoC2021
{
    public class Day16
    {
        public long PartA(string[] lines)
        {
            var (versionSum, _) = new BITSComputer().Calculate(lines[0]);
            
            Console.WriteLine(versionSum);
            return versionSum;
        }

        public long PartB(string[] lines)
        {
            var (_, res) = new BITSComputer().Calculate(lines[0]);

            Console.WriteLine(res);
            return res;
        }
    }
}
