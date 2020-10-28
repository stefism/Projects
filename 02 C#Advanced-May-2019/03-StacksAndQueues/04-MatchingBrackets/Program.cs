using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> brackedFinder = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == '(')
                {
                    brackedFinder.Push(i);
                }

                if (currentChar == ')')
                {
                    int start = brackedFinder.Pop();
                    Console.WriteLine(input.Substring(start, i - start + 1));
                }
            }
        }
    }
}
