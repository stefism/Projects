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
                        animals[animalName].Add(new Animals{FoodInGrams = animalFood, Area = animalArea });
                    }
                    else
                    {
                        foreach (var item in animals)
                        {
                            if (item.Key == animalName)
                            {
                                foreach (var animalValues in animals.Values)
                                {
                                    foreach (var item2 in animalValues)
                                    {
                                        item2.FoodInGrams += animalFood;
                                        break;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                else if (command == "Feed")
                {
                    bool isFeed = false;

                    foreach (var animalValues in animals.Values)
                    {
                        foreach (var item in animalValues)
                        {
                            item.FoodInGrams -= animalFood;

                            if (item.FoodInGrams <= 0)
                            {
                                isFeed = true;
                            }
                        }
                    }

                    if (isFeed)
                    {
                        Console.WriteLine($"{animalName} was successfully fed");
                        animals.Remove(animalName);
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
