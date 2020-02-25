using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Console.ReadLine().Split().
                Where(w => w.Length % 2 == 0).
                OrderBy(x => x);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
