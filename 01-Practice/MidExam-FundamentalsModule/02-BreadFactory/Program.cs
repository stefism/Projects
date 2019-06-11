using System;
using System.Linq;

namespace _02_BreadFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // (Demo) Technology Fundamentals Mid Exam - 02 March 2019

            string[] inputCases = Console.ReadLine().Split("|");

            int energy = 100;
            int coins = 100;

            for (int i = 0; i < inputCases.Length; i++)
            {
                string[] currentCase = inputCases[i].Split("-");

                string command = currentCase[0];
                int value = int.Parse(currentCase[1]);

                switch (command)
                {
                    case "rest":
                        if (energy + value > 100)
                        {
                            int receivedEnergy = 100 - energy;
                            energy = 100;
                            Console.WriteLine($"You gained {receivedEnergy} energy.");
                            Console.WriteLine($"Current energy: {energy}.");
                        }
                        else
                        {
                            energy += value;
                            Console.WriteLine($"You gained {value} energy.");
                            Console.WriteLine($"Current energy: {energy}.");
                        }
                        break;

                    case "order":
                        energy -= 30;

                        if (energy < 0)
                        {
                            energy += 50; // energy += 50;
                            Console.WriteLine("You had to rest!");
                        }
                        else
                        {
                            coins += value;
                            Console.WriteLine($"You earned {value} coins.");
                        }
                        break;

                    default:
                        if (coins >= value) // Тука
                        {
                            Console.WriteLine($"You bought {command}.");
                            coins -= value;
                        }
                        else
                        {
                            Console.WriteLine($"Closed! Cannot afford {command}.");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {energy}");
        }
    }
}
