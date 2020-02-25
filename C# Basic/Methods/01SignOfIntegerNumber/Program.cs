using System;

namespace _01SignOfIntegerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            SignOfIntegerNumber(number);
        }

        static void SignOfIntegerNumber(int number)
        {
            int controlNumber = 0;

            if (number > controlNumber)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < controlNumber)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else if (number == controlNumber)
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }
    }
}
