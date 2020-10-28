using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new List<People>();

            while (true)
            {
                List<string> currentPeople = Console.ReadLine().Split().ToList();

                if (currentPeople[0] == "End")
                {
                    peoples = People.OrderPeopleByAge(peoples);

                    //foreach (var item in peoples)
                    //{
                    //    Console.WriteLine(item);
                    //}

                    Console.WriteLine(string.Join(Environment.NewLine, peoples)); // Яко. Замества горния цикъл.

                    break;
                }

                string name = currentPeople[0];
                int id = int.Parse(currentPeople[1]);
                int age = int.Parse(currentPeople[2]);

                People people = new People(name, id, age);

                peoples.Add(people);
            }
        }
    }
    class People
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }

        public People(string name, int id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }
        public static List<People> OrderPeopleByAge(List<People> peoples)
        {
            List<People> sortedPeople = peoples.OrderBy(a => a.Age).ToList();

            return sortedPeople;
        }
        public override string ToString()
        {
            return $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
        }
    }
}
