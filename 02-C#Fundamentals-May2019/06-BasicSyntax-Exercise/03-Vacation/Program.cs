using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleNumber = int.Parse(Console.ReadLine());
            string peopleType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double priceForOnePerson = 0;
            double totalPrice = 0;

            if (dayOfWeek == "Friday")
            {
                switch (peopleType)
                {
                    case "Students":
                        priceForOnePerson = 8.45;
                        break;

                    case "Business":
                        priceForOnePerson = 10.90;
                        break;

                    case "Regular":
                        priceForOnePerson = 15;
                        break;
                }
            }

            else if (dayOfWeek == "Saturday")
            {
                switch (peopleType)
                {
                    case "Students":
                        priceForOnePerson = 9.80;
                        break;

                    case "Business":
                        priceForOnePerson = 15.60;
                        break;

                    case "Regular":
                        priceForOnePerson = 20;
                        break;
                }
            }

            else if (dayOfWeek == "Sunday")
            {
                switch (peopleType)
                {
                    case "Students":
                        priceForOnePerson = 10.46;
                        break;

                    case "Business":
                        priceForOnePerson = 16;
                        break;

                    case "Regular":
                        priceForOnePerson = 22.50;
                        break;
                }
            }

            totalPrice = priceForOnePerson * peopleNumber;

            if (peopleType == "Students" && peopleNumber >= 30)
            {
                totalPrice *= 0.85;
            }

            else if (peopleType == "Business" && peopleNumber >= 100)
            {
                totalPrice = priceForOnePerson * (peopleNumber-10);
            }

            else if (peopleType == "Regulal" && peopleNumber >= 10 && peopleNumber <= 20)
            {
                totalPrice *= 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
