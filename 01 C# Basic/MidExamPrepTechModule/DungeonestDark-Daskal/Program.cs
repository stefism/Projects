using System;

namespace DungeonestDark_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split('|');

            int initialHealth = 100;
            int initialCoins = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currentRoom = rooms[i].Split();
                string command = currentRoom[0];
                int number = int.Parse(currentRoom[1]);

                if (command == "potion")
                {
                    int currentHealth = initialHealth;
                    initialHealth += number;

                    if (initialHealth > 100)
                    {
                        Console.WriteLine($"You healed for {100 - currentHealth} hp.");
                        Console.WriteLine("Current health: 100 hp.");
                        initialHealth = 100;
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }
                }

                else if (command == "chest")
                {
                    initialCoins += number;
                    Console.WriteLine($"You found {number} coins.");
                }

                else //monster
                {
                    string monster = command;
                    initialHealth -= number;

                    if (initialHealth > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i+1}");
                        return;
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {initialCoins}");
            Console.WriteLine($"Health: {initialHealth}");
        }
    }
}
