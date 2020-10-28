using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divideNumber = int.Parse(Console.ReadLine());

            numbers = DivideNumbers(numbers, divideNumber);

            numbers.Reverse();

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> DivideNumbers(List<int> numbers, int divideNumber)
        {
            List<int> outputNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (number % divideNumber != 0)
                {
                    outputNumbers.Add(number);
                }
            }

            return outputNumbers;
        }
    }
}
