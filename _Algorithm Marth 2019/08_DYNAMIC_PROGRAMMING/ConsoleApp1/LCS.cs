using System;

namespace LongestCommonSubsequence
{
    class LCS
    {
        static void Main()
        {
            string firstSequence = Console.ReadLine();
            string secondSequence = Console.ReadLine();

            var lcs = new int[firstSequence.Length + 1, secondSequence.Length + 1];

            for (int row = 1; row <= firstSequence.Length; row++)
            {
                for (int col = 01; col <= secondSequence.Length; col++)
                {
                    int upValue = lcs[row - 1, col];
                    int leftValue = lcs[row, col - 1];

                    int result = Math.Max(upValue, leftValue);

                    if (firstSequence[row - 1] == secondSequence[col - 1])
                    {
                        result = Math.Max(1 + lcs[row - 1, col - 1], result);
                    }

                    lcs[row, col] = result;
                }
            }

            Console.WriteLine(lcs[firstSequence.Length, secondSequence.Length]);
        }
    }
}
