using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakCycles
{
    class Program
    { //06. Graphs-and-Graph-Algorithms-Homework.docx -> 05 Break Cycles
        static void Main(string[] args)
        {
            var graph = new SortedDictionary<char, List<char>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var edgeParts = line.Split();
                var node = edgeParts[0][0]; //Ако искаме само една буква от string да я вземем като char, може така -> [0][0]. На нулевото, нулевото един вид. Щото то незнае, че стринга е само от една буква.
                
                var otherNodes = edgeParts.Skip(2).ToArray();

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<char>();
                }

                graph[node].AddRange(otherNodes.Select(str => str[0]));
            }
        }


    }
}
