using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _01e_Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            // >>([A-Z]+[a-z]+|[A-Z]+)<<(\d+\.?\d+)!(\d+)
            // >>(?<name>[A-Z]+[a-z]+|[A-Z]+)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)

            var regex = new Regex(@">>(?<name>[A-Z]+[a-z]+|[A-Z]+)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)");

            List<string> furnitures = new List<string>();

            double totalMoney = 0;

            while (true)
            {
                string currentInfo = Console.ReadLine();

                var matches = regex.Matches(currentInfo);

                foreach (Match item in matches)
                {
                    string furniture = item.Groups["name"].Value;
                    double price = double.Parse(item.Groups["price"].Value);
                    int quantity = int.Parse(item.Groups["quantity"].Value);

                    furnitures.Add(furniture);

                    totalMoney += price * quantity;
                }

                if (currentInfo == "Purchase")
                {
                    Console.WriteLine("Bought furniture:");

                    foreach (var item in furnitures)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine($"Total money spend: {totalMoney:F2}");
                    break;
                }
            }
        }
    }
}
