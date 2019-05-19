using System;

namespace _07_VendingMashineWithMethod
{
    class Program
    {
        static string product = "";
        static double sum = 0;
        static void Main(string[] args)
        {

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

            while (true)
            {
                product = Console.ReadLine();

                if (product == "End")
                {
                    break;
                }

                else if (product == "Nuts")
                {
                    SubstractSumAndSendMessage(nutsPrice);
                }

                else if (product == "Water")
                {
                    SubstractSumAndSendMessage(waterPrice);
                }

                else if (product == "Crisps")
                {
                    SubstractSumAndSendMessage(crispsPrice);
                }
                
                else if (product == "Soda")
                {
                    SubstractSumAndSendMessage(sodaPrice);
                }

                else if (product == "Coke")
                {
                    SubstractSumAndSendMessage(cokePrice);
                }

                else
                {
                    Console.WriteLine("Invalid product");
                    continue;
                }
            }

            Console.WriteLine($"Change: {sum:F2}");
        }

        static void SubstractSumAndSendMessage(double productPrice)
        {
            double lastSum = productPrice;
            sum -= productPrice;

            if (sum < 0)
            {
                Console.WriteLine("Sorry, not enough money");
                sum += lastSum;
            }

            else
            {
                Console.WriteLine($"Purchased {product.ToLower()}");
            }
        }
    }
}
