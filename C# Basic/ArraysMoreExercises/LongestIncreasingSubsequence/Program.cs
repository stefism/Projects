using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            bool ifBigger = false;
            int bestLength = 1;

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i+1; j < input.Count; j++)
                {
                    if (input[i] < input[j])
                    {
                        ifBigger = true;
                        bestLength++;
                        result.Add(input[i]);
                    }
                }
            }
        }
    }
}
