﻿using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace PrimsAlgorithm
{
    class PrimsAlgorithm
    {
        static HashSet<int> spanningTrree = new HashSet<int>();      
        
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

            foreach (var node in nodes)
            {
                if (!spanningTrree.Contains(node))
                {
                    Prim(node);
                }
            }
        }

        static void Prim(int startingNode)
        {
            spanningTrree.Add(startingNode);

            var priorityQueue = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.EdgeWeight - s.EdgeWeight));

            priorityQueue.AddMany(nodeToEdges[startingNode]);

            while (priorityQueue.Count != 0)
            {
                var minEdge = priorityQueue.GetFirst();
                priorityQueue.Remove(minEdge);

                var firstNode = minEdge.FirstNode;
                var secondNode = minEdge.SecondNode;

                var nonTreeNode = -1;

                if (spanningTrree.Contains(firstNode) 
                    && !spanningTrree.Contains(secondNode))
                {
                    nonTreeNode = secondNode;
                }

                if (spanningTrree.Contains(secondNode)
                    && !spanningTrree.Contains(firstNode))
                {
                    nonTreeNode = firstNode;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                spanningTrree.Add(nonTreeNode);

                Console.WriteLine($"{minEdge.FirstNode} - {minEdge.SecondNode}");

                priorityQueue.AddMany(nodeToEdges[nonTreeNode]);
            }
        }
    }
}
