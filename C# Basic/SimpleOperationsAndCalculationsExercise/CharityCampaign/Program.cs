using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberDays = int.Parse(Console.ReadLine());
            int NumberCookers = int.Parse(Console.ReadLine());
            int NumberCakes = int.Parse(Console.ReadLine());
            int NumberGofrets = int.Parse(Console.ReadLine());
            int NumberPancakes = int.Parse(Console.ReadLine());

            //double cakesPrice = 45;
            //double gofretsPrice = 5.80;
            //double pancakePrice = 3.20;

            double moneyOf1CookerFor1Day = (NumberCakes * 45)
                + (NumberGofrets * 5.80) + (NumberPancakes * 3.20);
            double moneyOf1CookerForAllDay = moneyOf1CookerFor1Day 
                * NumberDays;
            double moneyTotal = (moneyOf1CookerForAllDay * NumberCookers);

            double Expensions = moneyTotal / 8;
            double price = moneyTotal - Expensions;

            Console.WriteLine($"{price:F2}");
        }
    }
}
