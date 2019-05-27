using System;

namespace _04_RefacrotingPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            for (int number = 2; number <= inputNumber; number++)
            {
                bool isPrime = true;
                for (int currentNumber = 2; currentNumber < number; currentNumber++)
                {
                    if (number % currentNumber == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", number, isPrime.ToString().ToLower());
            }
        }
    }
}
