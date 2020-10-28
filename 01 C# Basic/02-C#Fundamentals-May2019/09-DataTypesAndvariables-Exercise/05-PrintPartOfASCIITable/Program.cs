using System;

namespace _05_PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialASCIICode = int.Parse(Console.ReadLine());
            int finalASCIICode = int.Parse(Console.ReadLine());

            for (int i = initialASCIICode; i <= finalASCIICode; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
