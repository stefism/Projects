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

                if (animalProperties.Length != 3)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                animalName = animalProperties[0];
                bool isAge = int.TryParse(animalProperties[1], out int animalAge);

                if (!isAge)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                animalGender = animalProperties[2];
                
                AddAnimalToList(animalAge);
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
