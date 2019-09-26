using System;
using System.Collections.Generic;

namespace _06_EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashSetPersons = new HashSet<Person>();
            SortedSet<Person> sortedSetPersons = new SortedSet<Person>();

            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                string[] currentPerson = Console.ReadLine().Split();

                string personName = currentPerson[0];
                int personAge = int.Parse(currentPerson[1]);

                Person person = new Person(personName, personAge);

                hashSetPersons.Add(person);
                sortedSetPersons.Add(person);
            }

            Console.WriteLine(hashSetPersons.Count);
            Console.WriteLine(sortedSetPersons.Count);

            ;
        }
    }
}
