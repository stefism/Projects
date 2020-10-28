using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goalSteps = 10000;
            int stepsToGo = 0;

            while (true)
            {

                if (stepsToGo >= goalSteps)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    break;
                }

                string steps = Console.ReadLine();

                if (steps == "Going home")
                {
                    int stepsNumberBeforeHome = int.Parse(Console.ReadLine());
                    stepsNumberBeforeHome = stepsNumberBeforeHome + stepsToGo;

                    if (stepsNumberBeforeHome >= goalSteps)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{goalSteps - stepsNumberBeforeHome} more steps to reach goal.");
                        break;
                    }
                }

                int stepsNumber = int.Parse(steps);

                stepsToGo = stepsToGo + stepsNumber;
            }
        }
    }
}
