using System;
using System.Collections.Generic;
using System.Linq;

namespace _02m_CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> inputTimes = Console.ReadLine().Split().Select(double.Parse).ToList();
            double leftTime = 0;
            double rightTime = 0;

            for (int i = 0; i < inputTimes.Count / 2; i++)
            {
                leftTime += inputTimes[i];
                rightTime += inputTimes[inputTimes.Count - 1 - i];

                if (inputTimes[i] == 0)
                {
                    leftTime *= 0.8;
                }

                if (inputTimes[inputTimes.Count - 1 - i] == 0)
                {
                    rightTime *= 0.8;
                }
            }

            if (leftTime < rightTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightTime}");
            }
        }
    }
}
