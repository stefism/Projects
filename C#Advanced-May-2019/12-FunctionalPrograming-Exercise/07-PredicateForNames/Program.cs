using System;
using System.Linq;

namespace _07_PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Console.WriteLine(string.Join(Environment.NewLine, names
                .Where(x => x.Length <= nameLength)));
        }
    }
}
