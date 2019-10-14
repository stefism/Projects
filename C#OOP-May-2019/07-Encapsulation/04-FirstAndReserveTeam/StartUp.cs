using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            Team team = new Team("SoftUni");

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();

                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                decimal salary = decimal.Parse(input[3]);

                Person person = null;
                
                try
                {
                    person = new Person(firstName, lastName, age, salary);
                }

                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);
                }

                if (person != null)
                {
                    persons.Add(person);
                }
            }

            if (persons != null)
            {
                foreach (var person in persons)
                {
                    team.AddPlayer(person);
                }
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        }
    }
}
