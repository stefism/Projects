using System;
using System.Collections.Generic;
using System.Text;

namespace _03E_AnimalFarm
{
    public class Engine
    {
        List<Animal> animals;

        public Engine()
        {
            animals = new List<Animal>();
        }

        public void Run()
        {
            while (true)
            {
                string[] animalArgs = Console.ReadLine().Split();

                if (animalArgs[0] == "End")
                {
                    break;
                }

                string animalType = animalArgs[0];
                string animalName = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);

                AddAnimalsToList(animalArgs, animalType, animalName, weight);

                string[] feedArgs = Console.ReadLine().Split();

                string foodType = feedArgs[0];
                int foodQuantity = int.Parse(feedArgs[1]);

                bool isFoodTypeCorrect = ValidateFood(animalType, foodType);

                if (!isFoodTypeCorrect)
                {
                    Console.WriteLine($"{animalType} does not eat {foodType}!");
                    continue;
                }

                animals[animals.Count - 1].IncreaseWeight(foodQuantity);
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }

        private bool ValidateFood(string animalType, string foodType)
        {
            if ((animalType == "Tiger" || animalType == "Dog" 
                || animalType == "Owl") && foodType != "Meat")
            {
                return false;
            }

            else if ((animalType == "Cat") && (foodType != "Vegetable" && foodType != "Meat"))
            {
                return false;
            }

            else if ((animalType == "Mouse") && (foodType != "Vegetable" && foodType != "Fruit"))
            {
                return false;
            }

            return true;
        }

        private void AddAnimalsToList(string[] animalArgs, string animalType, string animalName, double weight)
        {
            switch (animalType)
            {
                case "Owl":
                    double wingSize = double.Parse(animalArgs[3]);

                    Animal owl = new Owl(animalName, weight, wingSize);
                    animals.Add(owl);

                    ProduceSound("Owl");
                    break;

                case "Hen":
                    wingSize = double.Parse(animalArgs[3]);

                    Animal hen = new Hen(animalName, weight, wingSize);
                    animals.Add(hen);

                    ProduceSound("Hen");
                    break;

                case "Mouse":
                    string livingRegion = animalArgs[3];

                    Animal mouse = new Mouse(animalName, weight, livingRegion);
                    animals.Add(mouse);

                    ProduceSound("Mouse");
                    break;

                case "Dog":
                    livingRegion = animalArgs[3];

                    Animal dog = new Dog(animalName, weight, livingRegion);
                    animals.Add(dog);

                    ProduceSound("Dog");
                    break;

                case "Cat":
                    livingRegion = animalArgs[3];
                    string breed = animalArgs[4];

                    Animal cat = new Cat(animalName, weight, livingRegion, breed);
                    animals.Add(cat);

                    ProduceSound("Cat");
                    break;

                case "Tiger":
                    livingRegion = animalArgs[3];
                    breed = animalArgs[4];

                    Animal tiger = new Tiger(animalName, weight, livingRegion, breed);
                    animals.Add(tiger);

                    ProduceSound("Tiger");
                    break;
            }
        }

        private void ProduceSound(string animalType)
        {
            switch (animalType)
            {
                case "Owl":
                    Console.WriteLine("Hoot Hoot");
                    break;

                case "Hen":
                    Console.WriteLine("Cluck");
                    break;

                case "Mouse":
                    Console.WriteLine("Squeak");
                    break;

                case "Dog":
                    Console.WriteLine("Woof!");
                    break;

                case "Cat":
                    Console.WriteLine("Meow");
                    break;

                case "Tiger":
                    Console.WriteLine("ROAR!!!");
                    break;
            }
        }
    }
}
