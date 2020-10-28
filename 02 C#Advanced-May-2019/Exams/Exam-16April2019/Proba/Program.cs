using System;
using System.Linq;
using System.Collections.Generic;

namespace Proba
{
    class Program
    {
        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int matrixRow = int.Parse(Console.ReadLine());
            int matrixCol = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixRow, matrixCol];

            for (int row = 0; row < matrixRow; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrixCol; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            List<int> numberInMatrix = new List<int>();

            int currentRow = 0;
            int currentCol = 0;

            int startCol = 1;
            int startRow = 0;

            while (true)
            {
                numberInMatrix.Add(matrix[currentRow, currentCol]);
                matrix[currentRow, currentCol] = 0;

                if (currentCol < matrix.GetLength(1) && currentCol == 0)
                {
                    currentCol++;
                    //startCol++;

                    numberInMatrix.Add(matrix[currentRow, currentCol]);
                    matrix[currentRow, currentCol] = 0;

                    PrintMatrix(matrix);
                    //Console.WriteLine();
                }

                startCol++;

                int exitCol = 0;

                while (currentCol != exitCol)
                {
                    if (currentRow < matrix.GetLength(0) - 1) //!
                    {
                        currentCol--;
                        currentRow ++;

                        numberInMatrix.Add(matrix[currentRow, currentCol]);
                        matrix[currentRow, currentCol] = 0;

                        PrintMatrix(matrix);
                        //Console.WriteLine();
                    }
                    else
                    {
                        currentRow--;
                    }
                }

                if (startCol < matrix.GetLength(1))
                {
                    currentCol = startCol;
                    currentRow = startRow;
                }
                else
                {
                    startCol--;
                    currentCol = startCol;
                    startRow++;
                    exitCol++;
                    currentRow = startRow;
                }
            }
        }
    }
}
