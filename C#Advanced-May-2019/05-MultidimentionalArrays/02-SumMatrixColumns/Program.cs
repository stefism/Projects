using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arraySize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int row = arraySize[0];
            int col = arraySize[1];

            int[,] array = new int[row, col];

            for (int currentRow = 0; currentRow < row; currentRow++)
            {
                int[] curentInputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int currentCol = 0; currentCol < col; currentCol++)
                {
                    array[currentRow, currentCol] = curentInputRow[currentCol];
                }
            }

            for (int currentCol = 0; currentCol < col; currentCol++)
            {
                int sum = 0;

                for (int currentRow = 0; currentRow < row; currentRow++)
                {
                    int currentValue = array[currentRow, currentCol];
                    sum += currentValue;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
