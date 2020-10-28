using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Retake Mid Exam 18 December 2018. 02 Santa's List

            List<string> kidsNames = Console.ReadLine().Split('&').ToList();

            while (true)
            {
                List<string> command = Console.ReadLine().Split().ToList();

                if (command[0] == "Bad")
                {
                    if (!kidsNames.Contains(command[1]))
                    {
                        kidsNames.Insert(0, command[1]);
                    }
                }

                else if (command[0] == "Good")
                {
                    if (kidsNames.Contains(command[1]))
                    {
                        kidsNames.Remove(command[1]);
                    }
                }

                else if (command[0] == "Rename")
                {
                    if (kidsNames.Contains(command[1]))
                    {
                        for (int i = 0; i < kidsNames.Count; i++)
                        {
                            if (kidsNames[i].Contains(command[1]))
                            {
                                kidsNames[i] = command[2];
                            }
                        }
                    }
                }

                else if (command[0] == "Rearrange")
                {
                    if (kidsNames.Contains(command[1]))
                    {
                        kidsNames.Remove(command[1]);
                        kidsNames.Add(command[1]);
                    }
                }

                else if (command[0] == "Finished!")
                {
                    Console.WriteLine(string.Join(", ", kidsNames));
                    break;
                }
            }
        }
    }
}
