using System;
using System.Linq;

namespace _05_SnakeMoves
{
    class Program
    {
        static void Main(string[] args) 
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[] inputString = Console.ReadLine().ToCharArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];

            int charCount = 0;

            int currentRow = 1;

            for (int row = 0; row < rows; row++)
            {
                if (currentRow % 2 != 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = inputString[charCount];

                        charCount++;

                        if (charCount == inputString.Length)
                        {
                            charCount = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols-1; col >= 0; col--)
                    {
                        matrix[row, col] = inputString[charCount];

                        charCount++;

                        if (charCount == inputString.Length)
                        {
                            charCount = 0;
                        }
                    }
                }

                currentRow++;
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
