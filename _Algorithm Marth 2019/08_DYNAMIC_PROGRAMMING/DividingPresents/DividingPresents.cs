using System;
using System.Linq;

namespace DividingPresents
{
    class DividingPresents
    {
        static void Main()
        {
            int[] presents = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            int totalSum = presents.Sum();

            int[] sums = new int[totalSum + 1];

            for (int i = 1; i < sums.Length; i++)
            {
                sums[i] = -1;
            }

            for (int presIndex = 0; presIndex < presents.Length; presIndex++)
            {
                for (int prevSumIndex = totalSum - presents[presIndex]; prevSumIndex >= 0; prevSumIndex--)
                {
                    int presentValue = presents[presIndex];

                    if (sums[prevSumIndex] != -1 && sums[prevSumIndex + presentValue] == -1)
                    {
                        sums[prevSumIndex + presentValue] = presIndex;
                    }
                }
            }

            int halfSum = totalSum / 2;

            for (int i = halfSum - 1; i >= 0; i--)
            {
                if (sums[i] == -1)
                {
                    continue;
                }

                Console.WriteLine($"Difference: {totalSum - i - i}");
                Console.WriteLine($"Alan:{i} Bob:{totalSum - i}");
                Console.Write("Alan takes:");

                while (i != 0)
                {
                    Console.Write($" {presents[sums[i]]}");
                    i -= presents[sums[i]];
                }

                Console.WriteLine();
                Console.WriteLine("Bob takes the rest.");
            }
        }
    }
}
