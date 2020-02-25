using System;

namespace _07NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintMatrixFromNumber(number);
        }

        static void PrintMatrixFromNumber(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(number + " ");
                for (int j = 1; j < number; j++)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine();
                //Console.Write(number + " ");
            }
        }
    }
}
