using System;
using System.Collections.Generic;
using System.Linq;

namespace _02PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowForTriangle = int.Parse(Console.ReadLine());
            int counter = 1;

            List<int> triangle = new List<int>();

            triangle.Add(1);
            Console.WriteLine(triangle[0]);
            triangle.Add(1);

            Console.WriteLine(string.Join(" ", triangle));

            for (int i = 0; i < rowForTriangle-2; i++)
            {
                triangle.Insert(counter, triangle[i]+ triangle[i+1]);

                Console.WriteLine(string.Join(" ", triangle));

                if (counter == triangle.Count)
                {
                    continue;
                }

                counter++;
            }
        }
    }
}
