using System;
using System.Collections.Generic;
using System.Linq;

namespace _07ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool changes = false;

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                if (commands[0] == "end")
                {
                    if (changes)
                    {
                        Console.WriteLine(string.Join(" ", numbers));
                    }
                    break;
                }
                else if (commands[0] == "Add")
                {
                    numbers.Add(int.Parse(commands[1]));
                    changes = true;
                }
                else if (commands[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commands[1]));
                    changes = true;
                }
                else if (commands[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commands[1]));
                    changes = true;
                }
                else if (commands[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                    changes = true;
                }

                else if (commands[0] == "Contains")
                {
                    bool contains = numbers.Contains(int.Parse(commands[1]));

                    if (contains)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (commands[0] == "PrintEven")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
                }

                else if (commands[0] == "PrintOdd")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 1)));
                }

                else if (commands[0] == "GetSum")
                {
                    int getSum = numbers.Sum();
                    Console.WriteLine(getSum);
                }

                else if (commands[0] == "Filter")
                {
                    if (commands[1] == "<")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x < int.Parse(commands[2]))));
                    }

                    else if (commands[1] == ">")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x > int.Parse(commands[2]))));
                    }

                    else if (commands[1] == ">=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x >= int.Parse(commands[2]))));
                    }

                    else if (commands[1] == "<=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x <= int.Parse(commands[2]))));
                    }
                }
            }
        }
    }
}
