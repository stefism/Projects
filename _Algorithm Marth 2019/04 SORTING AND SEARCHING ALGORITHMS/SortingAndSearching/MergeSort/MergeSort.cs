using System;

namespace MergeSort
{
    class Program
    {
        static void Sort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) // array with 1 element
            {
                return;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            Sort(array, startIndex, middleIndex); // left part of the array
            Sort(array, middleIndex + 1, endIndex); // right part of the array

            MergeArray(array, startIndex, middleIndex, endIndex);
        }

        private static void MergeArray(int[] array, int startIndex, int middleIndex, int endIndex)
        {
            //Заради закръглянето на цепенето на масива, има шанс средния индекс да излезе извън границите, затова трябва да се провери дали е част от масива.
            if (array[middleIndex] <= array[middleIndex + 1])
            {
                return;
            }
        }

        static void Main(string[] args)
        {
            var numbers = new[] { 102, 6, 84, 13, 1, 70, 5 };
            Sort(numbers, 0, numbers.Length - 1);
        }
    }
}
