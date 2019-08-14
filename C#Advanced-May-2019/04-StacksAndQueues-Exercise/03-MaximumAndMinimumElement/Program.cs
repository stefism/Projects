using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());
            Stack<int> elements = new Stack<int>();

            for (int i = 0; i < operations; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int operation = command[0];

                switch (operation)
                {
                    case 1:
                        int element = command[1];
                        elements.Push(element);
                        break;

                    case 2:
                        if (elements.Count > 0)
                        {
                            elements.Pop();
                        }
                        break;

                    case 3:
                        if (elements.Count > 0)
                        {
                            Console.WriteLine(elements.Max());
                        }
                        break;

                    case 4:
                        if (elements.Count > 0)
                        {
                            Console.WriteLine(elements.Min());
                        }
                        break;
                }
            }

            //int[] output = elements.ToArray();
            //output = output.Reverse().ToArray();

            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
