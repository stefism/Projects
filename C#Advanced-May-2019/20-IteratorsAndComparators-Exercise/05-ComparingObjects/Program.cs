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
                string[] currrentPerson = Console.ReadLine().Split();

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

            int peopleToCompare = int.Parse(Console.ReadLine());

            int matchesCount = 0;

        }
    }
}
