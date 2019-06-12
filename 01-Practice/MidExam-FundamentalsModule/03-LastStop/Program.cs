using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Mid Exam - 10 March 2019 Group 1

            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                string currentCommand = commands[0];

                switch (currentCommand)
                {
                    case "Change":
                        int paintingNumber = int.Parse(commands[1]);
                        int changedNumber = int.Parse(commands[2]);
                        int index = input.FindIndex(a => a == paintingNumber);

                        if (index != -1)
                        {
                            input[index] = changedNumber;
                        }
                        break;

                    case "Hide":
                        int hideNumber = int.Parse(commands[1]);
                        int hideIndex = input.FindIndex(a => a == hideNumber);

                        if (hideIndex != -1)
                        {
                            input.RemoveAt(hideIndex);
                        }
                        break;

                    case "Switch":
                        int switch1 = int.Parse(commands[1]);
                        int switch2 = int.Parse(commands[2]);

                        int indexSwitch1 = input.FindIndex(a => a == switch1);
                        int indexSwitch2 = input.FindIndex(a => a == switch2);

                        if (indexSwitch1 != -1 && indexSwitch2 != -1)
                        {
                            input[indexSwitch2] = switch1;
                            input[indexSwitch1] = switch2;
                        }
                        break;

                    case "Insert": // Е тука може да има проблем с инсертването.
                        int insertIndex = int.Parse(commands[1]);
                        int givenNumber = int.Parse(commands[2]);

                        if (insertIndex >=0 && insertIndex <= input.Count-1) // Е тука може да има проблем с инсертването.
                        {
                            input.Insert(insertIndex+1, givenNumber);
                        }
                        break;

                    case "Reverse":
                        input.Reverse();
                        break;

                    case "END":
                        Console.WriteLine(string.Join(" ", input));
                        return;
                }
            }
        }
    }
}
