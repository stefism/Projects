using System;
using System.Collections.Generic;
using System.Linq;

namespace _05m_Shopping_Spree
{

    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputPersons = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> splitedPerson = new List<string>();

            List<string> inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> splitedProduct = new List<string>();

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            persons = CreatePersonsList(inputPersons, splitedPerson, persons);
            products = CreateProductList(inputProducts, splitedProduct, products);

            while (true)
            {
                List<string> command = Console.ReadLine().Split().ToList();

                if (command[0] == "END")
                {
                    foreach (var item in persons)
                    {
                        //if (item.BuyedProducts.Count == 0)
                        //{
                        //    item.BuyedProducts.Add("Nothing bought");
                        //}

                        if (item.BoughtProducts.Count == 0)
                        {
                            Console.WriteLine($"{item.PersonName} - Nothing bought");
                        }
                        else
                        {
                            Console.WriteLine($"{item.PersonName} - {string.Join(", ", item.BoughtProducts)}");
                        }
                    }

                    break;
                }

                BuyProductOrNot(persons, command, products);

            }
        }
        
        static void BuyProductOrNot(List<Person> persons, List<string> command, List<Product> products)
        {
            string personName = command[0];
            string productName = command[1];

            foreach (var item in persons)
            {
                if (item.PersonName == personName)
                {
                    double productPrice = ReturnProductPrice(productName, products);

                    if (item.PersonMoney >= productPrice)
                    {
                        Console.WriteLine($"{item.PersonName} bought {productName}");
                        item.PersonMoney -= productPrice;
                        item.BoughtProducts.Add(productName);
                    }
                    else
                    {
                        Console.WriteLine($"{item.PersonName} can't afford {productName}");
                    }
                }
            }
        }
        static double ReturnProductPrice(string productName, List<Product> products)
        {
            double productPrice = 0;

            foreach (var item in products)
            {
                if (item.ProductName == productName)
                {
                    productPrice = item.ProductCost;
                    return productPrice;
                }
            }
            return productPrice;
        }

        static List<Product> CreateProductList(List<string> inputProducts, List<string> splitedProduct, List<Product> outputProduct)
        {
            for (int i = 0; i < inputProducts.Count; i++)
            {
                Product product = new Product();
                splitedProduct = inputProducts[i].Split("=").ToList();
                product.ProductName = splitedProduct[0];
                product.ProductCost = double.Parse(splitedProduct[1]);
                outputProduct.Add(product);
            }
            return outputProduct;
        }

        static List<Person> CreatePersonsList(List<string> inputPerson, List<string> splitedPerson, List<Person> outputPerson)
        {
            for (int i = 0; i < inputPerson.Count; i++)
            {
                Person person = new Person();
                splitedPerson = inputPerson[i].Split("=").ToList();
                person.PersonName = splitedPerson[0];
                person.PersonMoney = double.Parse(splitedPerson[1]);
                outputPerson.Add(person);
            }
            return outputPerson;
        }
    }

    class Person
    {
        public string PersonName { get; set; }
        public double PersonMoney { get; set; }
        public List<string> BoughtProducts { get; set; }

        public Person()
        {
            BoughtProducts = new List<string>();
        }
    }

    class Product
    {
        public string ProductName { get; set; }
        public double ProductCost { get; set; }
    }
}
