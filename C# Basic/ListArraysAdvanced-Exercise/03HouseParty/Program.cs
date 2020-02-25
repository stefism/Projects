using System;
using System.Collections.Generic;
using System.Linq;

namespace _03HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> goingOrNot = Console.ReadLine().Split().ToList();

                if (goingOrNot.Count == 3)
                {
                    bool isExist = guests.Contains(goingOrNot[0]);

                    if (isExist)
                    {
                        Console.WriteLine($"{goingOrNot[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(goingOrNot[0]);
                    }
                }

                else
                {
                    bool isExist = guests.Contains(goingOrNot[0]);

                    if (isExist)
                    {
                        guests.Remove(goingOrNot[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{goingOrNot[0]} is not in the list!");
                    }
                }
            }

            foreach (var item in guests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
