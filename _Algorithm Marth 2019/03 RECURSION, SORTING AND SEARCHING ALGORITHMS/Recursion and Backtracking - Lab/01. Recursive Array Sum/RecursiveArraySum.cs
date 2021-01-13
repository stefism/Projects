using System;

namespace _01._Recursive_Array_Sum
{
    class RecursiveArraySum
    {
        static int Summation(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            var currArrNum = arr[index];
            var cuurSum = Summation(arr, index + 1);

            var totalSum = currArrNum + cuurSum;
            return totalSum;
        }

        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            
            var sum = Summation(numbers, 0);

            Console.WriteLine(sum);
        }
    }
}
