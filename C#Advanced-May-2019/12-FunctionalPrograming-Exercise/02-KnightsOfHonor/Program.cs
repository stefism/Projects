using System;

namespace _02_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = n =>
            Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", n));

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printNames(names);
        }
    }
}
