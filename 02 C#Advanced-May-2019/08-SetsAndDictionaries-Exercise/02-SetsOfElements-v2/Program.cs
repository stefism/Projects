using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_SetsOfElements_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsCount = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstSetCount = setsCount[0];
            int secondSetCount = setsCount[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                firstSet.Add(currentNumber);
            }

            for (int i = 0; i < secondSetCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                secondSet.Add(currentNumber);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
