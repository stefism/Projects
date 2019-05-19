using System;

namespace _07_VendingMashine
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;

            while (true)
            {
                string inputCoins = Console.ReadLine();

                if (inputCoins == "Start")
                {
                    break;
                }

                double coins = double.Parse(inputCoins);

                if (coins != 0.1 && coins != 0.2 && coins != 0.5 && coins != 1 && coins != 2)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                else
                {
                    sum += coins;
                    //Console.WriteLine(sum);
                }
            }

            double nutsPrice = 2;
            double waterPrice = 0.7;
            double crispsPrice = 1.5;
            double sodaPrice = 0.8;
            double cokePrice = 1.0;

            double lastSum = 0;

            while (true)
            {
                string product = Console.ReadLine();

                if (product == "End")
                {
                    break;
                }
                
                else if (product == "Nuts")
                {
                    sum -= nutsPrice;
                    lastSum = nutsPrice;
                }

                else if (product == "Water")
                {
                    sum -= waterPrice;
                    lastSum = waterPrice;
                }

                else if (product == "Crisps")
                {
                    sum -= crispsPrice;
                    lastSum = crispsPrice;
                }

                else if (product == "Soda")
                {
                    sum -= sodaPrice;
                    lastSum = sodaPrice;
                }

                else if (product == "Coke")
                {
                    sum -= cokePrice;
                    lastSum = cokePrice;
                }

                else
                {
                    Console.WriteLine("Invalid product");
                    continue;
                }

                if (sum < 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                    sum += lastSum;
                    continue;
                }
                else
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
            }

            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}
