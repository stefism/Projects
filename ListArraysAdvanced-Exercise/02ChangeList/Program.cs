using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                if (commands[0] == "end")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }

                else if (commands[0] == "Delete")
                {
                    int numberToManupulateInArray = int.Parse(commands[1]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == numberToManupulateInArray)
                        {
                            numbers.RemoveAt(i);
                        }

                        //-същото като горното//

                        // *** numbers.RemoveAll(x => x == numberToManupulateInArray);

                        // премахва всички елементи с този номер от списъка
                    }
                }

                else if (commands[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                }
            }
        }
    }
}
