using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                if (commands[0] == "End")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }

                else if (commands[0] == "Add")
                {
                    numbers.Add(int.Parse(commands[1]));
                }

                else if (commands[0] == "Remove")
                {
                    if (int.Parse(commands[1]) >= 0 && int.Parse(commands[1]) <= numbers.Count-1)
                    {
                        numbers.RemoveAt(int.Parse(commands[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }

                else if (commands[0] == "Insert")
                {
                    if (int.Parse(commands[2]) >= 0 && int.Parse(commands[2]) <= numbers.Count-1)
                    {
                        numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }

                else if (commands[0] == "Shift")
                {
                    if (commands[1] == "left")
                    {
                        for (int i = 0; i < int.Parse(commands[2]); i++)
                        {
                            int firstNumber = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(firstNumber);
                        }
                    }

                    else if (commands[1] == "right")
                    {
                        for (int i = 0; i < int.Parse(commands[2]); i++)
                        {
                            int lastNumber = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, lastNumber);
                        }
                    }
                }
            }
        }
    }
}
