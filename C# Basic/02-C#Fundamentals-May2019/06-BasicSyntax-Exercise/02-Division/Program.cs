using System;

namespace _02_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            //bool isDivide = false;

            if (number % 10 == 0)
            {
                Console.WriteLine("The number is divisible by 10");
                //return;
            }

            else if (number % 7 == 0)
            {
                Console.WriteLine("The number is divisible by 7");
                //return;
            }

            else if (number % 6 == 0)
            {
                Console.WriteLine("The number is divisible by 6");
                //return;
            }

            else if (number % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3");
               // return;
            }

            else if (number % 2 == 0)
            {
                Console.WriteLine("The number is divisible by 2");
                //return;
            }

            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
