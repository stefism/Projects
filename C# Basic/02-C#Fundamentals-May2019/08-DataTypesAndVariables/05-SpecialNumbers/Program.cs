using System;

namespace _05_SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersForPrint = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numbersForPrint; i++)
            {
                int number = i;
                int sum = 0;

                while (number > 0)
                {
                    int lastNumber = number % 10;
                    sum += lastNumber;
                    number /= 10;
                }

                bool isTrueOrFalse = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine($"{i} -> {isTrueOrFalse}");
            }
        }
    }
}
