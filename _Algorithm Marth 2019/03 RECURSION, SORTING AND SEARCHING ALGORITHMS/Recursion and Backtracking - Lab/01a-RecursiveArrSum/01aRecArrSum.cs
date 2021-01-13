using System;

namespace _01a_RecursiveArrSum
{
    class Program
    {
        static int Summation0(int[] arr, int index = 0)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            var currArrNum = arr[index];
            var cuurSum = Summation1(arr, 1);

            var totalSum = currArrNum + cuurSum;
            return totalSum;
        }

        static int Summation1(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            var currArrNum = arr[index];
            var cuurSum = Summation2(arr, 2);

            var totalSum = currArrNum + cuurSum;
            return totalSum;
        }

        static int Summation2(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            var currArrNum = arr[index];
            var cuurSum = Summation1(arr, 2);

            var totalSum = currArrNum + cuurSum;
            return totalSum;
        }

        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2 };

            var sum = Summation0(numbers);

            Console.WriteLine(sum);
        }
    }
}
