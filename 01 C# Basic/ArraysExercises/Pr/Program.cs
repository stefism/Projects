using System;
using System.Linq;

namespace _04ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int arrayRotation = int.Parse(Console.ReadLine());

            for (int i = 0; i < arrayRotation; i++)
            {
                int lastNumber = numbers[0];
                int counter = 0;

                for (int j = 1; j < numbers.Length; j++)
                {
                    numbers[counter] = numbers[j];
                    counter++;
                }

                numbers[numbers.Length - 1] = lastNumber;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
