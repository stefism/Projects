using System;

namespace _12_RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            int lastNumber = 0;
            bool isSpecial = false;
            for (int i = 1; i <= inputNumber; i++)
            {
                lastNumber = i;

                while (i > 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }
                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", lastNumber, isSpecial);
                sum = 0;
                i = lastNumber;
            }
        }
    }
}
