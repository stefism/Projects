using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string initialString = Console.ReadLine();

            sb.Append(initialString);

            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < matrixSize; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row,col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "end")
                {
                    break;
                }

                switch (direction)
                {
                    case "up":
                        if (playerRow == 0)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Remove(sb.Length - 1, 1);
                            }
                        }
                        else
                        {
                            playerRow--;

                            if (matrix[playerRow, playerCol] != '-')
                            {
                                sb.Append(matrix[playerRow, playerCol]);
                            }
                                matrix[playerRow, playerCol] = 'P';
                                matrix[playerRow + 1, playerCol] = '-';
                        }

                        //Console.WriteLine(sb.ToString());
                        //PrintMatrix(matrix);
                        break;

                    case "down":
                        if (playerRow == matrixSize-1)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Remove(sb.Length - 1, 1);
                            }
                        }
                        else
                        {
                            playerRow++;

                            if (matrix[playerRow, playerCol] != '-')
                            {
                                sb.Append(matrix[playerRow, playerCol]);
                            }
                                matrix[playerRow, playerCol] = 'P';
                                matrix[playerRow - 1, playerCol] = '-';
                        }

                        //Console.WriteLine(sb.ToString());
                        //PrintMatrix(matrix);
                        break;

                    case "left":
                        if (playerCol == 0)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Remove(sb.Length - 1, 1);
                            }
                        }
                        else
                        {
                            playerCol--;

                            if (matrix[playerRow, playerCol] != '-')
                            {
                                sb.Append(matrix[playerRow, playerCol]);
                            }
                            matrix[playerRow, playerCol] = 'P';
                            matrix[playerRow, playerCol + 1] = '-';
                        }

                        //Console.WriteLine(sb.ToString());
                        //PrintMatrix(matrix);
                        break;

                    case "right":
                        if (playerCol == matrixSize-1)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Remove(sb.Length - 1, 1);
                            }
                        }
                        else
                        {
                            playerCol++;

                            if (matrix[playerRow, playerCol] != '-')
                            {
                                sb.Append(matrix[playerRow, playerCol]);
                            }
                                matrix[playerRow, playerCol] = 'P';
                                matrix[playerRow, playerCol - 1] = '-';
                        }

                        //Console.WriteLine(sb.ToString());
                        //PrintMatrix(matrix);
                        break;
                }
            }

            Console.WriteLine(sb.ToString());
            PrintMatrix(matrix);
        }

        public static void PrintMatrix(char[,] matrix)
        {
            //Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
