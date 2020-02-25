using System;

namespace NumbersEndingInSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                // Число, модулно разделено на 10, винаги дава последната
                // цифра на числото.

                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
