using System;
using System.Collections.Generic;

namespace Graph
{
    class Graph
    {
        static bool[] visited;
        static List<int>[] graph;

        static void DepthFirstSearch(int graphNode)
        {
            if (!visited[graphNode])
            {
                visited[graphNode] = true;

                foreach (var childNode in graph[graphNode])
                {
                    DepthFirstSearch(childNode);
                }

                Console.Write($"{graphNode} ");
            }
        }

        static void BreadthFirstSearch(int graphNode)
        {
            //If we using Stack instead Queue, we implement iterative DepthFirstSearch approach.

            if (visited[graphNode])
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(graphNode);
            visited[graphNode] = true;

            while (queue.Count != 0)
            {
                int currentNode = queue.Dequeue();
                Console.Write($"{currentNode} ");

                foreach (var child in graph[currentNode])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        static void Main()
        {
            graph = new List<int>[] //without directions between nodes
            {
                new List<int> { 3, 6, },
                new List<int> { 2, 3, 4, 5, 6, },
                new List<int> { 1, 4, 5, },
                new List<int> { 0, 1, 5, },
                new List<int> { 1, 2, 6, },
                new List<int> { 1, 2, 3, },
                new List<int> { 0, 1, 4, },
            };

            visited = new bool[graph.Length];

            for (int graphNode = 0; graphNode < graph.Length; graphNode++)
            {
                //DepthFirstSearch(graphNode);
                BreadthFirstSearch(graphNode);
            }
        }
    }
}
