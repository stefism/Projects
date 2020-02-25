using System;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int dailyQuota = int.Parse(Console.ReadLine());
            double sumFish = 0;
            double lostSum = 0;
            double priceSum = 0;
            double sumFromFish = 0;

            int counterFish = 0;

            for (int i = 0; i < dailyQuota; i++)
            {
                counterFish++;

                string fishName = Console.ReadLine();

                if (fishName == "Stop")
                {

                }

                int fishWeight = int.Parse(Console.ReadLine());

                for (int n = 0; n < fishName.Length; n++) // тука ако гръмне, евентуално - 1
                {
                    sumFromFish = fishName[n];
                    sumFish += sumFromFish;
                }

                Console.WriteLine($"Sum from fish: {sumFish:F2}");

                sumFish /= fishWeight;
                
                Console.WriteLine($"Price: {sumFish:F2}" );

                if (counterFish % 3 == 0)
                {
                    priceSum = sumFish;
                }
                else
                {
                    lostSum = sumFish;
                }
            }

            Console.WriteLine("Lyubo fulfilled the quota!");

            Console.WriteLine($"Lost: {lostSum}");
            Console.WriteLine($"Price: {priceSum}");

            if (priceSum >= lostSum)
            {
                Console.WriteLine($"Lyubo's profit from {counterFish} fishes is {(priceSum - lostSum):F2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {(lostSum - priceSum):F2} leva today.");
            }
        }
    }
}
