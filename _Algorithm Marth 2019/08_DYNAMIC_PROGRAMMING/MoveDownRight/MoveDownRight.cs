using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveDownRight
{
    class MoveDownRight
    {
        private static int[,] numbers;
        private static int[,] sums;
        private static List<string> output = new List<string>();

        static void Main()
        {
            ReadInput();
            CalculateSums();
            AddOutput();

            output.Reverse();
            Console.WriteLine(string.Join(" ", output));
        }

        private static void AddOutput()
        {
            int currentRow = sums.GetLength(0) - 1;
            int currentCol = sums.GetLength(1) - 1;

            output.Add($"[{currentRow}, {currentCol}]");

            while (currentRow != 0 || currentCol != 0)
            {
                int topSum = -1;
                if (currentRow - 1 >= 0)
                {
                    topSum = sums[currentRow - 1, currentCol];
                }

                int leftSum = -1;
                if (currentCol - 1 >= 0)
                {
                    leftSum = sums[currentRow, currentCol - 1];
                }

                if (topSum > leftSum)
                {
                    output.Add($"[{currentRow - 1}, {currentCol}]");
                    currentRow -= 1;
                }
                else
                {
                    output.Add($"[{currentRow}, {currentCol - 1}]");
                    currentCol -= 1;
                }
            }
        }

        private static void CalculateSums()
        {
            sums = new int[numbers.GetLength(0), numbers.GetLength(1)];

            sums[0, 0] = numbers[0, 0];

            for (int row = 1; row < numbers.GetLength(0); row++)
            {
                sums[row, 0] = sums[row - 1, 0] + numbers[row, 0];
            }

            for (int col = 1; col < numbers.GetLength(1); col++)
            {
                sums[0, col] = sums[0, col - 1] + numbers[0, col];
            }

            for (int row = 1; row < numbers.GetLength(0); row++)
            {
                for (int col = 1; col < numbers.GetLength(1); col++)
                {
                    int result = Math.Max(
                        sums[row - 1, col], sums[row, col - 1]
                        + numbers[row, col]);

                    sums[row, col] = result;
                }
            }
        }

        private static void ReadInput()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            numbers = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();

                for (int col = 0; col < input.Length; col++)
                {
                    numbers[row, col] = input[col];
                }
            }
        }
    }
}
