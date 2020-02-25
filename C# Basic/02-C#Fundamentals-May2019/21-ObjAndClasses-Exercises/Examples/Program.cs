using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> peopleNames = Console.ReadLine().Split().ToList();
            List<People> peoples = new List<People>();

            while (true)
            {
                List<string> peoplesAndProducts = Console.ReadLine().Split().ToList();
                string people = peoplesAndProducts[0];

                if (people == "End")
                {
                    foreach (var item in peoples)
                    {
                        Console.WriteLine(item.Name + " - " + string.Join(", ", item.Products));
                    }
                    break;
                }

                string products = peoplesAndProducts[1];

                bool isNameExist = IsNameExist(peoples, people);

                if (!isNameExist)
                {
                    People currentPeople = new People();
                    currentPeople.Name = people;
                    currentPeople.Products.Add(products);
                    peoples.Add(currentPeople);
                }
                else
                {
                    foreach (var item in peoples)
                    {
                        if (item.Name == people)
                        {
                            item.Products.Add(products);
                        }
                    }
                }
            }
        }
        static bool IsNameExist(List<People> peoples, string name)
        {
            foreach (var item in peoples)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }

            return false;
        }
    }
    class People
    {
        public string Name { get; set; }
        public List<string> Products { get; set; }

        public People()
        {
            Products = new List<string>();
            Name = string.Empty;
        }
    }
}
