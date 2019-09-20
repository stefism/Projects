using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (true)
            {
                string[] command = Console.ReadLine().ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "end")
                {
                    Console.WriteLine($"Sum: {stack.Sum()}");

                    break;
                }

                else if (command.Length == 2)
                {
                    int elementToRemove = int.Parse(command[1]);

                    if (stack.Count >= elementToRemove)
                    {
                        for (int i = 0; i < elementToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                else if (command.Length == 3)
                {
                    int firstElementToAdd = int.Parse(command[1]);
                    int secondElementToAdd = int.Parse(command[2]);

                    stack.Push(firstElementToAdd);
                    stack.Push(secondElementToAdd);
                }
            }
        }
    }
}
