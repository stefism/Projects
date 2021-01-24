using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestZigzagSubsequence
{
    class LZS
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            int[,] currIndexValues = new int[numbers.Length, 2];
            int[,] prevBestIndexes = new int[numbers.Length, 2];

            currIndexValues[0, 0] = currIndexValues[0, 1] = 1;
            prevBestIndexes[0, 0] = currIndexValues[0, 1] = -1;

            int maxResult = 0;
            int maxIndexRow = 0;
            int maxIndexCol = 0;

            for (int currIndex = 1; currIndex < numbers.Length; currIndex++)
            {
                for (int prevIndex = 0; prevIndex < currIndex; prevIndex++)
                {
                    int currNumber = numbers[currIndex];
                    int prevNumber = numbers[prevIndex];

                    if (currNumber > prevNumber && 
                        currIndexValues[currIndex, 0] < currIndexValues[prevIndex, 1] + 1)
                    {
                        currIndexValues[currIndex, 0] = currIndexValues[prevIndex, 1] + 1;
                        prevBestIndexes[currIndex, 0] = prevIndex;
                    }

                    if (currNumber < prevNumber &&
                        currIndexValues[currIndex, 1] < currIndexValues[prevIndex, 0] + 1)
                    {
                        currIndexValues[currIndex, 1] = currIndexValues[prevIndex, 0] + 1;
                        prevBestIndexes[currIndex, 1] = prevIndex;
                    }
                }

                if (currIndexValues[currIndex, 0] > maxResult)
                {
                    maxResult = currIndexValues[currIndex, 0];
                    maxIndexRow = currIndex;
                    maxIndexCol = 0;
                }

                if (currIndexValues[currIndex, 1] > maxResult)
                {
                    maxResult = currIndexValues[currIndex, 1];
                    maxIndexRow = currIndex;
                    maxIndexCol = 1;
                }
            }

            var result = new List<int>();

            while (maxIndexRow >= 0)
            {
                result.Add(numbers[maxIndexRow]);
                maxIndexRow = prevBestIndexes[maxIndexRow, maxIndexCol];

                if (maxIndexCol == 1)
                {
                    maxIndexCol = 0;
                }
                else
                {
                    maxIndexCol = 1;
                }
            }

            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
