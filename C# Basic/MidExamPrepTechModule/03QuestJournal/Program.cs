using System;
using System.Collections.Generic;
using System.Linq;

namespace _03QuestJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                List<string> command = Console.ReadLine().Split(" - ").ToList();

                if (command[0] == "Start")
                {
                    if (!input.Contains(command[1]))
                    {
                        input.Add(command[1]);
                    }
                }

                else if (command[0] == "Complete")
                {
                    if (input.Contains(command[1]))
                    {
                        input.Remove(command[1]);
                    }
                }

                else if (command[0] == "Renew")
                {
                    if (input.Contains(command[1]))
                    {
                        string contains = command[1];
                        input.Remove(command[1]);
                        input.Add(contains);
                    }
                }

                else if (command[0] == "Side Quest")
                {
                    List<string> sideQuest = command[1].Split(":").ToList();

                    if (!input.Contains(sideQuest[1]))
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (input[i] == sideQuest[0])
                            {
                                input.Insert(i+1, sideQuest[1]);
                            }
                        }
                    }
                }

                else if (command[0] == "Retire!")
                {
                    Console.WriteLine(string.Join(", ", input));
                    break;
                }
            }
        }
    }
}
