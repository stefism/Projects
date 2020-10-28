using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfExcursion = double.Parse(Console.ReadLine());
            double NumberOfPuzles = double.Parse(Console.ReadLine());
            double NumberOfSpeekDolls = double.Parse(Console.ReadLine());
            double NumberOfTeddyBears = double.Parse(Console.ReadLine());
            double NumberOfMignons = double.Parse(Console.ReadLine());
            double NumberOfTrucks = double.Parse(Console.ReadLine());

            double priceOfPuzles = 2.60;
            double priceOfSpeekDolls = 3.00;
            double priceOfTeddyBears = 4.10;
            double priceOfMignons = 8.20;
            double priceOfTrucks = 2.00;

            double totalToysSum = (NumberOfPuzles * priceOfPuzles)
                + (NumberOfSpeekDolls * priceOfSpeekDolls)
                + (NumberOfTeddyBears * priceOfTeddyBears)
                + (NumberOfMignons * priceOfMignons)
                + (NumberOfTrucks * priceOfTrucks);

            double numberOfToys = NumberOfPuzles + NumberOfSpeekDolls
                + NumberOfTeddyBears + NumberOfMignons + NumberOfTrucks;

            double rentForShop = 0.10;

            double discount = 0.0;

            if (numberOfToys >= 50)
            {
                discount = totalToysSum * 0.25;
            }

            double sumFromSale = totalToysSum - discount;
            double rent = sumFromSale * rentForShop;
            double profit = sumFromSale - rent;

            double SumLeft = profit - priceOfExcursion;

            if (profit >= priceOfExcursion)
            {
                Console.WriteLine($"Yes! {Math.Abs(SumLeft):F2} lv left." );
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(SumLeft):F2} lv needed.");
            }
        }
    }
}
