using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            List<int>  numbers = new List<int>() {number1, number2, number3 };

            numbers.Sort();

            for (int i = 2; i >= 0; i--)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
