using System;

namespace SummerClothеs
{
    class Program
    {
        static void Main(string[] args)
        {
            int gradus = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            string outfit = " ";
            string shoes = " ";

            switch (timeOfDay)
            {
                case "Morning":
                    if (gradus >= 10 && gradus <=18)
                    {
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                    else if (gradus > 18 && gradus <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (gradus >= 25)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    break;

                case "Afternoon":
                    if (gradus >= 10 && gradus <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (gradus > 18 && gradus <= 24)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    else if (gradus >= 25)
                    {
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;

                case "Evening":
                    if (gradus >= 10 && gradus <= 18)
                    {
                        outfit = "Shirt 3";
                        shoes = "Moccasins 3";
                    }
                    else if (gradus > 18 && gradus <= 24)
                    {
                        outfit = "Shirt 1";
                        shoes = "Moccasins 1";
                    }
                    else if (gradus >= 25)
                    {
                        outfit = "Shirt 2";
                        shoes = "Moccasins 3";
                    }
                    break;

            }

            Console.WriteLine($"Облечи {outfit} и {shoes}.");

                
            
        }
    }
}
