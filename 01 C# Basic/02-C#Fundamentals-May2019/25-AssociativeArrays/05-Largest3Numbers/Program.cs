using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split().Select(int.Parse)
                .OrderByDescending(n => n).Take(3).ToList()
                .ForEach(x => Console.Write(x + " "));
        }
    }
}
