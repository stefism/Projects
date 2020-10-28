using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];

                if (command == "Change")
                {
                    int currentNumber = int.Parse(commandArgs[1]);
                    int newNumber = int.Parse(commandArgs[2]);
                     
                    if (numbers.Contains(currentNumber))
                    {
                        int index = numbers.IndexOf(currentNumber);
                        numbers[index] = newNumber;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
