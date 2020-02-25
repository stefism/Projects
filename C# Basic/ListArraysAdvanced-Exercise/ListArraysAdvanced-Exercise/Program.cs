using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int wagonCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                if (commands[0] == "end")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }
                else if (commands[0] == "Add")
                {
                    numbers.Add(int.Parse(commands[1]));
                }
                else
                {
                    int addPeople = int.Parse(commands[0]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= wagonCapacity)
                        {
                            if (addPeople + numbers[i] <= wagonCapacity)
                            {
                                int currentIndex = numbers[i];
                                numbers.RemoveAt(i);
                                numbers.Insert(i, currentIndex+addPeople);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
