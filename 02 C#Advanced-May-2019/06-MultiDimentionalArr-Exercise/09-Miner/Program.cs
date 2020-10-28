using System;
using System.Linq;
using System.Collections.Generic;

namespace _09_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            List<string> moves = new List<string>(Console.ReadLine().Split());

            string[,] matrix = new string[matrixSize, matrixSize];

            int coalCounter = 0;

            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < matrixSize; row++)
            {
                string[] inputRow = Console.ReadLine().Split();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (inputRow[col] == "c")
                    {
                        coalCounter++;
                    }

                    if (inputRow[col] =="s")
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            foreach (var move in moves)
            {
                switch (move)
                {
                    case "left":
                        if (startCol >=1)
                        {
                            if (matrix[startRow, startCol-1] == "c")
                            {
                                coalCounter--;
                                matrix[startRow, startCol] = "*";
                                matrix[startRow, startCol - 1] = "s";
                                startCol = startCol - 1;

                                if (coalCounter == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                    return;
                                }
                            }

                            else if (matrix[startRow, startCol - 1] == "e")
                            {
                                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                return;
                            }

                            else
                            {
                                matrix[startRow, startCol] = "*";
                                matrix[startRow, startCol - 1] = "s";
                                startCol = startCol - 1;
                            }
                        }
                        break;

                    case "right":
                        if (startCol < matrix.GetLength(1) - 1)
                        {
                            if (matrix[startRow, startCol + 1] == "c")
                            {
                                coalCounter--;
                                matrix[startRow, startCol] = "*";
                                matrix[startRow, startCol + 1] = "s";
                                startCol = startCol + 1;

                                if (coalCounter == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                    return;
                                }
                            }

                            else if (matrix[startRow, startCol + 1] == "e")
                            {
                                Console.WriteLine($"Game over! ({startRow}, {startCol+1})");
                                return;
                            }

                            else
                            {
                                matrix[startRow, startCol] = "*";
                                matrix[startRow, startCol + 1] = "s";
                                startCol = startCol + 1;
                            }
                        }
                        break;

                    case "up":
                        if (startRow >= 1)
                        {
                            if (matrix[startRow - 1, startCol] == "c")
                            {
                                coalCounter--;
                                matrix[startRow, startCol] = "*";
                                matrix[startRow, startCol - 1] = "s";
                                startRow = startRow - 1;

                                if (coalCounter == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                    return;
                                }
                            }

                            else if (matrix[startRow - 1, startCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({startRow - 1}, {startCol})");
                                return;
                            }

                            else
                            {
                                matrix[startRow, startCol] = "*";
                                matrix[startRow-1, startCol] = "s";
                                startRow = startRow - 1;
                            }
                        }
                        break;

                    case "down":
                        if (startRow < matrix.GetLength(0) - 1)
                        {
                            if (matrix[startRow + 1, startCol] == "c")
                            {
                                coalCounter--;
                                matrix[startRow, startCol] = "*";
                                matrix[startRow+1, startCol] ="s";
                                startRow = startRow + 1;

                                if (coalCounter == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                    return;
                                }
                            }

                            else if (matrix[startRow + 1, startCol] == "e")
                            {
                                Console.WriteLine($"Game over! ({startRow + 1}, {startCol})");
                                return;
                            }

                            else
                            {
                                matrix[startRow, startCol] = "*";
                                matrix[startRow + 1, startCol] = "s";
                                startRow = startRow + 1;
                            }
                        }
                        break;
                }
            }

            if (coalCounter > 0)
            {
                Console.WriteLine($"{coalCounter} coals left. ({startRow}, {startCol})");
            }
        }
    }
}
