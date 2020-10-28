using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_BasicQueueOperations
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

            var queue = new Queue<int>(elements.Take(push));

            for (int i = 0; i < pop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(find))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
