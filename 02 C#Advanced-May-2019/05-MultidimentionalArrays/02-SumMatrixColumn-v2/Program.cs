using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SumMatrixColumns_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arraySize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int row = arraySize[0];
            int col = arraySize[1];

            int[,] array = new int[row, col];
            int[] sum = new int[col];

            for (int currentRow = 0; currentRow < row; currentRow++)
            {
                int[] curentInputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int currentCol = 0; currentCol < col; currentCol++)
                {
                    array[currentRow, currentCol] = curentInputRow[currentCol];
                    sum[currentCol] += curentInputRow[currentCol];
                }
            }

            foreach (var item in sum)
            {
                Console.WriteLine(item);
            }
        }
    }
}

