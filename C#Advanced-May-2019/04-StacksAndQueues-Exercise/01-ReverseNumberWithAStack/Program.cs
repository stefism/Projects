using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ReverseNumberWithAStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
