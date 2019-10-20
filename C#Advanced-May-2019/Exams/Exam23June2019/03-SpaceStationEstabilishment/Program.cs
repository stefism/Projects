using System;
using System.Linq;

namespace _03_SpaceStationEstabilishment
{
    class Program
    {
        static int stivenRow = -1;
        static int stivenCol = -1;
         
        static int blackHoleOneRow = -1;
        static int blackHoleOneCol = -1;
         
        static int blackHoleTwoRow = -1;
        static int blackHoleTwoCol = -1;

        static char[,] matrix;

        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            bool isBlackHolesExist = false;
            bool isFirstHoleFind = false;

            InializeMatrixAndGetCoordinates(matrixSize, ref isBlackHolesExist, ref isFirstHoleFind);

            int starPower = 0;

            while (true)
            {
                string move = Console.ReadLine();

                switch (move)
                {
                    case "up":
                        if (stivenRow == 0)
                        {
                            ExitAndPrintMessageAndMatrix(starPower);
                        }
                        else
                        {
                            if (matrix[stivenRow-1, stivenCol] == '-')
                            {
                                matrix[stivenRow - 1, stivenCol] = 'S';
                                matrix[stivenRow , stivenCol] = '-';
                                stivenRow--;
                            }
                            else
                            {
                                bool isNumber = int.TryParse(matrix[stivenRow - 1, stivenCol]
                                    .ToString(), out int currentStarPower);

                                if (isNumber)
                                {
                                    starPower += currentStarPower;
                                    matrix[stivenRow - 1, stivenCol] = 'S';
                                    matrix[stivenRow, stivenCol] = '-';
                                    stivenRow--;

                                    IfPowerCollectedPrintMessageAndEndProgram(starPower);
                                }
                                else
                                {
                                    if (blackHoleOneRow == stivenRow-1 && blackHoleOneCol == stivenCol)
                                    {
                                        RenameFieldInMatrixWithHoleOne();
                                        isBlackHolesExist = false;

                                        //PrintMatrix(matrix);
                                    }
                                    else if (blackHoleTwoRow == stivenRow-1 && blackHoleTwoCol == stivenCol)
                                    {
                                        RenameFieldInMatrixWithHoleTwo();
                                        isBlackHolesExist = false;

                                        //PrintMatrix(matrix);
                                    }
                                }
                            }
                        }
                        break;

                    case "down":
                        if (stivenRow == matrix.GetLength(0)-1)
                        {
                            ExitAndPrintMessageAndMatrix(starPower);
                        }
                        else
                        {
                            if (matrix[stivenRow + 1, stivenCol] == '-')
                            {
                                matrix[stivenRow + 1, stivenCol] = 'S';
                                matrix[stivenRow, stivenCol] = '-';
                                stivenRow++;

                                //PrintMatrix(matrix);
                            }
                            else
                            {
                                bool isNumber = int.TryParse(matrix[stivenRow + 1, stivenCol]
                                    .ToString(), out int currentStarPower);

                                if (isNumber)
                                {
                                    starPower += currentStarPower;
                                    matrix[stivenRow + 1, stivenCol] = 'S';
                                    matrix[stivenRow, stivenCol] = '-';
                                    stivenRow++;

                                    //PrintMatrix(matrix);

                                    IfPowerCollectedPrintMessageAndEndProgram(starPower);
                                }
                                else
                                {
                                    if (blackHoleOneRow == stivenRow + 1 && blackHoleOneCol == stivenCol)
                                    {
                                        RenameFieldInMatrixWithHoleOne();
                                        isBlackHolesExist = false;

                                        //PrintMatrix(matrix);
                                    }
                                    else if (blackHoleTwoRow == stivenRow + 1 && blackHoleTwoCol == stivenCol)
                                    {
                                        RenameFieldInMatrixWithHoleTwo();
                                        isBlackHolesExist = false;

                                        //PrintMatrix(matrix);
                                    }
                                }
                            }
                        }
                        break;

                    case "left":
                        if (stivenCol == 0)
                        {
                            ExitAndPrintMessageAndMatrix(starPower);
                        }
                        else
                        {
                            if (matrix[stivenRow, stivenCol - 1] == '-')
                            {
                                matrix[stivenRow, stivenCol - 1] = 'S';
                                matrix[stivenRow, stivenCol] = '-';
                                stivenCol--;

                                //PrintMatrix(matrix);
                            }
                            else
                            {
                                bool isNumber = int.TryParse(matrix[stivenRow, stivenCol - 1]
                                    .ToString(), out int currentStarPower);

                                if (isNumber)
                                {
                                    starPower += currentStarPower;
                                    matrix[stivenRow, stivenCol - 1] = 'S';
                                    matrix[stivenRow, stivenCol] = '-';
                                    stivenCol--;

                                    //PrintMatrix(matrix);

                                    IfPowerCollectedPrintMessageAndEndProgram(starPower);
                                }
                                else
                                {
                                    if (blackHoleOneRow == stivenRow && blackHoleOneCol == stivenCol - 1)
                                    {
                                        RenameFieldInMatrixWithHoleOne();
                                        isBlackHolesExist = false;

                                        //PrintMatrix(matrix);
                                    }
                                    else if (blackHoleTwoRow == stivenRow && blackHoleTwoCol == stivenCol - 1)
                                    {
                                        RenameFieldInMatrixWithHoleTwo();
                                        isBlackHolesExist = false;

                                        //PrintMatrix(matrix);
                                    }
                                }
                            }
                        }
                        break;

                    case "right":
                        if (stivenCol == matrix.GetLength(1)-1)
                        {
                            ExitAndPrintMessageAndMatrix(starPower);
                        }
                        else
                        {
                            if (matrix[stivenRow, stivenCol + 1] == '-')
                            {
                                matrix[stivenRow, stivenCol + 1] = 'S';
                                matrix[stivenRow, stivenCol] = '-';
                                stivenCol++;

                                //PrintMatrix(matrix);
                            }
                            else
                            {
                                bool isNumber = int.TryParse(matrix[stivenRow, stivenCol + 1]
                                    .ToString(), out int currentStarPower);

                                if (isNumber)
                                {
                                    starPower += currentStarPower;
                                    matrix[stivenRow, stivenCol + 1] = 'S';
                                    matrix[stivenRow, stivenCol] = '-';
                                    stivenCol++;

                                    //PrintMatrix(matrix);

                                    IfPowerCollectedPrintMessageAndEndProgram(starPower);
                                }
                                else
                                {
                                    if (blackHoleOneRow == stivenRow && blackHoleOneCol == stivenCol + 1)
                                    {
                                        RenameFieldInMatrixWithHoleOne();
                                        isBlackHolesExist = false;

                                        //PrintMatrix(matrix);
                                    }
                                    else if (blackHoleTwoRow == stivenRow && blackHoleTwoCol == stivenCol + 1)
                                    {
                                        RenameFieldInMatrixWithHoleTwo();
                                        isBlackHolesExist = false;

                                        //PrintMatrix(matrix);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }

        private static void IfPowerCollectedPrintMessageAndEndProgram(int starPower)
        {
            if (starPower >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {starPower}");
                PrintMatrix(matrix);
                Environment.Exit(1);
            }
        }

        private static void RenameFieldInMatrixWithHoleTwo()
        {
            matrix[stivenRow, stivenCol] = '-';
            stivenRow = blackHoleOneRow;
            stivenCol = blackHoleOneCol;
            matrix[stivenRow, stivenCol] = 'S';
            matrix[blackHoleTwoRow, blackHoleTwoCol] = '-';
        }

        private static void RenameFieldInMatrixWithHoleOne()
        {
            matrix[stivenRow, stivenCol] = '-';
            stivenRow = blackHoleTwoRow;
            stivenCol = blackHoleTwoCol;
            matrix[stivenRow, stivenCol] = 'S';
            matrix[blackHoleOneRow, blackHoleOneCol] = '-';
        }

        private static void ExitAndPrintMessageAndMatrix(int starPower)
        {
            matrix[stivenRow, stivenCol] = '-';
            Console.WriteLine("Bad news, the spaceship went to the void.");
            Console.WriteLine($"Star power collected: {starPower}");

            PrintMatrix(matrix);
            Environment.Exit(1);
        }

        private static void InializeMatrixAndGetCoordinates
            (int matrixSize, ref bool isBlackHolesExist, ref bool isFirstHoleFind)
        {
            matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        stivenRow = row;
                        stivenCol = col;
                    }
                    else if (matrix[row, col] == 'O')
                    {
                        if (!isFirstHoleFind)
                        {
                            blackHoleOneRow = row;
                            blackHoleOneCol = col;
                            isBlackHolesExist = true;
                            isFirstHoleFind = true;
                        }
                        else
                        {
                            blackHoleTwoRow = row;
                            blackHoleTwoCol = col;
                        }
                    }
                }
            }
        }

        public static void PrintMatrix(char[,] matrix)
        {
            //Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
