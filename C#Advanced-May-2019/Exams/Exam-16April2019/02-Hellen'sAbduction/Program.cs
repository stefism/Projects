using System;
using System.Linq;

namespace _02_Hellen_sAbduction
{
    class Program
    {
        static int ParisHealth;
        static char[,] Matrix;
        static int ParisRow;
        static int ParisCol;

        static void Main()
        {
            ParisHealth = int.Parse(Console.ReadLine());
            int matrixSize = int.Parse(Console.ReadLine());

            Matrix = new char[matrixSize, matrixSize];

            ParisRow = -1;
            ParisCol = -1;

            for (int row = 0; row < matrixSize; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                //char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    Matrix[row, col] = input[col];

                    if (input[col] == 'P')
                    {
                        ParisRow = row;
                        ParisCol = col;

                        Matrix[ParisRow, ParisCol] = '-';
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = commands[0];
                int spawnRow = int.Parse(commands[1]);
                int spawnCol = int.Parse(commands[2]);

                Matrix[spawnRow, spawnCol] = 'S';

                switch (direction)
                {
                    case "up":
                        if (ParisRow == 0)
                        {
                            ParisHealth--;

                            IfHealthBelowZeroProgramEnd();

                            //PrintMatrix();
                        }
                        else
                        {
                            ParisRow--;
                            ParisHealth--;

                            IfFindHelenProgramEnd();

                            IfHealthBelowZeroProgramEnd();

                            IfFindSpartanEnergyDecreaseBy2();

                            IfHealthBelowZeroProgramEnd();

                            //PrintMatrix();
                        }
                        break;

                    case "down":
                        if (ParisRow == matrixSize - 1)
                        {
                            ParisHealth--;

                            IfHealthBelowZeroProgramEnd();

                            //PrintMatrix();
                        }
                        else
                        {
                            ParisRow++;
                            ParisHealth--;

                            IfFindHelenProgramEnd();

                            IfHealthBelowZeroProgramEnd();

                            IfFindSpartanEnergyDecreaseBy2();

                            IfHealthBelowZeroProgramEnd();

                            //PrintMatrix();
                        }
                        break;

                    case "left":
                        if (ParisCol == 0)
                        {
                            ParisHealth--;

                            IfHealthBelowZeroProgramEnd();

                            //PrintMatrix();
                        }
                        else
                        {
                            ParisCol--;
                            ParisHealth--;

                            IfFindHelenProgramEnd();

                            IfHealthBelowZeroProgramEnd();

                            IfFindSpartanEnergyDecreaseBy2();

                            IfHealthBelowZeroProgramEnd();

                            //PrintMatrix();
                        }
                        break;

                    case "right":
                        if (ParisCol == matrixSize - 1)
                        {
                            ParisHealth--;

                            IfHealthBelowZeroProgramEnd();

                            //PrintMatrix();
                        }
                        else
                        {
                            ParisCol++;
                            ParisHealth--;

                            IfFindHelenProgramEnd();

                            IfHealthBelowZeroProgramEnd();

                            IfFindSpartanEnergyDecreaseBy2();

                            IfHealthBelowZeroProgramEnd();

                            //PrintMatrix();
                        }
                        break;
                }

            }
        }

        private static void IfFindHelenProgramEnd()
        {
            if (Matrix[ParisRow, ParisCol] == 'H')
            {
                Matrix[ParisRow, ParisCol] = '-';

                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {ParisHealth}");
                PrintMatrix();
                End();
            }
        }

        private static void IfFindSpartanEnergyDecreaseBy2()
        {
            if (Matrix[ParisRow, ParisCol] == 'S')
            {
                ParisHealth -= 2;

                Matrix[ParisRow, ParisCol] = '-';
            }
        }

        private static void IfHealthBelowZeroProgramEnd()
        {
            if (ParisHealth <= 0)
            {
                Matrix[ParisRow, ParisCol] = 'X';
                Console.WriteLine($"Paris died at {ParisRow};{ParisCol}.");
                PrintMatrix();
                End();
            }
        }

        private static void End()
        {
            Environment.Exit(1);
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < Matrix.GetLength(1); col++)
                {
                    Console.Write(Matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
