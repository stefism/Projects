using System;

namespace _05Orders
{
    class Program
    {
        static double price = 0;

        static void Main(string[] args)
        {
            string drinkType = Console.ReadLine();
            int numberOfDrinks = int.Parse(Console.ReadLine());

            DrinkPriceCalculate(drinkType, numberOfDrinks);
            Console.WriteLine("{0:F2}", (price * numberOfDrinks));
        }

        static void DrinkPriceCalculate(string drink, int numberOfDrink)
        {

            switch (drink)
            {
                case "coffee":
                    price = 1.50;
                    break;

                case "water":
                    price = 1.00;
                    break;

                case "coke":
                    price = 1.40;
                    break;

                case "snacks":
                    price = 2.00;
                    break;
            }
        }
    }
}
