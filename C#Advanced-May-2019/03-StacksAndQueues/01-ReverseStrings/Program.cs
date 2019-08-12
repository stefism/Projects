using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> charReverse = new Stack<char>();

            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                charReverse.Push(ch);
            }

            while (charReverse.Count > 0)
            {
                Console.Write(charReverse.Pop());
            }

            Console.WriteLine();
        }
    }
}
