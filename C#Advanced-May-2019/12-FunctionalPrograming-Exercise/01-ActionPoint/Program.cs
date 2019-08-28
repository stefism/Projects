using System;

namespace _01_ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = n =>
            Console.WriteLine(string.Join(Environment.NewLine, n));

            string[] inputNames = Console.ReadLine().Split();

            printNames(inputNames);
        }
    }
}
