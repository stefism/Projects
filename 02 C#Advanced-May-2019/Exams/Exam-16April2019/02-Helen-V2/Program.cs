using System;
using System.Linq;

namespace _02_Helen_V2
{
    class Program
    {
        static int ParisHealth;
        static char[][] Matrix;
        static int ParisRow;
        static int ParisCol;

        static void Main(string[] args)
        {
            ParisHealth = int.Parse(Console.ReadLine());
            int matrixRow = int.Parse(Console.ReadLine());

            Matrix = new char[matrixRow][];

            for (int row = 0; row < matrixRow; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                Matrix[row] = input;

                if (input.Contains('P'))
                {
                    ParisRow = row;

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == 'P')
                        {
                            ParisCol = i;
                            Matrix[row][i] = '-';
                        }
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = commands[0];
                int spawnRow = int.Parse(commands[1]);
                int spawnCol = int.Parse(commands[2]);

                Matrix[spawnRow][spawnCol] = 'S';

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
                        if (ParisRow == Matrix.Length-1)
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
                        if (ParisCol == Matrix[ParisRow].Length-1)
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

            //PrintMatrix();
        }
        static void IfFindHelenProgramEnd()
        {
            if (Matrix[ParisRow][ParisCol] == 'H')
            {
                Matrix[ParisRow][ParisCol] = '-';

                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {ParisHealth}");
                PrintMatrix();
                End();
            }
        }

        static void IfFindSpartanEnergyDecreaseBy2()
        {
            if (Matrix[ParisRow][ParisCol] == 'S')
            {
                ParisHealth -= 2;

                Matrix[ParisRow][ParisCol] = '-';
            }
        }

        static void IfHealthBelowZeroProgramEnd()
        {
            if (ParisHealth <= 0)
            {
                Matrix[ParisRow][ParisCol] = 'X';
                Console.WriteLine($"Paris died at {ParisRow};{ParisCol}.");
                PrintMatrix();
                End();
            }
        }

        static void End()
        {
            Environment.Exit(1);
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < Matrix.Length; row++)
            {
                Console.WriteLine(Matrix[row]);
            }
        }
    }
}
