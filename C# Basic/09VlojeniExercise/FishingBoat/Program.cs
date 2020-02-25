using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double fishers = double.Parse(Console.ReadLine());

            double rentForBoot = 0;
            double discount = 0;

            switch (season)
            {
                case "Spring":
                    rentForBoot = 3000;
                    break;

                case "Summer":
                    rentForBoot = 4200;
                    break;

                case "Autumn":
                    rentForBoot = 4200;
                    break;

                case "Winter":
                    rentForBoot = 2600;
                    break;
            }

            if (fishers <= 6)
            {
                discount = rentForBoot * 0.10;
            }
            else if (fishers > 6 && fishers <= 11)
            {
                discount = rentForBoot * 0.15;
            }
            else if (fishers >= 12)
            {
                discount = rentForBoot * 0.25;
            }

            double priceToPay = rentForBoot - discount;

            if (fishers % 2 == 0 && season != "Autumn")
            {
                priceToPay = priceToPay - (priceToPay * 0.05);
            }

            double moneyLeft = budget - priceToPay;

            if (budget >= priceToPay)
            {
                Console.WriteLine($"Yes! You have {Math.Abs(moneyLeft):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(moneyLeft):F2} leva.");
            }

        }
    }
}
