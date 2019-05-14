using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> array2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> result = new List<int>();

            int maxIndex = Math.Max(array1.Count, array2.Count);

            for (int i = 0; i < maxIndex; i++)
            {
                if (i < array1.Count)
                {
                    result.Add(array1[i]);
                }

                if (i < array2.Count)
                {
                    result.Add(array2[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
