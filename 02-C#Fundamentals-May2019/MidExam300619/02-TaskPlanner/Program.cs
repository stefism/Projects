using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_TaskPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputTask = Console.ReadLine().Split().Select(int.Parse).ToList();

            int completedTask = 0;
            int incompletedTask = 0;
            int droppedTask = 0;

            while (true)
            {
                List<string> currentCommands = Console.ReadLine().Split().ToList();

                string command = currentCommands[0];

                if (command == "End")
                {
                    for (int i = 0; i < inputTask.Count; i++)
                    {
                        if (inputTask[i] > 0)
                        {
                            Console.Write(inputTask[i] + " ");
                        }
                    }
                    Console.WriteLine();
                    break;
                }

                switch (command)
                {
                    case "Complete":
                        int indexToComplete = int.Parse(currentCommands[1]);

                        if (indexToComplete >= 0 && indexToComplete < inputTask.Count)
                        {
                            inputTask[indexToComplete] = 0;
                        }
                        break;

                    case "Change":
                        int indexToChange = int.Parse(currentCommands[1]);
                        int newTimeToPut = int.Parse(currentCommands[2]);

                        if (indexToChange >= 0 && indexToChange < inputTask.Count)
                        {
                            if (newTimeToPut == 0)
                            {
                                inputTask.Remove(indexToChange);
                                completedTask++;
                            }
                            else
                            {
                                inputTask[indexToChange] = newTimeToPut;
                            }
                        }
                        break;

                    case "Drop":
                        int indexToDrop = int.Parse(currentCommands[1]);

                        if (indexToDrop >= 0 && indexToDrop < inputTask.Count)
                        {
                            inputTask[indexToDrop] = -1;
                        }
                        break;

                    case "Count":
                        if (currentCommands[1] == "Completed")
                        {
                            for (int i = 0; i < inputTask.Count; i++)
                            {
                                if (inputTask[i] == 0)
                                {
                                    completedTask++;
                                }
                            }

                            Console.WriteLine(completedTask);
                        }

                        else if (currentCommands[1] == "Incomplete")
                        {
                            for (int i = 0; i < inputTask.Count; i++)
                            {
                                if (inputTask[i] > 0)
                                {
                                    incompletedTask++;
                                }
                            }

                            Console.WriteLine(incompletedTask);
                        }

                        else if (currentCommands[1] == "Dropped")
                        {
                            for (int i = 0; i < inputTask.Count; i++)
                            {
                                if (inputTask[i] == -1)
                                {
                                    droppedTask++;
                                }
                            }
                            Console.WriteLine(droppedTask);
                        }

                        break;
                }
            }
        }
    }
}
