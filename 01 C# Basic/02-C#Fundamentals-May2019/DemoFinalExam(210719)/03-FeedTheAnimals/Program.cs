using System;
using System.Linq;
using System.Collections.Generic;

namespace _03_FeedTheAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new Dictionary<string, List<Animals>>();

            while (true)
            {
                string[] currentAnimalInfo = Console.ReadLine().Split(":");

                string command = currentAnimalInfo[0];

                if (command == "Last Info")
                {
                    animals = animals.OrderByDescending(x => x.Value[0].FoodInGrams)
                        .ThenBy(x => x.Key)
                        .ToDictionary(x => x.Key, x => x.Value);

                    Console.WriteLine("Animals:");
                    Console.WriteLine(string.Join(Environment.NewLine, animals.Select(x => $"{x.Key} -> {x.Value[0].FoodInGrams}g")));

                    Console.WriteLine("Areas with hungry animals:");

                    var hungryAreas = new Dictionary<string, int>();

                    foreach (var item in animals)
                    {
                        string currentArea = item.Value[0].Area;

                        if (!hungryAreas.ContainsKey(currentArea))
                        {
                            hungryAreas[currentArea] = 0;
                        }

                        hungryAreas[currentArea]++;
                    }

                    hungryAreas = hungryAreas.OrderByDescending(x => x.Value)
                        .ThenByDescending(x => x.Key)
                        .ToDictionary(x => x.Key, x => x.Value);

                    Console.WriteLine(string.Join(Environment.NewLine, hungryAreas.Select(x => $"{x.Key} : {x.Value}")));

                    break;
                }

                string animalName = currentAnimalInfo[1];
                int animalFood = int.Parse(currentAnimalInfo[2]);
                string animalArea = currentAnimalInfo[3];

                if (command == "Add")
                {
                    if (!animals.ContainsKey(animalName))
                    {
                        animals[animalName] = new List<Animals>();
                        animals[animalName].Add(new Animals { FoodInGrams = animalFood, Area = animalArea });
                    }
                    else
                    {
                        animals[animalName].Select(x => x.FoodInGrams += animalFood).ToList();
                    }
                }

                else if (command == "Feed")
                {
                    if (animals.ContainsKey(animalName))
                    {
                        animals[animalName].Select(x => x.FoodInGrams -= animalFood).ToList();

                        if (animals[animalName][0].FoodInGrams <= 0)
                        {
                            Console.WriteLine($"{animalName} was successfully fed");
                            animals.Remove(animalName);
                        }
                    }
                }
            }
        }
    }

    class Animals
    {
         public int FoodInGrams { get; set; }
        public string Area { get; set; }

        public Animals()
        {
            FoodInGrams = 0;
            Area = string.Empty;
        }
    }
}
