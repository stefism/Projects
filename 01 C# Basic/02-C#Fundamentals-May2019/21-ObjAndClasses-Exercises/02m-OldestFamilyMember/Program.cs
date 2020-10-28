using System;
using System.Collections.Generic;
using System.Linq;

namespace _02m_OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeoples = int.Parse(Console.ReadLine());
            List<Peoples> peoples = new List<Peoples>();

            for (int i = 0; i < numberOfPeoples; i++)
            {
                List<string> people = Console.ReadLine().Split().ToList();
                Peoples currentPeople = new Peoples(people[0], int.Parse(people[1]));

                peoples.Add(currentPeople);
            }

            int maxAge = peoples.Max(a => a.Age);

            foreach (var item in peoples)
            {
                if (item.Age == maxAge)
                {
                    Console.WriteLine($"{item.Name} {item.Age}");
                    break;
                }
            }
        }
    }
    class Peoples
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Peoples(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
