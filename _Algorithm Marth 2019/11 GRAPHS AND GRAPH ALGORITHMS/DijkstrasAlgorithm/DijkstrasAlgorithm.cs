using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace DijkstrasAlgorithm
{
    class DijkstrasAlgorithm
    {
        static Dictionary<int, List<Edge>> nodeToEdges = new Dictionary<int, List<Edge>>();

        static void Main()
        {
            var graph = new List<Edge>
            {
                new Edge {FirstNode = 2, SecondNode = 4, EdgeWeight = 2},
                new Edge {FirstNode = 1, SecondNode = 4, EdgeWeight = 9},
                new Edge {FirstNode = 3, SecondNode = 5, EdgeWeight = 7},
                new Edge {FirstNode = 4, SecondNode = 5, EdgeWeight = 8},
                new Edge {FirstNode = 8, SecondNode = 9, EdgeWeight = 7},
                new Edge {FirstNode = 1, SecondNode = 2, EdgeWeight = 4},
                new Edge {FirstNode = 5, SecondNode = 6, EdgeWeight = 12},
                new Edge {FirstNode = 7, SecondNode = 8, EdgeWeight = 8},
                new Edge {FirstNode = 7, SecondNode = 9, EdgeWeight = 10},
                new Edge {FirstNode = 1, SecondNode = 3, EdgeWeight = 5},
                new Edge {FirstNode = 3, SecondNode = 4, EdgeWeight = 20},
            };

            var nodes = graph
                .Select(e => e.FirstNode) // Селектирай всички първи
                .Union(graph.Select(e => e.SecondNode)) // Обедини ги с вторите
                .Distinct()
                .OrderBy(e => e)
                .ToHashSet();

            foreach (var edge in graph)
            {
                if (!nodeToEdges.ContainsKey(edge.FirstNode))
                {
                    nodeToEdges[edge.FirstNode] = new List<Edge>();
                }

                if (!nodeToEdges.ContainsKey(edge.SecondNode))
                {
                    nodeToEdges[edge.SecondNode] = new List<Edge>();
                }

                nodeToEdges[edge.FirstNode].Add(edge);
                nodeToEdges[edge.SecondNode].Add(edge);
            }

            var distances = new int[nodes.Max() + 1];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[nodes.First()] = 0;

            var queue = new SortedSet<int>(Comparer<int>
                .Create((f, s) => distances[f] - distances[s]));

            queue.Add(nodes.First());

            while (queue.Count != 0)
            {
                var min = queue.Min();
                queue.Remove(min);

                foreach (var edge in nodeToEdges[min])
                {
                    var otherNode = edge.FirstNode == min
                        ? edge.SecondNode
                        : edge.FirstNode;

                    if (distances[otherNode] == int.MaxValue)
                    {
                        queue.Add(otherNode);
                    }

                    var newDistance = distances[min] + edge.EdgeWeight;

                    if (newDistance < distances[otherNode])
                    {
                        distances[otherNode] = newDistance;
                        queue = new SortedSet<int>(queue, Comparer<int>
                                .Create((f, s) => distances[f] - distances[s]));
                    }
                }
            }
        }
    }
}