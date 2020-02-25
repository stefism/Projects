using System;
using static System.Net.Mime.MediaTypeNames;

namespace _03_GamingStore
{
    class Program
    {
        static double SpentMoney = 0;
        //static double LeftMoney = 0;
        static void Main(string[] args)
        {
            SpentMoney = double.Parse(Console.ReadLine());
            double initialMoney = SpentMoney;


            double outFall4_Price = 39.99;
            double csOg_Price = 15.99;
            double zplinterZell_price = 19.99;
            double honored2_price = 59.99;
            double roverWatch_price = 29.99;
            double roverWatchOrigin_price = 39.99;

            while (true)
            {
                string gameName = Console.ReadLine();

                if (gameName == "Game Time")
                {
                    break;
                }

                switch (gameName)
                {
                    case "OutFall 4":
                        CalculateMoneyAndSendMessage("OutFall 4", outFall4_Price);
                        break;

                    case "CS: OG":
                        CalculateMoneyAndSendMessage("CS: OG", csOg_Price);
                        break;

                    case "Zplinter Zell":
                        CalculateMoneyAndSendMessage("Zplinter Zell", zplinterZell_price);
                        break;

                    case "Honored 2":
                        CalculateMoneyAndSendMessage("Honored 2", honored2_price);
                        break;

                    case "RoverWatch":
                        CalculateMoneyAndSendMessage("RoverWatch", roverWatch_price);
                        break;

                    case "RoverWatch Origins Edition":
                        CalculateMoneyAndSendMessage("RoverWatch Origins Edition", roverWatchOrigin_price);
                        break;

                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
            }

            Console.WriteLine($"Total spent: ${(initialMoney - SpentMoney):F2}. Remaining: ${SpentMoney:F2}");
        }

        static void CalculateMoneyAndSendMessage(string gameName, double gamePrice)
        {
            if (SpentMoney >= gamePrice)
            {
                Console.WriteLine($"Bought {gameName}");
                SpentMoney -= gamePrice;
            }
            else if (SpentMoney > 0 && SpentMoney < gamePrice)
            {
                Console.WriteLine("Too Expensive");
            }
            if (SpentMoney <= 0)
            {
                Console.WriteLine("Out of money!");
                Environment.Exit(1);
            }
        }
    }
}
