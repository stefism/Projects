using System;
using System.Collections.Generic;
using System.Linq;

namespace Kruskal_sAlgorithm
{
    class KruskalsAlgorithm
    {
        static int[] parents;

        static void Main()
        {
            var graphChars = new List<EdgeChars>
            {
                new EdgeChars {FirstNode = 'A', SecondNode = 'B', EdgeWeight = 4},
                new EdgeChars {FirstNode = 'A', SecondNode = 'C', EdgeWeight = 5},
                new EdgeChars {FirstNode = 'B', SecondNode = 'D', EdgeWeight = 2},
                new EdgeChars {FirstNode = 'A', SecondNode = 'D', EdgeWeight = 9},
                new EdgeChars {FirstNode = 'C', SecondNode = 'D', EdgeWeight = 20},
                new EdgeChars {FirstNode = 'C', SecondNode = 'E', EdgeWeight = 7},
                new EdgeChars {FirstNode = 'D', SecondNode = 'E', EdgeWeight = 8},
                new EdgeChars {FirstNode = 'E', SecondNode = 'F', EdgeWeight = 12},
                new EdgeChars {FirstNode = 'H', SecondNode = 'G', EdgeWeight = 8},
                new EdgeChars {FirstNode = 'H', SecondNode = 'I', EdgeWeight = 7},
                new EdgeChars {FirstNode = 'G', SecondNode = 'I', EdgeWeight = 10},
            };

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
                .Distinct() // И вземи уникалните
                .ToList();

            parents = new int[nodes.Max() + 1];

            foreach (var node in nodes)
            {
                parents[node] = node;
            }

            var edges = graph.OrderBy(e => e.EdgeWeight).ToHashSet();

            while (edges.Count != 0)
            {
                var edge = edges.First();
                edges.Remove(edge);

                var firstNode = edge.FirstNode;
                var secondNode = edge.SecondNode;

                var firstRoot = FindRoot(firstNode);
                var secondRoot = FindRoot(secondNode);

                if (firstRoot != secondRoot)
                {
                    Console.WriteLine($"{firstNode} - {secondNode}");
                    parents[firstRoot] = secondRoot;
                }
            }         
        }

        static int FindRoot(int node)
        {
            while (parents[node] != node)
            {
                node = parents[node];
            }

            return node;
        }
    }
}
