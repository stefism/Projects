using AnimalZooA1.Contracts;
using System;

namespace AnimalZooA1.Data
{
	internal class Engine : IEngine
	{
		public void Run()
		{
			Animal monkey = new Monkey();
			Animal lion = new Lion();
			Animal elephant = new Elephant();

			Console.WriteLine("This is the A1 Zoo. There is 3 types of animal;");
			Console.WriteLine("Monkey");
			Console.WriteLine("Lion");
			Console.WriteLine("Elephant");
			Console.WriteLine("And 2 type of animal actions;");
			Console.WriteLine("Feed");
			Console.WriteLine("Hungry");
			Console.WriteLine("For example, is you want to feed monkey, type on the console 'Monkey Feed'");
			Console.WriteLine("For check how animals is left in the zoo, type 'Check'");
			Console.WriteLine("If you want to Exit, type 'Exit'");

			while(true)
			{
				string[] commands = Console.ReadLine().Split();

				string animal = commands[0].ToLower();

				if(animal == "exit")
				{
					Console.WriteLine("Thank's for using A1 Zoo :)");
					break;
				}
				else if(animal == "check")
				{
					AnimalsLeft(new[] { monkey, lion, elephant });
					continue;
				}

				string action = commands[1].ToLower();

				if(animal == "monkey")
				{
					AnimalActions(monkey, action);
				}
				else if(animal == "lion")
				{
					AnimalActions(lion, action);
				}
				else if(animal == "elephant")
				{
					AnimalActions(elephant, action);
				}
				else
				{
					Console.WriteLine("This animal is not exist in the Zoo.");
					Console.WriteLine("The possible animals is 'Monkey', 'Lion' and 'Elephant'.");
					Console.WriteLine("Please select the correct animal or correct action:");

					continue;
				}
			}
		}

		private void AnimalActions(Animal animal, string action)
		{
			string typeOfAnimal = string.Empty;

			switch(animal)
			{
				case var _ when animal is Monkey:
					typeOfAnimal = "Monkey";
					break;

				case var _ when animal is Elephant:
					typeOfAnimal = "Elephant";
					break;

				case var _ when animal is Lion:
					typeOfAnimal = "Lion";
					break;
			}

			switch(action)
			{
				case "feed":
					if(animal.AnimalsLeft == 0)
					{
						Console.WriteLine($"There are no more {typeOfAnimal} in the zoo.");
					}
					else
					{
						animal.Feed();
						Console.WriteLine($"Thanks for food. Now {typeOfAnimal} health is {animal.Health}");
					}
					
					break;

				case "hungry":
					if(animal.AnimalsLeft == 0)
					{
						Console.WriteLine($"There are no more {typeOfAnimal} in the zoo.");
					}
					else
					{
						animal.Stavration();
						Console.WriteLine($"Now {typeOfAnimal} health is {animal.Health}");
						DecreaseAnimals(animal);
					}

					break;
			}
		}

		private void DecreaseAnimals(Animal animal)
		{
			string animalsLeft = animal.AnimalsLeft > 0 ? animal.AnimalsLeft.ToString() : "No more";
			
			if(animal is Monkey)
			{
				if(animal.Health < 40)
				{
					DecreaseNumberOfAnimal(animal);
					Console.WriteLine($"One monkey is died. {animalsLeft} Monkeys left in the Zoo.");
				}
			}
			else if(animal is Lion)
			{
				if(animal.Health < 50)
				{
					DecreaseNumberOfAnimal(animal);
					Console.WriteLine($"One Lion is died. {animalsLeft} Lions left in the Zoo.");
				}
			}
			else if(animal is Elephant)
			{
				if(animal.Health < 70)
				{
					DecreaseNumberOfAnimal(animal);
					Console.WriteLine($"One Elephant is died. {animal.AnimalsLeft} Elephants left in the Zoo.");
				}
			}
		}

		private void AnimalsLeft(Animal[] animals)
		{
			foreach(var animal in animals)
			{
				if(animal is Monkey)
				{
					Console.WriteLine($"Monkey left: {animal.AnimalsLeft}");
				}
				else if(animal is Lion)
				{
					Console.WriteLine($"Lions left: {animal.AnimalsLeft}");
				}
				else if(animal is Elephant)
				{
					Console.WriteLine($"Elephants left: {animal.AnimalsLeft}");
				}
			}
		}

		private void DecreaseNumberOfAnimal(Animal animal)
		{
			animal.AnimalsLeft--;
			animal.Health = 100;
		}
	}
}
