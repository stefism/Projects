using System;

namespace Probi
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int a = 3;
            int b = 3;

            while (i < a)
            {
                Console.WriteLine("i = " + i);
                int j = 0;
                while (j < b)

                {
                    Console.WriteLine("j = " + j);
                    j++;
                }
                Console.WriteLine();
                i++;

            }
        }
    }
}
