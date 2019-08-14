using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int push = commands[0];
            int pop = commands[1];
            int find = commands[2];

            var stack = new Stack<int>(elements.Take(push));

            for (int i = 0; i < pop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(find))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
