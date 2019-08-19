using System;
using System.Linq;

namespace _07_KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            bool isAttack = true;

            int removedKnights = 0;

            int horseRow = -1;
            int horseCol = -1;

            int maxAttackRow = -1;
            int maxAttackCol = -1;

            int maxAttackIndex = -1;

            while (isAttack == true)
            {
                int attackIndex = 0;

                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        attackIndex = 0;

                        bool crashMiddleTopLeft = CrashMiddleTopLeft(matrix, ref horseRow, ref horseCol, row, col);

                        if (crashMiddleTopLeft)
                        {
                            attackIndex++;
                        } //

                        bool crashMiddleTopRight = CrashMiddleTopRight(matrix, ref horseRow, ref horseCol, row, col);

                        if (crashMiddleTopRight)
                        {
                            attackIndex++;
                        }

                        bool crashTopLeft = CrashTopLeft(matrix, ref horseRow, ref horseCol, row, col);

                        if (crashTopLeft)
                        {
                            attackIndex++;
                        }

                        bool crashTopRight = CrashTopRight(matrix, ref horseRow, ref horseCol, row, col);

                        if (crashTopRight)
                        {
                            attackIndex++;
                        }

                        bool crashMiddleBottomLeft = CrashMiddleBottomLeft(matrix, ref horseRow, ref horseCol, row, col);

                        if (crashMiddleBottomLeft)
                        {
                            attackIndex++;
                        }

                        bool crashMiddleBottomRight = CrashMiddleBottomRight(matrix, ref horseRow, ref horseCol, row, col);

                        if (crashMiddleBottomRight)
                        {
                            attackIndex++;
                        }

                        bool crashBottomLeft = CrashBottomLeft(matrix, ref horseRow, ref horseCol, row, col);

                        if (crashBottomLeft)
                        {
                            attackIndex++;
                        }

                        bool crashBottomRight = CrashBottomRight(matrix, ref horseRow, ref horseCol, row, col);

                        if (crashBottomRight)
                        {
                            attackIndex++;
                        }

                        if (attackIndex > maxAttackIndex)
                        {
                            maxAttackIndex = attackIndex;
                            maxAttackCol = col;
                            maxAttackRow = row;
                        }
                    }
                }

                if (attackIndex == 0 && maxAttackIndex == 0)
                {
                    isAttack = false;
                }
                else
                {
                    matrix[maxAttackRow, maxAttackCol] = '0';
                    removedKnights++;
                    maxAttackIndex = 0;
                }
            }

            Console.WriteLine(removedKnights);
        }

        static bool CrashBottomRight(char[,] matrix, ref int horseRow, ref int horseCol, int row, int col)
        {
            if (matrix[row, col] == 'K')
            {
                horseRow = row;
                horseCol = col;

                if (horseRow < (matrix.GetLength(0) - 2) && horseCol < (matrix.GetLength(1) - 1))
                {
                    int crashRow = horseRow + 2;
                    int crashCol = horseCol + 1;

                    if (matrix[crashRow, crashCol] == 'K')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CrashBottomLeft(char[,] matrix, ref int horseRow, ref int horseCol, int row, int col)
        {
            if (matrix[row, col] == 'K')
            {
                horseRow = row;
                horseCol = col;

                if (horseRow < matrix.GetLength(0) - 2 && horseCol >= 1)
                {
                    int crashRow = horseRow + 2;
                    int crashCol = horseCol - 1;

                    if (matrix[crashRow, crashCol] == 'K')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CrashMiddleBottomRight(char[,] matrix, ref int horseRow, ref int horseCol, int row, int col)
        {
            if (matrix[row, col] == 'K')
            {
                horseRow = row;
                horseCol = col;

                if (horseRow < matrix.GetLength(0) - 1 && horseCol < matrix.GetLength(1) - 2)
                {
                    int crashRow = horseRow + 1;
                    int crashCol = horseCol + 2;

                    if (matrix[crashRow, crashCol] == 'K')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CrashMiddleBottomLeft(char[,] matrix, ref int horseRow, ref int horseCol, int row, int col)
        {
            if (matrix[row, col] == 'K')
            {
                horseRow = row;
                horseCol = col;

                if (horseRow < matrix.GetLength(0) - 1 && horseCol >= 2)
                {
                    int crashRow = horseRow + 1;
                    int crashCol = horseCol - 2;

                    if (matrix[crashRow, crashCol] == 'K')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CrashTopRight(char[,] matrix, ref int horseRow, ref int horseCol, int row, int col)
        {
            if (matrix[row, col] == 'K')
            {
                horseRow = row;
                horseCol = col;

                if (horseRow >= 2 && horseCol < matrix.GetLength(1) - 1)
                {
                    int crashRow = horseRow - 2;
                    int crashCol = horseCol + 1;

                    if (matrix[crashRow, crashCol] == 'K')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CrashTopLeft(char[,] matrix, ref int horseRow, ref int horseCol, int row, int col)
        {
            if (matrix[row, col] == 'K')
            {
                horseRow = row;
                horseCol = col;

                if (horseRow >= 2 && horseCol >= 1)
                {
                    int crashRow = horseRow - 2;
                    int crashCol = horseCol - 1;

                    if (matrix[crashRow, crashCol] == 'K')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CrashMiddleTopRight(char[,] matrix, ref int horseRow, ref int horseCol, int row, int col)
        {
            if (matrix[row, col] == 'K')
            {
                horseRow = row;
                horseCol = col;

                if (horseRow >= 1 && horseCol < matrix.GetLength(1) - 2)
                {
                    int crashRow = horseRow - 1;
                    int crashCol = horseCol + 2;

                    if (matrix[crashRow, crashCol] == 'K')
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        static bool CrashMiddleTopLeft(char[,] matrix, ref int horseRow, ref int horseCol, int row, int col)
        {
            if (matrix[row, col] == 'K')
            {
                horseRow = row;
                horseCol = col;

                if (horseRow >= 1 && horseCol >= 2)
                {
                    int crashRow = horseRow - 1;
                    int crashCol = horseCol - 2;

                    if (matrix[crashRow, crashCol] == 'K')
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
