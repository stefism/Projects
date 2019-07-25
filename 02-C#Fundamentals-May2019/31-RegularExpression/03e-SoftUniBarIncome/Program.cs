using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03e_SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            // %(?<customer>[A-Z][a-z]+)%[^|\$%\.]*<(?<product>[A-Za-z]+)>[^|\$%\.]*\|(?<count>\d+)\|[^|\$%\.0-9]*(?<price>\d+\.?\d+)\$

            var regex = new Regex(@"%(?<customer>[A-Z][a-z]+)%[^|\$%\.]*<(?<product>[A-Za-z]+)>[^|\$%\.]*\|(?<count>\d+)\|[^|\$%\.0-9]*(?<price>\d+\.?\d+)\$");

            double totalIncome = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    Console.WriteLine($"Total income: {totalIncome:F2}");

                    break;
                }
                var matches = regex.Match(input);

                if (matches.Success)
                {
                    string customer = matches.Groups["customer"].Value;
                    string product = matches.Groups["product"].Value;
                    int numberOfProduct = int.Parse(matches.Groups["count"].Value);
                    double price = double.Parse(matches.Groups["price"].Value);

                    double finalPrice = price * numberOfProduct;

                    totalIncome += price * numberOfProduct;

                    Console.WriteLine($"{customer}: {product} - {finalPrice:F2}");
                }
            }
        }
    }
}
