using System;
using System.Linq;

namespace _02_FuncExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(", ")
                .Select(int.Parse).Select(NumbersSquare).ToArray();

            //int[] inputNumbers = Console.ReadLine().Split(", ") .Select(int.Parse).ToArray();

            //inputNumbers = SquareNumbers(inputNumbers);

            Console.WriteLine(string.Join(", ", inputNumbers));
        }

        static int[] SquareNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] * 2;
            }

            return numbers;
        }

        static Func<int, int> NumbersSquare = n => n * 2;

        //static Func<int, int> NumbersSquare(int n)
        //{
        //    return n => n * 2;
        //} 
    }
}
