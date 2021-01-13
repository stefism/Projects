using System;

namespace _04._Recursive_Factorial
{
    class RecursuveFactorial
    {
        static long Factorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }

            return num * Factorial(num - 1);
        }

        static void Main(string[] args)
        {
            
        }
    }
}
