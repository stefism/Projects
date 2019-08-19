using System;
using System.Linq;

namespace _06_BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int targetRow = coordinates[0];
            int targetCol = coordinates[1];
            int radius = coordinates[2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool isInRadius = Math.Pow(row - targetRow, 2)
                        + Math.Pow(col - targetCol, 2) <= Math.Pow(radius, 2);

                    if (isInRadius)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int onesCounter = 0;

                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        onesCounter++;
                        matrix[row, col] = 0;
                    }
                }

                for (int row = 0; row < onesCounter; row++)
                {
                    matrix[row, col] = 1;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
