using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Cat>();

            dict["Ivan"] = new Cat
            {
                Poroda = "Persiiska",
                Age = 18
            };

            dict["Pepa"] = new Cat
            {
                Poroda = "Angorska",
                Age = 12
            };

            var cat = dict["Ivan"];
            //Console.WriteLine(cat.Age);

            foreach (var item in dict)
            {
                var currentCat = item.Value;
                Console.WriteLine(item.Key + " -> "+ currentCat.Poroda+" - " + currentCat.Age);
            }
        }
    }
    class Cat
    {
        public string Poroda { get; set; }
        public int Age { get; set; }
    }
}
