using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> vegetables = new Dictionary<string, int>
            {
                {"Carrots", 0},
                {"Potatoes", 0},
                {"Lettuce", 0}
            };

            int matrixRow = int.Parse(Console.ReadLine());
            int harmedCount = 0;

            string[][] matrix = new string[matrixRow][];

            for (int i = 0; i < matrixRow; i++)
            {
                string[] input = Console.ReadLine().Split();

                matrix[i] = input;
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }

                string currendCommand = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                switch (currendCommand)
                {
                    case "Harvest":
                        if (row < 0 || row > matrix.Length-1)
                        {
                            continue;
                        }

                        if (col < 0 || col > matrix[row].Length - 1)
                        {
                            continue;
                        }

                        if (matrix[row][col] == " ")
                        {
                            continue;
                        }

                        string vegetableType = matrix[row][col];

                        if (vegetableType == "L")
                        {
                            vegetables["Lettuce"]++;
                        }
                        else if (vegetableType == "P")
                        {
                            vegetables["Potatoes"]++;
                        }
                        else if (vegetableType == "C")
                        {
                            vegetables["Carrots"]++;
                        }

                        matrix[row][col] = " ";
                        break;

                    case "Mole":
                        if (row < 0 || row > matrix.Length - 1)
                        {
                            continue;
                        }

                        if (col < 0 || col > matrix[row].Length - 1)
                        {
                            continue;
                        }

                        string direction = command[3];

                        if (direction == "up")
                        {
                            while (row >= 0)
                            {
                                if (matrix[row][col] != " ")
                                {
                                    matrix[row][col] = " ";
                                    harmedCount++;
                                }

                                row -= 2;
                            }
                        }
                        else if (direction == "down")
                        {
                            while (row < matrix.Length)
                            {
                                if (matrix[row][col] != " ")
                                {
                                    matrix[row][col] = " ";
                                    harmedCount++;
                                }

                                row += 2;
                            }
                        }
                        else if (direction == "left")
                        {
                            while (col >= 0)
                            {
                                if (matrix[row][col] != " ")
                                {
                                    matrix[row][col] = " ";
                                    harmedCount++;
                                }
                                col -= 2;
                            }
                        }
                        else if (direction == "right")
                        {
                            while (col < matrix[row].Length)
                            {
                                if (matrix[row][col] != " ")
                                {
                                    matrix[row][col] = " ";
                                    harmedCount++;
                                }
                                col += 2;
                            }
                        }
                        break;
                }
            }

            PrintMatrix(matrix);
            Console.WriteLine(string.Join(Environment.NewLine, vegetables
                .Select(x => $"{x.Key}: {x.Value}")));
            Console.WriteLine($"Harmed vegetables: {harmedCount}");

            void PrintMatrix(string[][] matrixs)
            {
                for (int i = 0; i < matrixs.Length; i++)
                {
                    Console.WriteLine(string.Join(" ", matrixs[i]));
                }
            }
        }
    }
}
