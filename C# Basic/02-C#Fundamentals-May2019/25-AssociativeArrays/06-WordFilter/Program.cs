using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split().Where(w => w.Length % 2 == 0)
                .ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
