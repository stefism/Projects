using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingDictionary = new Dictionary<string, string>();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentCommand = Console.ReadLine().Split();

                string command = currentCommand[0];
                string peopleName = currentCommand[1];
                
                switch (command)
                {
                    case "register":
                        string ticketNumber = currentCommand[2];

                        if (!parkingDictionary.ContainsKey(peopleName))
                        {
                            parkingDictionary[peopleName] = ticketNumber;
                            Console.WriteLine($"{peopleName} registered {ticketNumber} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {parkingDictionary[peopleName]}");
                        }
                        break;

                    case "unregister":
                        if (!parkingDictionary.ContainsKey(peopleName))
                        {
                            Console.WriteLine($"ERROR: user {peopleName} not found");
                        }
                        else
                        {
                            parkingDictionary.Remove(peopleName);
                            Console.WriteLine($"{peopleName} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (var item in parkingDictionary)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
