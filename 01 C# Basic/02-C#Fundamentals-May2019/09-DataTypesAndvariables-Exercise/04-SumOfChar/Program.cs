using System;

namespace _04_SumOfChar
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCharToSum = int.Parse(Console.ReadLine());
            int sumOfChar = 0;

            for (int i = 0; i < numberOfCharToSum; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                sumOfChar += currentChar;
            }

            Console.WriteLine($"The sum equals: {sumOfChar}");
        }
    }
}
