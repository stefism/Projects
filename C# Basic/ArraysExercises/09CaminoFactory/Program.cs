using System;
using System.Linq;

namespace _09CaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            int longestSubsequence = -1; // Колко е дължината на най-дългата под поредица.
            int longestSubIndex = -1; // Колко е индекса на най-дългата под поредица.
            int longestSubSum = -1; // Колко е сумата на всички единици в целия масив.
            int indexOfLongest = 0; // Номера на масива.

            int[] sequence = new int[lenght];

            string input = Console.ReadLine();

            int indexOfSequence = 1;

            while (input != "Clone them!")
            {
                int[] currentSequence = input.
                    Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int subSequence = 0;
                int subIndex = -1;
                int subSum = 0;

                int count = 0;

                for (int i = 0; i < lenght; i++)
                {
                    if (currentSequence[i] == 1)
                    {
                        count++;
                        subSum++;
                        if (count > subSequence)
                        {
                            subSequence = count;
                            subIndex = i - count;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }

                if (subSequence > longestSubsequence)
                {
                    longestSubIndex = subIndex;
                    longestSubsequence = subSequence;
                    longestSubSum = subSum;
                    sequence = currentSequence;
                    indexOfLongest = indexOfSequence;
                }
                else if (subSequence == longestSubsequence && longestSubIndex > subIndex)
                {
                    longestSubIndex = subIndex;
                    longestSubSum = subSum;
                    sequence = currentSequence;
                    indexOfLongest = indexOfSequence;
                }
                else if (subSequence == longestSubsequence 
                    && longestSubIndex ==  subIndex && longestSubSum < subSum)
                {
                    longestSubSum = subSum;
                    sequence = currentSequence;
                    indexOfLongest = indexOfSequence;
                }

                indexOfSequence++;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {indexOfLongest} with sum: {longestSubSum}.");
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
