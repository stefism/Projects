using System;
using System.Linq;
using System.Collections.Generic;

namespace _09_ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> output = Enumerable.Range(1, endNumber).ToList();


            Func<List<int>, bool> isDivide = divide => divide.All(x => x % 2 == 0);

            //output = output.Where(isDivide).ToList();
        }
    }
}
