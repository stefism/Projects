using System;

namespace TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double tenisRocketPrice = double.Parse(Console.ReadLine());
            int numberOfTenisRocket = int.Parse(Console.ReadLine());
            int numberOfComplectSneakers = int.Parse(Console.ReadLine());

            double priceOfTenisRockets = numberOfTenisRocket * tenisRocketPrice;
            double oneSneakerPrice = tenisRocketPrice / 6;
            double priceForAllSneakers = oneSneakerPrice * numberOfComplectSneakers;

            double otherEquipmentPrice = (priceOfTenisRockets + priceForAllSneakers) * 0.2;
            double totalPrice = priceOfTenisRockets + priceForAllSneakers + otherEquipmentPrice;

            double priceForJocovich = totalPrice / 8;
            double priceForSponsors = totalPrice * 7 / 8;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceForJocovich)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(priceForSponsors)}");
        }
    }
}
