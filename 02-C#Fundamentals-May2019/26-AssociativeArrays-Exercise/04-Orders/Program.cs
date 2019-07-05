using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var productDictionary = new Dictionary<string, List<Products>>();
            int[] oldNumber = new int[1];

            while (true)
            {
                List<string> currentProduct = Console.ReadLine().Split().ToList();

                string product = currentProduct[0];

                if (product == "buy")
                {
                    foreach (var item in productDictionary)
                    {
                        double[] totalProductPrice = new double[1];
                        totalProductPrice = item.Value.Select(a => a.ProductTotalPrice).ToArray();
                        Console.WriteLine($"{item.Key} -> {totalProductPrice[0]:F2}");
                    }
                    break;
                }

                double price = double.Parse(currentProduct[1]);
                int quantity = int.Parse(currentProduct[2]);

                Products allProducts = new Products();

                if (!productDictionary.ContainsKey(product))
                {
                    allProducts.ProductQuantity = 0;
                }
                else
                {
                    oldNumber = productDictionary[product].Select(a => a.ProductQuantity).ToArray();
                }
                allProducts.ProductPrice = price;
                allProducts.ProductQuantity = quantity;

                productDictionary[product] = new List<Products>();

                allProducts.ProductQuantity = quantity + oldNumber[0];
                double totalPrice = Products.CalculateTotalPrice(allProducts.ProductPrice, allProducts.ProductQuantity);
                allProducts.ProductTotalPrice = totalPrice;

                productDictionary[product].Add(allProducts);
            }
        }
    }
    class Products
    {
        public double ProductPrice;
        public int ProductQuantity;
        public double ProductTotalPrice;

        public static double CalculateTotalPrice(double price, int quantity)
        {
            double totalPrice = price * quantity;
            return totalPrice;
        }

        public Products()
        {
            ProductTotalPrice = ProductPrice * ProductQuantity;
        }
    }
}
