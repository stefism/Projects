using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SeashellTreasure
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsOfTheBeach = int.Parse(Console.ReadLine());

            char[][] beach = new char[rowsOfTheBeach][];

            for (int i = 0; i < rowsOfTheBeach; i++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                beach[i] = currentRow;
            }

            List<char> collectedSeashells = new List<char>();

            int seagulShells = 0;

            while (true)
            {
                string[] actions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = actions[0];

                if (command == "Sunset")
                {
                    break;
                }

                int beachRow = int.Parse(actions[1]);
                int beachCol = int.Parse(actions[2]);

                if (!IsCoordinatesValid(beach, beachRow, beachCol))
                {
                    continue;
                }

                if (command == "Collect")
                {
                    if (beach[beachRow][beachCol] != '-')
                    {
                        collectedSeashells.Add(beach[beachRow][beachCol]);

                        beach[beachRow][beachCol] = '-';
                    }
                }

                else if (command == "Steal")
                {
                    string direction = actions[3];

                    seagulShells = SeagullGetSeashellIfExist(beach, seagulShells, beachRow, beachCol);

                    switch (direction)
                    {
                        case "up":

                            for (int i = 0; i < 3; i++)
                            {
                                if (beachRow == 0)
                                {
                                    seagulShells = SeagullGetSeashellIfExist(beach, seagulShells, beachRow, beachCol);
                                    break;
                                }

                                if (beachRow > 0 && beach[beachRow - 1].Length >= beachCol)
                                {
                                    beachRow = beachRow - 1;
                                    seagulShells = SeagullGetSeashellIfExist(beach, seagulShells, beachRow, beachCol);
                                }
                            }

                            break;

                        case "down":

                            for (int i = 0; i < 3; i++)
                            {
                                if (beachRow == beach.Length - 1)
                                {
                                    seagulShells = SeagullGetSeashellIfExist(beach, seagulShells, beachRow, beachCol);
                                    break;
                                }

                                if (beachRow < beach.Length - 1 && beach[beachRow + 1].Length >= beachCol)
                                {
                                    beachRow = beachRow + 1;
                                    seagulShells = SeagullGetSeashellIfExist(beach, seagulShells, beachRow, beachCol);
                                }
                            }

                            break;

                        case "left":

                            for (int i = 0; i < 3; i++)
                            {
                                if (beachCol == 0)
                                {
                                    break;
                                }

                                beachCol--;
                                seagulShells = SeagullGetSeashellIfExist(beach, seagulShells, beachRow, beachCol);
                            }

                            break;

                        case "right":

                            for (int i = 0; i < 3; i++)
                            {
                                if (beachCol == beach[beachRow].Length - 1)
                                {
                                    break;
                                }

                                beachCol++;
                                seagulShells = SeagullGetSeashellIfExist(beach, seagulShells, beachRow, beachCol);
                            }

                            break;
                    }
                }
            }

            for (int i = 0; i < beach.Length; i++)
            {
                Console.WriteLine(string.Join(" ", beach[i]));
            }

            if (collectedSeashells.Count > 0)
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count} -> {string.Join(", ", collectedSeashells)}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count}");
            }

            Console.WriteLine($"Stolen seashells: {seagulShells}");
        }

        private static int SeagullGetSeashellIfExist(char[][] beach, int seagulShells, int beachRow, int beachCol)
        {
            if (beach[beachRow][beachCol] != '-')
            {
                seagulShells++;
                beach[beachRow][beachCol] = '-';
            }

            return seagulShells;
        }

        static bool IsCoordinatesValid(char[][] beach, int beachRow, int beachCol)
        {
            if (beachRow >= 0 && beachRow < beach.Length)
            {
                if (beachCol >= 0 && beachCol < beach[beachRow].Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
