using System;
using System.Collections.Generic;
using System.Linq;

namespace _02DungeonestDark
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int coins = 0;

            int roomCounter = 0;

            List<string> input = Console.ReadLine().Split("|").ToList();

            for (int i = 0; i < input.Count; i++)
            {
                string[] commands = input[i].Split();
                int value = int.Parse(commands[1]);

                if (commands[0] != "potion" && commands[0] != "chest")
                {
                    roomCounter++;
                    health -= value;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {commands[0]}.");
                        Console.WriteLine($"Best room: {roomCounter}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {commands[0]}.");
                    }
                }

                else if (commands[0] == "potion")
                {
                    roomCounter++;

                    if (health + value > 100)
                    {
                        value = 100 - health;
                        health = 100;
                    }
                    else
                    {
                        health += value;
                    }

                    Console.WriteLine($"You healed for {value} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }

                else if (commands[0] == "chest")
                {
                    roomCounter++;
                    coins += value;
                    Console.WriteLine($"You found {value} coins.");
                }
            }

            /*You've made it!
            Coins: 120
            Health: 65
            */
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
