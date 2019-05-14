using System;

namespace ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Retake Mid Exam 18 December 2018. 01 Christmas Spirit

            int quantityLimit = int.Parse(Console.ReadLine());
            int daysToChristmas = int.Parse(Console.ReadLine());

            int ornamentSet = 2;
            int treeSkirt = 5;
            int treeGarlands = 3;
            int treeLights = 15;

            int totalCost = 0;

            int dayCounter = 0;

            int spirit = 0;

            for (int i = 1; i <= daysToChristmas; i++)
            {
                dayCounter++;

                if (dayCounter % 2 == 0)
                {
                    totalCost += quantityLimit * ornamentSet;
                    spirit += 5;
                }

                if (dayCounter % 3 == 0)
                {
                    totalCost += (quantityLimit * treeSkirt) + (quantityLimit * treeGarlands);
                    spirit += 13;
                }

                if (dayCounter % 5 == 0)
                {
                    totalCost += quantityLimit * treeLights;
                    spirit += 17;
                }

                if (dayCounter % 3 == 0 && dayCounter % 5 == 0)
                {
                    spirit += 30;
                }

                if (dayCounter % 10 == 0)
                {
                    spirit -= 20;
                    quantityLimit += 2;
                    totalCost += treeSkirt + treeGarlands + treeLights;
                }
            }

            if (daysToChristmas % 10 == 0)
            {
                spirit -= 30;
            }

            Console.WriteLine($"Total cost: {totalCost}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
}
