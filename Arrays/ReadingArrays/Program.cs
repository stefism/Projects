using System;

namespace ReadingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = int.Parse(Console.ReadLine());

            int[] array = new int[arraySize];

            for (int arrayIndex = 0; arrayIndex < arraySize; arrayIndex++)
            {
                array[arrayIndex] = int.Parse(Console.ReadLine());
            }
        }
    }
}
