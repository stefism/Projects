using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_FeedTheAnimals_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            var animalsDailyLimit = new Dictionary<string, int>();
            var areaAnimals = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Last Info")
            {
                string[] splitedInput = input.Split(":");

                string command = splitedInput[0];
                string animalName = splitedInput[1];
                int food = int.Parse(splitedInput[2]);
                string area = splitedInput[3];

                if (command == "Add")
                {
                    if (!animalsDailyLimit.ContainsKey(animalName))
                    {
                        animalsDailyLimit[animalName] = 0;
                    }

                    animalsDailyLimit[animalName] += food;

                    if (!areaAnimals.ContainsKey(area))
                    {
                        areaAnimals[area] = new List<string>();
                    }

                    if (!areaAnimals[area].Contains(animalName))
                    {
                        areaAnimals[area].Add(animalName);
                    }
                }

                else if (command == "Feed")
                {
                    if (animalsDailyLimit.ContainsKey(animalName))
                    {
                        animalsDailyLimit[animalName] -= food;

                        if (animalsDailyLimit[animalName] < 1) // <= 0 ?
                        {
                            animalsDailyLimit.Remove(animalName);
                            areaAnimals[area].Remove(animalName);

                            Console.WriteLine($"{animalName} was successfully fed");
                        }
                    }
                }
                
                input = Console.ReadLine();
            }

            animalsDailyLimit = animalsDailyLimit
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            areaAnimals = areaAnimals
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Animals:");

            foreach (var animal in animalsDailyLimit)
            {
                Console.WriteLine($"{animal.Key} -> {animal.Value}g");
            }

            //Console.WriteLine(string.Join(Environment.NewLine, animalsDailyLimit
            //    .Select(x => $"{x.Key} -> {x.Value}g")));

            Console.WriteLine("Areas with hungry animals:");

            foreach (var animal in areaAnimals)
            {
                Console.WriteLine($"{animal.Key} : {animal.Value.Count}");
            }

            //Console.WriteLine(string.Join(Environment.NewLine, areaAnimals
            //    .Select(x => $"{x.Key} : {x.Value.Count}")));
        }
    }
}
