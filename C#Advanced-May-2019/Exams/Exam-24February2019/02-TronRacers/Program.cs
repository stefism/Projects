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
                        firstPlayerRow = matrixSize;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                    }
                }

                else if (firstPlayerMove == "down")
                {
                    if (firstPlayerRow > matrixSize)
                    {
                        firstPlayerRow++;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                    }
                    else
                    {
                        firstPlayerRow = 0;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
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
                        firstPlayerCol = matrixSize;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                    }
                }

                else if (firstPlayerMove == "right")
                {
                    if (firstPlayerCol < matrixSize)
                    {
                        firstPlayerCol++;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                    }
                    else
                    {
                        firstPlayerCol = 0;
                        IsFirstPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                    }
                }

                #endregion

                if (secondPlayerMove == "up")
                {
                    if (secondPlayerRow > 0)
                    {
                        secondPlayerRow -= 1;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                    }
                    else
                    {
                        secondPlayerRow = matrixSize;
                        IsSecondPlayerDeadEndProgramOrContinue(matrix, firstPlayerRow, firstPlayerCol);
                    }
                }
            }
        }

        private static void IsFirstPlayerDeadEndProgramOrContinue(char[,] matrix, int firstPlayerRow, int firstPlayerCol)
        {
            if (matrix[firstPlayerRow, firstPlayerCol] == 's')
            {
                matrix[firstPlayerRow, firstPlayerCol] = 'x';

                Environment.Exit(1);
            }

            matrix[firstPlayerRow, firstPlayerCol] = 'f';
        }

        private static void IsSecondPlayerDeadEndProgramOrContinue(char[,] matrix, int secondPlayerRow, int secondPlayerCol)
        {
            if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
            {
                matrix[secondPlayerRow, secondPlayerCol] = 'x';

                Environment.Exit(1);
            }

            matrix[secondPlayerRow, secondPlayerCol] = 's';
        }
    }
}
