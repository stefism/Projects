using System;
using System.Linq;

namespace _04_SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[arraySize, arraySize];

            for (int row = 0; row < arraySize; row++)
            {
                char[] currentInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < arraySize; col++)
                {
                    matrix[row, col] = currentInput[col];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());

            bool isFind = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbolToFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFind = true;
                        break;
                    }
                }
            }

            if (!isFind)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}
