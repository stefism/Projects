using System;
using System.Linq;
using System.Collections.Generic;

namespace _03_PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputElements = int.Parse(Console.ReadLine());

            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < inputElements; i++)
            {
                string[] currentElements = Console.ReadLine().Split();

                foreach (var element in currentElements)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));
        }
    }
}
