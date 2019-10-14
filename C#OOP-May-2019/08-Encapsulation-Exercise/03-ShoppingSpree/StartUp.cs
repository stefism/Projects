using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static List<Person> persons;
        static List<Product> products;

        public static void Main()
        {
            persons = new List<Person>();
            products = new List<Product>();

            string[] peoplesAndMoney = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            AddPersonToList(peoplesAndMoney);

            string[] propductsAndCosts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            AddProductToList(propductsAndCosts);

            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split();

                if (inputArgs[0] == "END")
                {
                    break;
                }

                string peopleName = inputArgs[0];
                string productToBuy = inputArgs[1];

                Person currentPerson = persons.FirstOrDefault(x => x.Name == peopleName);
                Product currentProduct = products.FirstOrDefault(x => x.Name == productToBuy);

                currentPerson.AddProductToList(currentProduct);
            }

            foreach (var person in persons)
            {
                int productCount = person.Products.Count;

                if (productCount > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(x => $"{x.Name}"))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }

        private static void AddProductToList(string[] propductsAndCosts)
        {
            foreach (var product in propductsAndCosts)
            {
                string[] productArgs = product.Split("=");

                string productName = productArgs[0];
                decimal productPrice = decimal.Parse(productArgs[1]);

                Product currentProduct = null;

                try
                {
                    currentProduct = new Product(productName, productPrice);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }

                if (currentProduct != null)
                {
                    products.Add(currentProduct);
                }
            }
        }

        private static void AddPersonToList(string[] peoplesAndMoney)
        {
            foreach (var people in peoplesAndMoney)
            {
                string[] peoplesArgs = people.Split("=");

                string peopleName = peoplesArgs[0];
                decimal peopleMoney = decimal.Parse(peoplesArgs[1]);

                Person person = null;

                try
                {
                    person = new Person(peopleName, peopleMoney);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }

                if (person != null)
                {
                    persons.Add(person);
                }
            }
        }
    }
}
