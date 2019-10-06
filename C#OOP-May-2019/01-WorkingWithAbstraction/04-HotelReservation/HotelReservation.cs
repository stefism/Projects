using System;

namespace _04_HotelReservation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            double pricePerDay = double.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2];
            string typeOfDiscount = "None";

            var currentSeason = Enum.Parse(typeof(Season), season);
            
            if (input.Length == 4)
            {
                typeOfDiscount = input[3];
            }

            var currentDiscount = Enum.Parse(typeof(Discount), typeOfDiscount);

            double totalPrice = PriceCalculator
                .GetTotalPrice(pricePerDay, numberOfDays, (Season)currentSeason, (Discount)currentDiscount);

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
