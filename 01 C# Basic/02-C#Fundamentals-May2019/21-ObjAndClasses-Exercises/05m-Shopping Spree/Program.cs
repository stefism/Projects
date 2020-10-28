using System;
using System.Collections.Generic;
using System.Linq;

namespace _05m_Shopping_Spree
{

    class Program
    {
        public static List<PeoplesAndProducts> ByedItemsForPrint = new List<PeoplesAndProducts>();
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
                    foreach (var item in ByedItemsForPrint)
                    {
                        //if (item.BuyedProducts.Count == 0)
                        //{
                        //    item.BuyedProducts.Add("Nothing bought");
                        //}

                        if (item.BuyedProducts.Count == 0)
                        {
                            Console.WriteLine($"{item.PeopleName} - Nothing bought");
                        }
                        else
                        {
                            Console.WriteLine($"{item.PeopleName} - {string.Join(", ", item.BuyedProducts)}");
                        }
                    }

                    break;
                }

                BuyProductOrNot(persons, command, products);

            }
        }
        static void AddProductToList(string personName, string productName)
        {
            foreach (var item in ByedItemsForPrint)
            {
                if (item.PeopleName == personName)
                {
                    item.BuyedProducts.Add(productName);
                }
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
                        AddProductToList(personName, productName);
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

                PeoplesAndProducts products = new PeoplesAndProducts();
                products.PeopleName = splitedPerson[0];
                ByedItemsForPrint.Add(products);

                //ByedItemsForPrint.Add(new PeoplesAndProducts {PeopleName = splitedPerson[0]});
                // Тоя ред замества горните три.
            }
            return outputPerson;
        }
    }

    class PeoplesAndProducts
    {
        public string PeopleName { get; set; }
        public List<string> BuyedProducts { get; set; }

        public PeoplesAndProducts()
        {
            BuyedProducts = new List<string>();
        }
    }

    class Person
    {
        public string PersonName { get; set; }
        public double PersonMoney { get; set; }
    }

    class Product
    {
        public string ProductName { get; set; }
        public double ProductCost { get; set; }
    }
}
