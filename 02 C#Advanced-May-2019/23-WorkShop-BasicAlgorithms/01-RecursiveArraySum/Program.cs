using System;
using System.Linq;

namespace _01_RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int index = Array.IndexOf(numbers, 4);

            int result = FindSum(numbers, 0);

            Console.WriteLine(result);
        }

        public static int FindSum(int[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                return 0;
            }

            int result = numbers[index] + FindSum(numbers, ++index);
            return result;
        }
    }
}
