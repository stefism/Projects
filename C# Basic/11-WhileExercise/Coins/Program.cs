using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            amount = amount * 100;
            double rest = 0;
            double whole = 0;
            double wholeCoins = 0;
            double wholeNumber = 0;
            double restCoins = 0;

            if (amount > 100)
            {
                rest = amount % 100;
                whole = (amount - rest) / 100;

                Console.WriteLine($"Остатъка: {rest}");
                Console.WriteLine($"Цялото: {whole}");

                if (whole > 1)
                {
                    wholeNumber = whole % 2;
                    wholeCoins = ((whole - wholeNumber) / 2) + wholeNumber;
                    Console.WriteLine(wholeCoins);
                }
            }

            else
            {
                rest = amount;

                if (rest >= 50)
                {
                    restCoins++;
                    rest = amount - 50;

                    if (rest > 20)
                    {
                        rest = rest - 20;
                        restCoins++;
                    }

                    if (rest > 20)
                    {
                        rest = rest - 20;
                        restCoins++;
                    }

                    if (rest > 5)
                    {
                        rest = rest - 5;
                        restCoins++;
                    }

                    if (rest > 2)
                    {
                        rest = rest - 2;
                        restCoins++;
                    }

                    if (rest > 1)
                    {
                        rest = rest - 1;
                        restCoins++;
                    }
                }
                else if (rest >= 40)
                {
                    if (rest > 40)
                    {
                        rest = rest - 20;
                        restCoins++;
                    }

                    if (rest > 20)
                    {
                        rest = rest - 20;
                        restCoins++;
                    }

                    if (rest > 5)
                    {
                        rest = rest - 5;
                        restCoins++;
                    }

                    if (rest > 2)
                    {
                        rest = rest - 2;
                        restCoins++;
                    }

                    if (rest > 1)
                    {
                        rest = rest - 1;
                        restCoins++;
                    }
                }
            }
            Console.WriteLine(restCoins);
        }

    }

}







