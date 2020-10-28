using System;
using System.Linq;
using System.Collections.Generic;

namespace _05_FilterByAge_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            var persones = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] person = Console.ReadLine().Split(", ");
                string name = person[0];
                int age = int.Parse(person[1]);

                persones.Add(new KeyValuePair<string, int>(name, age));
            }

            string filter = Console.ReadLine();
            int peopleAge = int.Parse(Console.ReadLine());
            string[] nameOrAge = Console.ReadLine().Split();

            persones.Where(peoples => filter == "younger"
            ? peoples.Value < peopleAge
            : peoples.Value >= peopleAge)
                .ToList()
                .ForEach(peoples => PrintResult(peoples, nameOrAge));
        }

        static void PrintResult(KeyValuePair<string, int> persones, string[] nameOrAge)
        {
            if (nameOrAge.Length == 2)
            {
                Console.WriteLine(nameOrAge[0] == "name"
                    ? $"{persones.Key} - {persones.Value}"
                    : $"{persones.Value} - {persones.Key}");
            }
            else
            {
                Console.WriteLine(nameOrAge[0] == "name"
                    ? $"{persones.Key}"
                    : $"{persones.Value}");
            }
        }
    }
}
