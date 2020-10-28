using System;
using System.Linq;

namespace _06_Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayRow = int.Parse(Console.ReadLine());

            int[][] array = new int[arrayRow][];

            for (int i = 0; i < array.Length; i++)
            {
                int[] currentInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                array[i] = currentInput;
            }

            while (true)
            {
                string[] commandAndCoordinates = Console.ReadLine().Split();

                string command = commandAndCoordinates[0];

                if (command == "END")
                {
                    break;
                }

                int row = int.Parse(commandAndCoordinates[1]);
                int col = int.Parse(commandAndCoordinates[2]);
                int value = int.Parse(commandAndCoordinates[3]);

                if (col < 0 || row < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if ((row > array.Length - 1) || (array[row].Length-1 < col))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    array[row][col] += value;
                }

                else
                {
                    array[row][col] -= value;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(string.Join(" ", array[i]));
            }
        }
    }
}
