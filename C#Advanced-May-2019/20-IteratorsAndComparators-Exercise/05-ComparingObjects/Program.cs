using System;
using System.Linq;
using System.Collections.Generic;

namespace _05_ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();

            while (true)
            {
                string[] currrentPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currrentPerson[0] == "END")
                {
                    break;
                }

                string personName = currrentPerson[0];
                int personAge = int.Parse(currrentPerson[1]);
                string personTown = currrentPerson[2];

                Person person = new Person(personName, personAge, personTown);

                personList.Add(person);
            }

            int numberOfPersonToCompare = int.Parse(Console.ReadLine());

            var personToCompare = personList[numberOfPersonToCompare - 1];

            int matchesCount = 1;
            int differentPeopleCount = 0;

            foreach (var person in personList)
            {
                if (personToCompare == person)
                {
                    continue;
                }

                if (person.CompareTo(personToCompare) != 0)
                {
                    differentPeopleCount++;
                }
                else
                {
                    matchesCount++;
                }
            }

            if (matchesCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matchesCount} {differentPeopleCount} {personList.Count}");
            }
        }
    }
}
