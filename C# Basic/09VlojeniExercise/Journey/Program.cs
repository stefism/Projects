using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string campOrHotel = "";
            string somewhere = "";

            if (budget <= 100)
            {
                somewhere = "Bulgaria";

                if (season == "summer")
                {
                    budget = budget * 0.30;
                    campOrHotel = "Camp";
                }
                else if (season == "winter")
                {
                    budget = budget * 0.70;
                    campOrHotel = "Hotel";
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                somewhere = "Balkans";

                if (season == "summer")
                {
                    budget = budget * 0.40;
                    campOrHotel = "Camp";
                }
                else if (season == "winter")
                {
                    budget = budget * 0.80;
                    campOrHotel = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                somewhere = "Europe";
                budget = budget * 0.90;
                campOrHotel = "Hotel";
            }

            Console.WriteLine($"Somewhere in {somewhere}");
            Console.WriteLine($"{campOrHotel} - {budget:F2}");

        }
    }
}
