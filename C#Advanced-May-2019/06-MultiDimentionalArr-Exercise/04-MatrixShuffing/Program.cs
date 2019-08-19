using System;
using System.Linq;

namespace _04_MatrixShuffing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentInput = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentInput[col];
                }
            }

            while (true)
            {
                string[] currentCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currentCommand[0] == "END")
                {
                    break;
                }

                if (currentCommand[0] != "swap" || currentCommand.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(currentCommand[1]);
                int col1 = int.Parse(currentCommand[2]);

                int row2 = int.Parse(currentCommand[3]);
                int col2 = int.Parse(currentCommand[4]);

                if (row1 < 0 || row2 < 0 || col1 < 0 || col2 < 0 || row1 > matrix.GetLength(0) - 1
                    || row2 > matrix.GetLength(0) - 1 || col1 > matrix.GetLength(1) - 1 || col2 > matrix.GetLength(1) - 1)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string firstValue = matrix[row1, col1];
                string secondValue = matrix[row2, col2];

                matrix[row1, col1] = secondValue;
                matrix[row2, col2] = firstValue;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                   Console.WriteLine();
                }
            }
        }
    }
}
