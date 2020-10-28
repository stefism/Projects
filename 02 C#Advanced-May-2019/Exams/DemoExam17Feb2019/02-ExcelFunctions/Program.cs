using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_ExcelFunctions
{
    class Program
    {
        static string[][] matrix;

        static void Main()
        {
            int matrixRow = int.Parse(Console.ReadLine());

            matrix = new string[matrixRow-1][];

            List<string> header = Console.ReadLine().Split(", ").ToList();

            for (int i = 0; i < matrixRow-1; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                matrix[i] = input;
            }

            string[] commandArgs = Console.ReadLine().Split();

            string command = commandArgs[0];
            string headerName = commandArgs[1];
            int index = header.IndexOf(headerName); // Масива няма indexOf.

            if (command == "sort")
            {
                matrix = matrix.OrderBy(x => x[index]).ToArray();
            }

            else if (command == "filter")
            {
                string value = commandArgs[2];

                matrix = matrix.Where(x => x[index] == value).ToArray();
            }

            else if (command == "hide")
            {
                header.RemoveAt(index);
                matrix = DeleteColumn(matrix, index);
            }

            Console.WriteLine(string.Join(" | ", header));

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" | ", matrix[i]));
            }
        }

        public static string[][] DeleteColumn(string [][] matrix, int index)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                List<string> temp = matrix[i].ToList();
                temp.RemoveAt(index);
                matrix[i] = temp.ToArray();
            }

            return matrix;
        }
    }
}
