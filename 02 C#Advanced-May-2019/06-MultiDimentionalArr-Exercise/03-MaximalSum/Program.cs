using System;
using System.Linq;

namespace _03_MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentInput[col];
                }
            }

            int maxSum = int.MinValue;
            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                                       + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                                       + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[startRow, startCol]} {matrix[startRow, startCol+1]} {matrix[startRow, startCol + 2]}");
            Console.WriteLine($"{matrix[startRow+1, startCol]} {matrix[startRow+1, startCol + 1]} {matrix[startRow+1, startCol + 2]}");
            Console.WriteLine($"{matrix[startRow+2, startCol]} {matrix[startRow+2, startCol + 1]} {matrix[startRow+2, startCol + 2]}");
        }
    }
}
