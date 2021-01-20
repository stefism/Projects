using System;

namespace Fibonacci
{
    class Fibonacci
    {
        static long[] numbers;

        static long Fib(long n)
        {
            if (numbers[n] != 0)
            {
                return numbers[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            long result = Fib(n - 1) + Fib(n - 2);

            numbers[n] = result;

            return result;
        }

        static void Main()
        {
            numbers = new long[100]; //usualy n+1

            var result = Fib(20);
            Console.WriteLine(result);
        }
    }
}
