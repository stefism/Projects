using System;
using System.Linq;
using System.Collections.Generic;

namespace _03_ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] currentShopInfo = Console.ReadLine().Split(", ");

                if (currentShopInfo[0] == "Revision")
                {
                    break;
                }

                string shop = currentShopInfo[0];
                string product = currentShopInfo[1];
                double price = double.Parse(currentShopInfo[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }

                shops[shop].Add(product, price);
            }

            foreach (var currentShop in shops)
            {
                Console.WriteLine($"{currentShop.Key}->");

                foreach (var products in currentShop.Value)
                {
                    Console.WriteLine($"Product: {products.Key}, Price: {products.Value}");
                }
            }
        }
    }
}
