using System;
using System.Linq;

namespace _02_2x2SuqaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            if (rows <= 0 || cols <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] currentInput = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentInput[col];
                }
            }

            int equalCounter = 0;

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    if (matrix[row, col] == matrix[row, col+1] 
                        && matrix[row, col] == matrix[row+1, col]
                        && matrix[row, col] == matrix[row + 1, col+1])
                    {
                        equalCounter++;
                    }
                }
            }

            if (equalCounter > 0)
            {
                Console.WriteLine(equalCounter);
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
