using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputChilds = Console.ReadLine().Split();
            int number = int.Parse(Console.ReadLine());

            Queue<string> children = new Queue<string>(inputChilds);

            while (children.Count != 1)
            {
                for (int i = 1; i < number; i++)
                {
                    children.Enqueue(children.Dequeue());
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
