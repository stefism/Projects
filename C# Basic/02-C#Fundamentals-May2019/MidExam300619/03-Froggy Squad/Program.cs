using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputFrogs = Console.ReadLine().Split().ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                string currentCommand = commands[0];

                if (currentCommand == "Join")
                {
                    inputFrogs.Add(commands[1]);
                }

                else if (currentCommand == "Jump") // Евентуално тука с индекса!!!
                {
                    string frogName = commands[1];
                    int indexToJump = int.Parse(commands[2]);

                    if (indexToJump >= 0 && indexToJump < inputFrogs.Count)
                    {
                        inputFrogs.Insert(indexToJump, frogName);
                    }
                }

                else if (currentCommand == "Dive")
                {
                    int index = int.Parse(commands[1]);

                    if (index >= 0 && index < inputFrogs.Count)
                    {
                        inputFrogs.RemoveAt(index);
                    }
                }

                else if (currentCommand == "First")
                {
                    int count = int.Parse(commands[1]);
                    if (count > inputFrogs.Count)
                    {
                        count = inputFrogs.Count;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write(inputFrogs[i] + " ");
                    }
                    Console.WriteLine();
                }

                else if (currentCommand == "Last")
                {
                    int count = int.Parse(commands[1]);

                    if (count > inputFrogs.Count)
                    {
                        count = 0;
                    }
                    else
                    {
                        count = inputFrogs.Count - count;
                    }

                    for (int i = count; i < inputFrogs.Count; i++)
                    {
                        Console.Write(inputFrogs[i] + " ");
                    }
                    Console.WriteLine();
                }

                else if (currentCommand == "Print")
                {
                    if (commands[1] == "Normal")
                    {
                        Console.WriteLine("Frogs: " + string.Join(" ", inputFrogs));
                        break;
                    }
                    else if (commands[1] == "Reversed")
                    {
                        inputFrogs.Reverse();
                        Console.WriteLine("Frogs: " + string.Join(" ", inputFrogs));
                        break;
                    }
                }
            }
        }
    }
}
