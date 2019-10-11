using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static string animalName;
        public static string animalGender;
        public static string animalType;
        public static List<Animal> animals;

        public static void Main(string[] args)
        {
            animals = new List<Animal>();

            while (true)
            {
                animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                string[] animalProperties = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                animalName = animalProperties[0];
                bool isAge = int.TryParse(animalProperties[1], out int animalAge);

                List<string> validAnimals = new List<string>
                {
                    "Dog",
                    "Frog",
                    "Cat",
                    "Kitten",
                    "Tomcat"
                };

                if (!isAge || animalAge <= 0 || !validAnimals.Contains(animalType))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (animalProperties.Length == 3)
                {
                    animalGender = animalProperties[2];

                    if (animalGender != "Male" && animalGender != "Female")
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                
                AddAnimalToList(animalAge);
            }

            foreach (var animal in animals)
            {
                //string[] type = animal.GetType().ToString().Split(".");

                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                animal.ProduceSound();
            }
        }

        private static void AddAnimalToList(int animalAge)
        {
            if (animalType == "Cat")
            {
                Cat cat = new Cat(animalName, animalAge, animalGender);
                animals.Add(cat);
            }
            else if (animalType == "Dog")
            {
                Dog dog = new Dog(animalName, animalAge, animalGender);
                animals.Add(dog);
            }
            else if (animalType == "Frog")
            {
                Frog frog = new Frog(animalName, animalAge, animalGender);
                animals.Add(frog);
            }
            else if (animalType == "Kitten")
            {
                Kitten kitten = new Kitten(animalName, animalAge);
                animals.Add(kitten);
            }
            else if (animalType == "Tomcat")
            {
                Tomcat tomcat = new Tomcat(animalName, animalAge);
                animals.Add(tomcat);
            }
        }
    }
}
