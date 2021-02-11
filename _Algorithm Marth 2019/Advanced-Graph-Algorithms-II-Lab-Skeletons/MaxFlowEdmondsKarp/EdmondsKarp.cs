using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EdmondsKarp
{
    private static int[][] graph;
    private static int[] parent;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        graph = targetGraph;
        parent = Enumerable.Repeat(-1, graph.Length).ToArray();

        var maxFLow = 0;
        var start = 0;
        var end = graph.Length - 1;

        while (Bfs(start, end))
        {
            int pathFlow = int.MaxValue;
            var currendNode = end;

            while (currendNode != start)
            {
                var prevNode = parent[currendNode];
                var currentFlow = graph[prevNode][currendNode];
                
                if (currentFlow > 0 && currentFlow < pathFlow)
                {
                    pathFlow = currentFlow;
                }

                currendNode = prevNode;
            }

            maxFLow += pathFlow;

            currendNode = end;

            while (currendNode != start)
            {
                var prevNode = parent[currendNode];

                graph[prevNode][currendNode] -= pathFlow;
                graph[currendNode][prevNode] += pathFlow;

                currendNode = prevNode;
            }
        }

        return maxFLow;
    }
    
    private static bool Bfs(int start, int end)
    {
        bool[] visited = new bool[graph.Length];
        
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            for (int child = 0; child < graph[node].Length; child++)
            {
                if (graph[node][child] > 0 && !visited[child])
                {
                    queue.Enqueue(child);
                    parent[child] = node;
                    visited[child] = true;
                }
            }
        }

        return visited[end];
    }
}
