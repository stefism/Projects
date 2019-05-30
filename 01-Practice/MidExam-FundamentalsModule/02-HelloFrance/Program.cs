using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {

            // Technology Fundamentals Mid Exam - 10 March 2019 Group 1

            List<string> inputArticlesAndPrice = Console.ReadLine().Split("|").ToList();
            double initialBudget = double.Parse(Console.ReadLine());

            double leftBudget = initialBudget;
            double totalProfit = 0;

            List<double> newPrices = new List<double>();

            for (int i = 0; i < inputArticlesAndPrice.Count; i++)
            {
                List<string> articlesAndPrice = inputArticlesAndPrice[i].Split("->").ToList();

                string articles = articlesAndPrice[0];
                double buySum = double.Parse(articlesAndPrice[1]);

                switch (articles)
                {
                    case "Clothes":
                        if (buySum <= 50 && leftBudget >= buySum)
                        {
                            double sumWithProfit = buySum * 1.40;
                            newPrices.Add(sumWithProfit);
                            totalProfit += sumWithProfit - buySum;
                            leftBudget -= buySum;
                        }
                        break;

                    case "Shoes":
                        if (buySum <= 35 && leftBudget >= buySum)
                        {
                            double sumWithProfit = buySum * 1.40;
                            newPrices.Add(sumWithProfit);
                            totalProfit += sumWithProfit - buySum;
                            leftBudget -= buySum;
                        }
                        break;

                    case "Accessories":
                        if (buySum <= 20.50 && leftBudget >= buySum)
                        {
                            double sumWithProfit = buySum * 1.40;
                            newPrices.Add(sumWithProfit);
                            totalProfit += sumWithProfit - buySum;
                            leftBudget -= buySum;
                        }
                        break;
                }
            }

            for (int i = 0; i < newPrices.Count; i++)
            {
                Console.Write("{0:F2}", newPrices[i]);
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.WriteLine($"Profit: {totalProfit:F2}");

            if (totalProfit+initialBudget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
