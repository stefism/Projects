using System;

namespace AlchocolMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWiskeyLv = double.Parse(Console.ReadLine());
            double beelLiter = double.Parse(Console.ReadLine());
            double wineLiter = double.Parse(Console.ReadLine());
            double rakiyaLiter = double.Parse(Console.ReadLine());
            double wiskeyLiter = double.Parse(Console.ReadLine());

            double totalPriceWiskey = wiskeyLiter * priceWiskeyLv;

            double PriceRakiya = priceWiskeyLv / 2;
            double PriceWine = PriceRakiya * 40 / 100;
            double PriceBeer = PriceRakiya * 80 / 100;

            double totalPriceRakiya = PriceRakiya * rakiyaLiter;
            double totalPriceWine = PriceWine * wineLiter;
            double totalPriceBeer = PriceBeer * beelLiter;

            double totalAll = totalPriceWiskey + totalPriceRakiya
                + totalPriceWine + totalPriceBeer;

            Console.WriteLine($"{totalAll:F2}");
            

        }
    }
}
