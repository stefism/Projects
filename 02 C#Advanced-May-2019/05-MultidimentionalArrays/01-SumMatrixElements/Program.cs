using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayLenght = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int row = arrayLenght[0];
            int col = arrayLenght[1];

            int[,] array = new int[row, col];

            for (int currentRow = 0; currentRow < row; currentRow++)
            {
                int[] currentRowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int currentCol = 0; currentCol < col; currentCol++)
                {
                    array[currentRow,currentCol] = currentRowInput[currentCol];
                }
            }

            int sum = 0;

            Console.WriteLine(array.GetLength(0));
            Console.WriteLine(array.GetLength(1));

            foreach (var number in array)
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
