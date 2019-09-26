using System;
using System.Linq;

namespace _03_Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                if (command == "END")
                {
                    break;
                }

                else if (command == "Push")
                {
                    int[] numbers = input.Skip(1).Select(int.Parse).ToArray();

                    stack.Push(numbers);
                }

                else if (command == "Pop")
                {
                    stack.Pop();
                }
            }

            if (stack.Count == 1)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }

                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
