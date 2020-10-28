using System;

namespace _02_TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            int firstPlayerRow = -1;
            int firstPlayerCol = -1;

            int secondPlayerRow = -1;
            int secondPlayerCol = -1;

            for (int row = 0; row < matrixSize; row++)
            {
                char[] input = Console.ReadLine().ToCharArray(); 

                for (int col = 0; col < matrixSize; col++)
                {
                    if (input[col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (input[col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }

                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                string[] directions = Console.ReadLine().Split();

                string firstPlayerMove = directions[0];
                string secondPlayerMove = directions[1];

                #region firstPlayerMove

                if (firstPlayerMove == "up")
                {
                    if (firstPlayerRow > 0)
                    {
                        firstPlayerRow -= 1;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                    }
                    else
                    {
                        firstPlayerRow = matrixSize-1;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                        //PrintMatrix(matrix);
                    }
                }

                else if (firstPlayerMove == "down")
                {
                    if (firstPlayerRow < matrixSize-1)
                    {
                        firstPlayerRow++;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                        //PrintMatrix(matrix);
                    }
                    else
                    {
                        firstPlayerRow = 0;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                        //PrintMatrix(matrix);
                    }
                }

                else if (firstPlayerMove == "left")
                {
                    if (firstPlayerCol > 0)
                    {
                        firstPlayerCol--;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                    }
                    else
                    {
                        firstPlayerCol = matrixSize-1;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                        //PrintMatrix(matrix);
                    }
                }

                else if (firstPlayerMove == "right")
                {
                    if (firstPlayerCol < matrixSize-1)
                    {
                        firstPlayerCol++;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                        //PrintMatrix(matrix);
                    }
                    else
                    {
                        firstPlayerCol = 0;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                        //PrintMatrix(matrix);
                    }
                }

                #endregion

                #region secondPlayerMove

                if (secondPlayerMove == "up")
                {
                    if (secondPlayerRow > 0)
                    {
                        secondPlayerRow -= 1;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, secondPlayerRow, secondPlayerCol);
                    }
                    else
                    {
                        secondPlayerRow = matrixSize-1;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, secondPlayerRow, secondPlayerCol);
                        //PrintMatrix(matrix);
                    }
                }

                else if (secondPlayerMove == "down")
                {
                    if (secondPlayerRow < matrixSize-1)
                    {
                        secondPlayerRow++;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, secondPlayerRow, secondPlayerCol);
                        //PrintMatrix(matrix);
                    }
                    else
                    {
                        secondPlayerRow = 0;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, secondPlayerRow, secondPlayerCol);
                        //PrintMatrix(matrix);
                    }
                }

                else if (secondPlayerMove == "left")
                {
                    if (secondPlayerCol > 0)
                    {
                        secondPlayerCol--;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, secondPlayerRow, secondPlayerCol);
                    }
                    else
                    {
                        secondPlayerCol = matrixSize-1;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, secondPlayerRow, secondPlayerCol);
                        //PrintMatrix(matrix);
                    }
                }

                else if (secondPlayerMove == "right")
                {
                    if (secondPlayerCol < matrixSize-1)
                    {
                        secondPlayerCol++;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, secondPlayerRow, secondPlayerCol);
                    }
                    else
                    {
                        secondPlayerCol = 0;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, secondPlayerRow, secondPlayerCol);
                        //PrintMatrix(matrix);
                    }
                }

                #endregion
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void IsFirstPlayerDeadEndProgramOrContinue(char[,] matrix, int firstPlayerRow, int firstPlayerCol)
        {
            if (matrix[firstPlayerRow, firstPlayerCol] == 's')
            {
                matrix[firstPlayerRow, firstPlayerCol] = 'x';

                PrintMatrix(matrix);

                Environment.Exit(1);
            }

            matrix[firstPlayerRow, firstPlayerCol] = 'f';
        }

        private static void IsSecondPlayerDeadEndProgramOrContinue(char[,] matrix, int secondPlayerRow, int secondPlayerCol)
        {
            if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
            {
                matrix[secondPlayerRow, secondPlayerCol] = 'x';

                PrintMatrix(matrix);

                Environment.Exit(1);
            }

            matrix[secondPlayerRow, secondPlayerCol] = 's';
        }
    }
}
