using System;
using System.Linq;
using System.Collections.Generic;

namespace _05_SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int columns = matrixSize[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentInputRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentInputRow[col];
                }
            }

            int sum = int.MinValue;
            int currentRow = -1;
            int currentCol = -1;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[currentRow, currentCol]} {matrix[currentRow, currentCol+1]}");
            Console.WriteLine($"{matrix[currentRow+1, currentCol]} {matrix[currentRow + 1, currentCol+1]}");
            Console.WriteLine(sum);
        }
    }
}
