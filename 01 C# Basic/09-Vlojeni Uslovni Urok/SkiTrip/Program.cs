using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double dayForStay = double.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();

            double roomFor1PersonPrice = 18.00;
            double apartmentPrice = 25.00;
            double presidentAppartmentPrice = 35.00;

            double priceForStay = 0;
            double discount = 0;
            double totalSum = 0;

            if (roomType == "room for one person")
            {
                totalSum = (dayForStay - 1) * roomFor1PersonPrice;
            }

            if (roomType == "apartment")
            {
                if (dayForStay < 10)
                {
                    priceForStay = (dayForStay - 1) * apartmentPrice;
                    discount = priceForStay * 0.30;
                    totalSum = priceForStay - discount;
                }
                else if (dayForStay >= 10 && dayForStay <= 15)
                {
                    priceForStay = (dayForStay - 1) * apartmentPrice;
                    discount = priceForStay * 0.35;
                    totalSum = priceForStay - discount;
                }
                else if (dayForStay > 15)
                {
                    priceForStay = (dayForStay - 1) * apartmentPrice;
                    discount = priceForStay * 0.50;
                    totalSum = priceForStay - discount;

                }
            }
            if (roomType == "president apartment")
            {
                if (dayForStay < 10)
                {
                    priceForStay = (dayForStay - 1) * presidentAppartmentPrice;
                    discount = priceForStay * 0.10;
                    totalSum = priceForStay - discount;
                }
                else if (dayForStay >= 10 && dayForStay <= 15)
                {
                    priceForStay = (dayForStay - 1) * presidentAppartmentPrice;
                    discount = priceForStay * 0.15;
                    totalSum = priceForStay - discount;
                }
                else if (dayForStay > 15)
                {
                    priceForStay = (dayForStay - 1) * presidentAppartmentPrice;
                    discount = priceForStay * 0.20;
                    totalSum = priceForStay - discount;
                }
            }
            if (rating == "positive")
            {
                totalSum = totalSum * 1.25;
            }
            else if (rating == "negative")
            {
                if (roomType == "room for one person")
                {
                    totalSum = totalSum - (totalSum * 0.10);
                }
                else if (roomType == "apartment")
                {
                    totalSum = totalSum - (totalSum * 0.10);
                }
                else if (roomType == "president apartment")
                {
                    totalSum = totalSum - (totalSum * 0.10);
                }
            }
            Console.WriteLine("{0:F2}", totalSum);
        }
    }
}
