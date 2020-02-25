using System;

namespace NumbersFromN_To_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; n > i; n--)
            {
                Console.WriteLine(n);
            }
        }
    }
}
