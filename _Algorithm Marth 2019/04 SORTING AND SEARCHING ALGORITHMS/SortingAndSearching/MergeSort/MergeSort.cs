using System;
using System.Linq;

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
            if (middleIndex < 0 || middleIndex + 1 >= array.Length 
                || array[middleIndex] <= array[middleIndex + 1])
            {
                return;
            }

            int[] helpArr = new int[array.Length];

            for (int i = startIndex; i <= endIndex; i++)
            {
                helpArr[i] = array[i];
            }

            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndex > middleIndex)
                {
                    array[i] = helpArr[rightIndex++];
                }
                else if (rightIndex > endIndex)
                {
                    array[i] = helpArr[leftIndex++];
                }
                else if (helpArr[leftIndex] <= helpArr[rightIndex])
                {
                    array[i] = helpArr[leftIndex++];
                }
                else
                {
                    array[i] = helpArr[rightIndex++];
                }
            }
        }

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Sort(numbers, 0, numbers.Length - 1);
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
