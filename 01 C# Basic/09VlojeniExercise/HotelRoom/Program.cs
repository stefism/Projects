using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double nightsNumber = double.Parse(Console.ReadLine());

            double priceStudio = 0;
            double priceAppartment = 0;

            if (month == "May" || month == "October")
            {
                priceStudio = 50;
                priceAppartment = 65;

                if (nightsNumber > 7 && nightsNumber <=14)
                {
                    priceStudio = priceStudio - (priceStudio * 0.05);
                }
                else if (nightsNumber > 14)
                {
                    priceStudio = priceStudio - (priceStudio * 0.30);
                }
            }

            else if (month == "June" || month == "September")
            {
                priceStudio = 75.20;
                priceAppartment = 68.70;

                if (nightsNumber > 14)
                {
                    priceStudio = priceStudio - (priceStudio * 0.20);
                }
            }

            else if (month == "July" || month == "August")
            {
                priceStudio = 76;
                priceAppartment = 77;
            }

            if (nightsNumber > 14)
            {
                priceAppartment = priceAppartment - (priceAppartment * 0.10);
            }

            double priceForStayInStudio = priceStudio * nightsNumber;
            double priceForStayInAppartment = priceAppartment * nightsNumber;

            Console.WriteLine($"Apartment: {priceForStayInAppartment:F2} lv.");
            Console.WriteLine($"Studio: {priceForStayInStudio:F2} lv.");

        }
    }
}
