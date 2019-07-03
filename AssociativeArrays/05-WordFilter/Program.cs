using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputWords = Console.ReadLine().Split().Where(x => x.Length % 2 == 0).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, inputWords));
        }
    }
}
