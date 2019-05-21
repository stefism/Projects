using System;
using System.Collections.Generic;
using System.Linq;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int repeatCounter = 0;
            int maxCounter = 0;
            int repeatNumber = 0;

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 1; j < input.Count; j++) 
                {
                    if (input[i] == input[j])
                    {
                        repeatCounter++;
                    }
                }

                if (repeatCounter > maxCounter)
                {
                    maxCounter = repeatCounter;
                    repeatNumber = i;
                }
            }

            Console.WriteLine(repeatNumber);
        }
    }
}
