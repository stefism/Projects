using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fielsSize = int.Parse(Console.ReadLine()); // Да ги направя на абсолютни стойности
            bool[] ladysIndexes = new bool[fielsSize];

            int[] initialIndexesOfLadyBugs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < initialIndexesOfLadyBugs.Length; i++)
            {
                if (initialIndexesOfLadyBugs[i] >= 0 && initialIndexesOfLadyBugs[i] <= ladysIndexes.Length - 1)
                {
                    ladysIndexes[initialIndexesOfLadyBugs[i]] = true;
                }
            }

            foreach (var item in ladysIndexes)
            {
                int result = Convert.ToInt32(item);
                Console.Write(result + " ");
            }
            Console.WriteLine();

            while (true)
            {
                string[] commands = Console.ReadLine().Split().ToArray();

                if (commands[0] == "end")
                {
                    break;
                }

                int flyFromIndex = int.Parse(commands[0]);
                int flyToIndex = int.Parse(commands[2]);
                string flyDirection = commands[1];

                switch (flyDirection)
                {
                    case "left":
                        if (flyFromIndex >= 0 && flyFromIndex <= ladysIndexes.Length - 1)
                        {
                            ladysIndexes = FlightLeft(flyFromIndex, flyToIndex, ladysIndexes);
                        }
                        break;

                    case "right":

                        break;
                }

                foreach (var item in ladysIndexes)
                {
                    int result = Convert.ToInt32(item);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
        }

        static bool[] FlightLeft(int flyFrom, int flyTo, bool[] ladysIndexes)
        {
            if (ladysIndexes[flyFrom] == true)
            {
                if (flyTo < 0)
                {
                    if (flyFrom + Math.Abs(flyTo) > ladysIndexes.Length)
                    {
                        ladysIndexes[flyFrom] = false;
                    }
                    else
                    {
                        for (int i = flyFrom + Math.Abs(flyTo); i <= ladysIndexes.Length - 1; i++)
                        {
                            if (i == ladysIndexes.Length-1)
                            {
                                if (ladysIndexes[ladysIndexes.Length - 1] == true)
                                {
                                    ladysIndexes[flyFrom] = false;
                                    break;
                                }
                            }
                           
                            if (ladysIndexes[i] == false) // Още логика! За ако всички полета за заети, да се маха калинката.
                            {
                                ladysIndexes[flyFrom] = false;
                                ladysIndexes[i] = true;
                                break;
                            }
                        }
                    }
                }
            }

            else
            {
                if (flyFrom - flyTo < 0)
                {
                    ladysIndexes[flyFrom] = false;
                }
                else
                {
                    for (int i = flyFrom - flyTo; i >= 0; i--)
                    {
                        if (ladysIndexes[i] == false)
                        {
                            ladysIndexes[flyFrom] = false;
                            ladysIndexes[i] = true;
                            break;
                        }
                    }
                }
            }

            return ladysIndexes;
        }
    }
}



