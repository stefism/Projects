using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            products = new List<Product>();
            Name = name;
            Money = money;
        }

        public string Name
        {
            get => name;

            set
            {
                if (value == string.Empty || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get => money;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products 
        {
            get 
            {
                return products.AsReadOnly();
            }
        }

        public void AddProductToList(Product product)
        {
            if (Money >= product.Cost)
            {
                products.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }
}
