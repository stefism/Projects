using System;

namespace _10_PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pushingPower = int.Parse(Console.ReadLine()); //N
            int distanceBetweenTarget = int.Parse(Console.ReadLine()); // M
            int exhaustionFactor = int.Parse(Console.ReadLine()); // Y
            double percent50OfPushingPower = pushingPower / 2.0;

            int targetCount = 0;

            while (true)
            {
                targetCount++;

                pushingPower -= distanceBetweenTarget;

                if (pushingPower == percent50OfPushingPower)
                {
                    if (exhaustionFactor != 0 && pushingPower != 0)
                    {
                        pushingPower /= exhaustionFactor;
                    }
                }

                if (pushingPower < distanceBetweenTarget)
                {
                    Console.WriteLine(pushingPower);
                    Console.WriteLine(targetCount);
                    break;
                }
            }
        }
    }
}
