using System;

namespace SeaTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForFood = int.Parse(Console.ReadLine());
            double moneyForsouvenirs = int.Parse(Console.ReadLine());
            double moneyForHotel = int.Parse(Console.ReadLine());

            double GasLiterNeeded = 420 / 100.00 * 7;
            //Console.WriteLine($"Liter needed: {GasLiterNeeded}");
            double moneyForGas = GasLiterNeeded * 1.85;
            //Console.WriteLine($"Money for gas: {moneyForGas}");

            double moneyForFoodAnsSouvenirs = (3 * moneyForFood) + (3 * moneyForsouvenirs);

            double firstDayInHotel = moneyForHotel * 0.9;
            double seconnDayInHotel = moneyForHotel * 0.85;
            double thirdDayInHotel = moneyForHotel * 0.8;

            double totalStayInSeaSum = moneyForGas + moneyForFoodAnsSouvenirs
                + firstDayInHotel + seconnDayInHotel + thirdDayInHotel;

            Console.WriteLine($"Money needed: {totalStayInSeaSum:F2}");
        }
    }
}
