using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static int[] depths;
    private static int[] lowpoint;
    private static int?[] parent;

    private static List<int> articulationPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[targetGraph.Length];
        depths = new int[targetGraph.Length];
        lowpoint = new int[targetGraph.Length];
        parent = new int?[targetGraph.Length];
        articulationPoints = new List<int>();
    }

    private static void FindArticulationPoints(int node, int depth)
    {
        visited[node] = true;
        depths[node] = depth;
        lowpoint[node] = depth;

        int childCount = 0;
        bool isArticulationPoint = false;

        foreach (var child in graph[node])
        {
            if (!visited[child])
            {

            }
            else if (child != parent[node])
            {

            }
        }
    }
}
