using System;

namespace _09_SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int extractYield = 0;
            int workersConsum = 26;
            int mineDaysCounter = 0;

            while (yield >= 100)
            {
                mineDaysCounter++;

                extractYield += yield;

                if (workersConsum > extractYield)
                {
                    workersConsum = extractYield;
                    extractYield -= workersConsum;
                    workersConsum = 26;
                }
                else
                {
                    workersConsum = 26;
                    extractYield -= workersConsum;
                }
                yield -= 10;
            }

            if (workersConsum > extractYield)
            {
                workersConsum = extractYield;
                extractYield -= workersConsum;
                workersConsum = 26;
            }
            else
            {
                workersConsum = 26;
                extractYield -= workersConsum;
            }

            Console.WriteLine(mineDaysCounter);
            Console.WriteLine(extractYield);
        }
    }
}
