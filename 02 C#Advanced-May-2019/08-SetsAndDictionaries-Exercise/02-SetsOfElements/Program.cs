using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsCount = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] firstSet = new int[setsCount[0]];
            int[] secondSet = new int[setsCount[1]];
            List<int> repeatedNumbers = new List<int>();

            for (int i = 0; i < firstSet.Length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet[i] = number;
            }

            for (int i = 0; i < secondSet.Length; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet[i] = number;
            }

            for (int i = 0; i < firstSet.Length; i++)
            {
                if (secondSet.Contains(firstSet[i]))
                {
                    repeatedNumbers.Add(firstSet[i]);
                }
            }

            Console.WriteLine(string.Join(" ", repeatedNumbers));
        }
    }
}
