using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class BITSComputer
    {
        private int stackPointer;
        private int versionSum;

        public BITSComputer()
        {
            stackPointer = 0;
            versionSum = 0;
        }

        public (int VersionSum, long Result) Calculate(string hexString)
        {
            var binary = string.Join(string.Empty,
              hexString.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
              )
            );
            var res = ParsePacket(binary);
            return (versionSum, res);
        }

        private long ParsePacket(string binarystring)
        {
            int version = ParsePacketVersion(binarystring);
            versionSum += version;
            var id = ParseId(binarystring);
            if (id == 4)
            {
                return HandleLiteral(binarystring);
            }
            else
            {
                return HandleOperator(binarystring, id);
            }
        }

        private long HandleOperator(string binarystring, int id)
        {
            switch (id)
            {
                case 0:
                    return GetValues(binarystring).Sum();
                case 1:
                    return GetValues(binarystring).Aggregate(1L, (acc, v) => acc * v);
                case 2:
                    return GetValues(binarystring).Min();
                case 3:
                    return GetValues(binarystring).Max();
                case 5:
                    var gvalues = GetValues(binarystring).ToArray();
                    if (gvalues.Length != 2) throw new Exception("Greater than packets most only have 2 sub packets");
                    return gvalues[0] > gvalues[1] ? 1 : 0;
                case 6:
                    var lvalues = GetValues(binarystring).ToArray();
                    if (lvalues.Length != 2) throw new Exception("Less than packets most only have 2 sub packets");
                    return lvalues[0] < lvalues[1] ? 1 : 0;
                case 7:
                    var evalues = GetValues(binarystring).ToArray();
                    if (evalues.Length != 2) throw new Exception("Equal to packets most only have 2 sub packets");
                    return evalues[0] == evalues[1] ? 1 : 0;

                default: throw new Exception("Unknown id");
            }
        }

        private IEnumerable<long> GetValues(string binarystring)
        {
            var len = binarystring[stackPointer] == '1' ? 11 : 15;
            stackPointer++;
            if (len == 11)
            {
                var numberOfPackets = Convert.ToInt32(binarystring.Substring(stackPointer, len), 2);
                stackPointer += len;
                for (int p = 0; p < numberOfPackets; p++)
                {
                    yield return ParsePacket(binarystring);
                }
            }
            else if (len == 15)
            {
                var packetLen = Convert.ToInt32(binarystring.Substring(stackPointer, len), 2);
                stackPointer += len;
                var target = stackPointer + packetLen;
                while (stackPointer < target)
                {
                    yield return ParsePacket(binarystring);
                }
            }
        }

        private long HandleLiteral(string binarystring)
        {
            string literal = "";
            while (binarystring[stackPointer] == '1')
            {
                literal += binarystring.Substring(stackPointer + 1, 4);
                stackPointer += 5;
            }
            literal += binarystring.Substring(stackPointer + 1, 4);
            stackPointer += 5;

            return Convert.ToInt64(literal, 2);
        }

        private int ParsePacketVersion(string binarystring)
        {
            int offset = 3;
            var version = Convert.ToInt32(binarystring.Substring(stackPointer, offset), 2);
            stackPointer += offset;
            return version;
        }

        private int ParseId(string binarystring)
        {
            int offset = 3;
            var id = Convert.ToInt32(binarystring.Substring(stackPointer, offset), 2);
            stackPointer += offset;
            return id;
        }
    }
}
