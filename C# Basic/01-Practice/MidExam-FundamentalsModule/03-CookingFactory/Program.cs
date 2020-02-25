using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_CookingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // (Demo)Technology Fundamentals Mid Exam - 02 March 2019

            int bestQuality = int.MinValue;
            double bestAverageQuality = int.MinValue;
            int bestMinLength = int.MaxValue;

            List<string> input = new List<string>();
            List<int> bestBreath = new List<int>();

            while (true)
            {
               input = Console.ReadLine().Split("#").ToList();
                
                if (input[0] == "Bake It!")
                {
                    Console.WriteLine($"Best Batch quality: {bestQuality}");
                    Console.WriteLine(string.Join(" ", bestBreath));
                    break;
                }

                List<int> breadQuality = input.Select(int.Parse).ToList();

                int currentQuality = 0;
                int currentLength = input.Count;
                

                if (currentLength < bestMinLength)
                {
                    bestMinLength = currentLength;
                }

                for (int i = 0; i < breadQuality.Count; i++)
                {
                    currentQuality += breadQuality[i];
                }

                double currentAverageQuality = currentQuality / breadQuality.Count;

                if (currentAverageQuality > bestAverageQuality)
                {
                    bestAverageQuality = currentAverageQuality;
                }

                if (currentQuality > bestQuality)
                {
                    bestQuality = currentQuality;
                    bestBreath = breadQuality;
                }
                else if (currentQuality == bestQuality)
                {
                    if (currentAverageQuality > bestAverageQuality)
                    {
                        bestAverageQuality = currentAverageQuality;
                        bestQuality = currentQuality;
                        bestBreath = breadQuality;
                    }
                }

                if (currentQuality == bestQuality && currentAverageQuality == bestAverageQuality) // currentAverageQuality > bestAverageQuality
                {
                    if (currentLength < bestMinLength)
                    {
                        bestQuality = currentQuality;
                        bestBreath = breadQuality;
                    }
                }
            }
        }
    }
}
