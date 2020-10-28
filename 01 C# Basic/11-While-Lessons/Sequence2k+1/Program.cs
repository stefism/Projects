using System;

namespace Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = 1;

            while (a <= n)
            {
                Console.WriteLine(a);
                a = (a * 2) + 1;
                

            }
        }
    }
}
