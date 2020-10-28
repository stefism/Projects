using System;

namespace _3EqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberTree = int.Parse(Console.ReadLine());

            if (numberOne != numberTwo)
            {
                Console.WriteLine("no");
            }
            else if (numberTree != numberTwo)
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine("yes");
            }

            }
        }
    }
