using System;

namespace Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string device = Console.ReadLine();

            double difficulty = 0;
            double performance = 0;

            switch (device)
            {
                case "ribbon":

                    if (country == "Russia")
                    {
                        difficulty = 9.100;
                        performance = 9.400;
                    }
                    else if (country == "Bulgaria")
                    {
                        difficulty = 9.600;
                        performance = 9.400;
                    }
                    else if (country == "Italy")
                    {
                        difficulty = 9.200;
                        performance = 9.500;
                    }

                    break;

                case "hoop":

                    if (country == "Russia")
                    {
                        difficulty = 9.300;
                        performance = 9.800;
                    }
                    else if (country == "Bulgaria")
                    {
                        difficulty = 9.550;
                        performance = 9.750;
                    }
                    else if (country == "Italy")
                    {
                        difficulty = 9.450;
                        performance = 9.350;
                    }

                    break;

                case "rope":

                    if (country == "Russia")
                    {
                        difficulty = 9.600;
                        performance = 9.000;
                    }
                    else if (country == "Bulgaria")
                    {
                        difficulty = 9.500;
                        performance = 9.400;
                    }
                    else if (country == "Italy")
                    {
                        difficulty = 9.700;
                        performance = 9.150;
                    }

                    break;
            }

            double totalScore = difficulty + performance;
            double leftPoints = 20.000 - totalScore;
            double percentPoints = (leftPoints / 20) * 100;

            Console.WriteLine($"The team of {country} get {totalScore:F3} on {device}.");
            Console.WriteLine($"{percentPoints:F2}%");
        }
    }
}
