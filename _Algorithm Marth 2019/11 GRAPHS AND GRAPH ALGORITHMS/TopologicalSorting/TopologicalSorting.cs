using System;
using System.Collections.Generic;

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
        }
    }
}
