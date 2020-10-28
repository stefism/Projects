using System;
using System.Linq;
using System.Collections.Generic;

namespace _05_FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, int>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] currentInput = Console.ReadLine().Split(", ");

                string name = currentInput[0];
                int age = int.Parse(currentInput[1]);

                people[name] = age;
            }

            string older = Console.ReadLine();
            int searchedAge = int.Parse(Console.ReadLine());
            string[] nameAndAge = Console.ReadLine().Split();

            PrintResult(people, older, searchedAge, nameAndAge);
        }

        static void PrintResult(Dictionary<string, int> people, string older, int age, string[] nameAndAge)
        {
            if (nameAndAge.Length == 2 && older == "older")
            {
                Console.WriteLine(string.Join(Environment.NewLine, people
                    .Where(x => x.Value >= age).Select(x => $"{x.Key} - {x.Value}")));
            }

            else if (nameAndAge.Length == 2 && older == "younger")
            {
                Console.WriteLine(string.Join(Environment.NewLine, people
                    .Where(x => x.Value < age).Select(x => $"{x.Key} - {x.Value}")));
            }

            else if (nameAndAge[0] == "name" && older == "younger")
            {
                Console.WriteLine(string.Join(Environment.NewLine, people
                    .Where(x => x.Value < age).Select(x => $"{x.Key}")));
            }

            else if (nameAndAge[0] == "name" && older == "older")
            {
                Console.WriteLine(string.Join(Environment.NewLine, people
                    .Where(x => x.Value >= age).Select(x => $"{x.Key}")));
            }

            else if (nameAndAge[0] == "age" && older == "younger")
            {
                Console.WriteLine(string.Join(Environment.NewLine, people
                    .Where(x => x.Value < age).Select(x => $"{x.Value}")));
            }

            else if (nameAndAge[0] == "age" && older == "older")
            {
                Console.WriteLine(string.Join(Environment.NewLine, people
                    .Where(x => x.Value >= age).Select(x => $"{x.Value}")));
            }
        }
    }
}
