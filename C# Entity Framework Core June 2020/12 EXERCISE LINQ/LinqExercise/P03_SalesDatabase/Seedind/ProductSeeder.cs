using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.IOManagement.Contracts;
using P03_SalesDatabase.Seedind.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Seedind
{
    public class ProductSeeder : ISeeder
    {
        private readonly SalesContext dbContext;
        private readonly Random random;
        private readonly IWriter writer;

        public ProductSeeder(SalesContext context, Random random, IWriter writer)
        {
            dbContext = context;
            this.random = random;
            this.writer = writer;
        }

        public void Seed()
        {
            ICollection<Product> products = new List<Product>();
            string[] names = new string[]
            {
                "Academic Products",
                "Add-In Boards, Chips",
                "Audio Products",
                "Bar Code Readers",
                "Bridges, Routers, Gateways",
                "Cables & Accessories",
                "Cases ",
                "CD-Recorders",
                "Copiers",
                "Connectors",
                "CPU Chips",
                "Digital Cameras",
                "Drives & Storage",
                "Power Management Display",
                "DVD-ROM Devices"
            };

            for (int i = 0; i < 100; i++)
            {
                int nameIndex = random.Next(0, names.Length);
                
                string currProductName = names[nameIndex];
                double quantity = random.Next(50);
                decimal price = random.Next(1, 200) * 1.024m;

                Product product = new Product
                {
                    Name = currProductName,
                    Quantity = quantity,
                    Price = price
                };

                products.Add(product);
            }

            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();

            writer.WriteLine("Added products to base:");
            foreach (var product in products)
            {
                writer.WriteLine($"Name: {product.Name} | Quantity: {product.Quantity} | Price: ${product.Price}");
            }
        }
    }
}
