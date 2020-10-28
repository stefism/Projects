using System;

namespace SushiTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushiType = Console.ReadLine();
            string restaurantName = Console.ReadLine();
            double portionNumber = int.Parse(Console.ReadLine());
            string orderForHome = Console.ReadLine();

            double sashimi = 0;
            double maki = 0;
            double uramaki = 0;
            double temaki = 0;

            double sushiPrice = 0;

            switch (restaurantName)
            {
                case "Sushi Zone":

                    sashimi = 4.99;
                    maki = 5.29;
                    uramaki = 5.99;
                    temaki = 4.29;

                    if (sushiType == "sashimi")
                    {
                        sushiPrice = sashimi * portionNumber;
                    }
                    else if (sushiType == "maki")
                    {
                        sushiPrice = maki * portionNumber;
                    }
                    else if (sushiType == "uramaki")
                    {
                        sushiPrice = uramaki * portionNumber;
                    }
                    else if (sushiType == "temaki")
                    {
                        sushiPrice = temaki * portionNumber;
                    }

                    break;

                case "Sushi Time":

                    sashimi = 5.49;
                    maki = 4.69;
                    uramaki = 4.49;
                    temaki = 5.19;

                    if (sushiType == "sashimi")
                    {
                        sushiPrice = sashimi * portionNumber;
                    }
                    else if (sushiType == "maki")
                    {
                        sushiPrice = maki * portionNumber;
                    }
                    else if (sushiType == "uramaki")
                    {
                        sushiPrice = uramaki * portionNumber;
                    }
                    else if (sushiType == "temaki")
                    {
                        sushiPrice = temaki * portionNumber;
                    }

                    break;

                case "Sushi Bar":

                    sashimi = 5.25;
                    maki = 5.55;
                    uramaki = 6.25;
                    temaki = 4.75;

                    if (sushiType == "sashimi")
                    {
                        sushiPrice = sashimi * portionNumber;
                    }
                    else if (sushiType == "maki")
                    {
                        sushiPrice = maki * portionNumber;
                    }
                    else if (sushiType == "uramaki")
                    {
                        sushiPrice = uramaki * portionNumber;
                    }
                    else if (sushiType == "temaki")
                    {
                        sushiPrice = temaki * portionNumber;
                    }

                    break;

                case "Asian Pub":

                    sashimi = 4.50;
                    maki = 4.80;
                    uramaki = 5.50;
                    temaki = 5.50;

                    if (sushiType == "sashimi")
                    {
                        sushiPrice = sashimi * portionNumber;
                    }
                    else if (sushiType == "maki")
                    {
                        sushiPrice = maki * portionNumber;
                    }
                    else if (sushiType == "uramaki")
                    {
                        sushiPrice = uramaki * portionNumber;
                    }
                    else if (sushiType == "temaki")
                    {
                        sushiPrice = temaki * portionNumber;
                    }

                    break;

                default:

                    Console.WriteLine($"{restaurantName} is invalid restaurant!");

                    break;
            }

            if (restaurantName == "Sushi Zone" || restaurantName == "Sushi Time" || restaurantName == "Sushi Bar" || restaurantName == "Asian Pub")
            {
                if (orderForHome == "N")
                {
                    Console.WriteLine($"Total price: {Math.Ceiling(sushiPrice)} lv.");
                }
                else if (orderForHome == "Y")
                {
                    //Console.WriteLine($"Без доставката: {Math.Ceiling(sushiPrice)} lv.");
                    sushiPrice = sushiPrice + (sushiPrice * 0.20);
                    Console.WriteLine($"Total price: {Math.Ceiling(sushiPrice)} lv.");
                }
            }

            
        }
    }
}
