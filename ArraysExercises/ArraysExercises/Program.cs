using System;
using System.Linq;

namespace _01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLenght = int.Parse(Console.ReadLine());

            int[] numbers = new int[arrayLenght];

            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
                sum += numbers[i];
            }

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(sum);
        }
    }
}
