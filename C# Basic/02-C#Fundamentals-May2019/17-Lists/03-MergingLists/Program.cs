using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> input2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
           
            bool isSmaller = input1.Count < input2.Count;

            if (isSmaller)
            {
                for (int i = 0; i < input1.Count; i ++)
                {
                    result.Add(input1[i]);
                    result.Add(input2[i]);
                }

                for (int i = input1.Count; i < input2.Count; i++)
                {
                    result.Add(input2[i]);
                }

                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                for (int i = 0; i < input2.Count; i++)
                {
                    result.Add(input1[i]);
                    result.Add(input2[i]);
                }

                for (int i = input2.Count; i < input1.Count; i++)
                {
                    result.Add(input1[i]);
                }
                Console.WriteLine(string.Join(" ", result));
            }

        }
    }
}
