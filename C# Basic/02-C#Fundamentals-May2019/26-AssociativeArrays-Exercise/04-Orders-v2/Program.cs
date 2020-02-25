using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Orders_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, Products>();

            while (true)
            {
                string[] currentProduct = Console.ReadLine().Split();

                string productName = currentProduct[0];

                if (productName == "buy")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, products
                        .Select(x => $"{x.Key} -> {(x.Value.ClassPrice * x.Value.ClassQuantity):F2}")));
                    break;
                }

                double productPrice = double.Parse(currentProduct[1]);
                int productQuantity = int.Parse(currentProduct[2]);

                if (!products.ContainsKey(productName))
                {
                    products[productName] = new Products();
                }

                products[productName].ClassQuantity += productQuantity;
                products[productName].ClassPrice = productPrice;
            }
        }
    }
    class Products
    {
        public double ClassPrice { get; set; }
        public int ClassQuantity { get; set; }
    }
}
