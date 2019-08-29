using System;
using System.Linq;

namespace _05_Applied_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int> addOne = x => x += 1;
            Func<int, int> subtractOne = x => x -= 1;
            Func<int, int> multiplyByTwo = x => x *= 2;

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    inputNumbers = inputNumbers.Select(addOne).ToArray();
                }

                else if (command == "multiply")
                {
                    inputNumbers = inputNumbers.Select(multiplyByTwo).ToArray();
                }

                else if (command == "subtract")
                {
                    inputNumbers = inputNumbers.Select(subtractOne).ToArray();
                }

                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", inputNumbers));
                }

                command = Console.ReadLine();
            }
        }
    }
}
