using System;

namespace TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tableNumber = int.Parse(Console.ReadLine());
            double tableLenght = double.Parse(Console.ReadLine());
            double tableWidth = double.Parse(Console.ReadLine());

            double coverAllArea = tableNumber * (tableLenght + 2 * 0.30)
                * (tableWidth + 2 * 0.30);
            double squareAllArea = tableNumber * (tableLenght / 2)
                * (tableLenght / 2);

            double priceUSD = coverAllArea * 7 + squareAllArea * 9;
            double priceLeva = priceUSD * 1.85;

            Console.WriteLine($"{priceUSD:F2} USD");
            Console.WriteLine($"{priceLeva:F2} BGN");
        }
    }
}
