using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    class LIS
    {
        static void Main()
        {
            int[] numbers = new[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };

            int[] solutions = new int[numbers.Length];
            int[] prev = new int[numbers.Length];

            int maxSolution = 0;
            int maxSolutionIndex = 0;

            for (int current = 0; current < numbers.Length; current++)
            {
                int solution = 1;
                int prevIndex = -1;

                int currentNumber = numbers[current];

                for (int solIndex = 0; solIndex < current; solIndex++)
                {
                    int prevNumber = numbers[solIndex];
                    int prevSolution = solutions[solIndex];

                    if (currentNumber > prevNumber && solution <= prevSolution)
                    {
                        solution = prevSolution + 1;
                        prevIndex = solIndex;
                    }
                }

                solutions[current] = solution;
                prev[current] = prevIndex;

                if (solution > maxSolution)
                {
                    maxSolution = solution;
                    maxSolutionIndex = current;
                }
            }

            Console.WriteLine(maxSolution);

            int index = maxSolutionIndex;

            var result = new List<int>();

            while (index != -1)
            {
                int currentNumber = numbers[index];
                result.Add(currentNumber);
                index = prev[index];
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
