using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            input.RemoveAll(a => a<0);

            if (input.Count > 0)
            {
                input.Reverse();
                Console.WriteLine(string.Join(" ", input));
            }
            else
            {
                Console.WriteLine("empty");
            }
            
        }
    }
}
