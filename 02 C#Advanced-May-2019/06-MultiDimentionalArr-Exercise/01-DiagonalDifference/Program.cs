using System;
using System.Linq;

namespace _01_DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRow = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixRow, matrixRow];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentInput[col];
                }
            }

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < matrixRow; i++)
            {
                leftSum += matrix[i, i];
                rightSum += matrix[matrix.GetLength(1) - 1 - i, i];
            }

            int difference = Math.Abs(leftSum - rightSum);

            Console.WriteLine(difference);
        }
    }
}
