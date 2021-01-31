using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting
{
    class TopologicalSorting
    {
        static List<int>[] graph;

        static void Main()
        {
            graph = new List<int>[]
            {
                new List<int>{ 1, 2, },
                new List<int>{ 3, 4, },
                new List<int>{ 5, },
                new List<int>{ 2, 5, },
                new List<int>{ 3, },
                new List<int>{ },
            };

            var result = new List<int>();
            var nodesWithoutIncommingEdges = new HashSet<int>();

            var nodesWithIncommingEdges = GetNodesWithIncommingEdges();

            for (int i = 0; i < graph.Length; i++)
            {
                if (!nodesWithIncommingEdges.Contains(i))
                {
                    nodesWithoutIncommingEdges.Add(i);
                }
            }

            while (nodesWithoutIncommingEdges.Count != 0)
            {
                int currentNode = nodesWithoutIncommingEdges.First();
                nodesWithoutIncommingEdges.Remove(currentNode);

                result.Add(currentNode);

                var childrenNodes = graph[currentNode].ToList();
                graph[currentNode] = new List<int>();

                var leftNodesWithIncommingEdges = GetNodesWithIncommingEdges();

                foreach (var childNode in childrenNodes)
                {
                    if (!leftNodesWithIncommingEdges.Contains(childNode))
                    {
                        nodesWithoutIncommingEdges.Add(childNode);
                    }
                }
            }

            if (graph.SelectMany(s => s).Any())
            {
                Console.WriteLine("Graph contains cycle.");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }

        static HashSet<int> GetNodesWithIncommingEdges()
        {
            var nodesWithIncommingEdges = new HashSet<int>();

            graph
                .SelectMany(s => s)
                .ToList()
                .ForEach(e => nodesWithIncommingEdges.Add(e));

            return nodesWithIncommingEdges;
        }
    }
}
