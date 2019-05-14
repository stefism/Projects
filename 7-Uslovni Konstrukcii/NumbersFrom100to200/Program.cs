using System;

namespace NumbersFrom100to200
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number > 200)
            {
                Console.WriteLine("Greater than 200");
            }

            else if (number < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else
            {
                Console.WriteLine("Between 100 and 200");
            }

        }
    }
}
