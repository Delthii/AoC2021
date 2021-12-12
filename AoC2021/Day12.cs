using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day12
    {
        public void PartA(string[] lines)
        {
            var g = new Graph();
            foreach (var line in lines) g.InsertEdge(line);

            Console.WriteLine(g.GetNumberOfPathsA());
        }

        public void PartB(string[] lines)
        {
            var g = new Graph();
            foreach (var line in lines) g.InsertEdge(line);

            Console.WriteLine(g.GetNumberOfPathsB());
        }
    }

    public class Graph
    {
        Dictionary<string, Cave> caves = new();
        List<string> paths = new();
        public Graph()
        {
        }

        public int GetNumberOfPathsA()
        {
            RecA("start", new List<string>());

            return paths.Count;
        }

        public int GetNumberOfPathsB()
        {
            RecB("start", new List<string>());

            return paths.Count;
        }

        private void RecA(string caveStr, List<string> path)
        {
            path.Add(caveStr);
            if (caveStr == "end")
            {
                paths.Add(string.Join(",", path));
                return;
            }

            var cave = caves[caveStr];
            foreach (var n in cave.N)
            {
                if (n.Name == "start") continue;
                if (!n.Big)
                {
                    if (path.Contains(n.Name))
                    {
                        continue;
                    }
                }

                RecA(n.Name, path.ToList());
            }
        }

        private void RecB(string caveStr, List<string> path)
        {
            path.Add(caveStr);
            if (caveStr == "end")
            {
                paths.Add(string.Join(",", path));
                return;
            }

            var cave = caves[caveStr];
            foreach(var n in cave.N)
            {
                if (n.Name == "start") continue;
                if(!n.Big)
                {
                    if(path.Contains(n.Name) && path.Where(p => p[0] > 'Z').GroupBy(p => p).Any(g => g.Count() > 1))
                    {
                        continue;
                    }
                }

                RecB(n.Name, path.ToList());
            }
        }



        public void InsertEdge(string edge)
        {
            var split = edge.Split('-');
            var start = split[0];
            var end = split[1];
            var startCave = caves.ContainsKey(start) ? caves[start] : new Cave
            {
                Name = start,
                Big = start[0] < 'a',
                N = new List<Cave>()
            };

            var endCave = caves.ContainsKey(end) ? caves[end] : new Cave
            {
                Name = end,
                Big = end[0] < 'a',
                N = new List<Cave>()
            };
            
            startCave.N.Add(endCave);
            endCave.N.Add(startCave);

            if (!caves.ContainsKey(start)) caves[start] = startCave;
            if (!caves.ContainsKey(end)) caves[end] = endCave;
        }
    }

    public class Cave
    {
        public string Name;
        public bool Big;
        public List<Cave> N;
    }
}
