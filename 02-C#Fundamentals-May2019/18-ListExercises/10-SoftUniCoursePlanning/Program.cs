using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            string condition = string.Empty;

            while (true)
            {
                List<string> currentCommands = Console.ReadLine().Split(":").ToList();
                string command = currentCommands[0];

                if (currentCommands.Count > 1)
                {
                    condition = currentCommands[1];
                }
                
                if (command == "Add")
                {
                    if (!lessons.Contains(condition))
                    {
                        lessons.Add(condition);
                    }
                }

                else if (command == "Insert")
                {
                    if (!lessons.Contains(condition))
                    {
                        int index = int.Parse(currentCommands[2]);
                        lessons.Insert(index, condition);
                    }
                }

                else if (command == "Remove")
                {
                    if (lessons.Contains(condition))
                    {
                        lessons.RemoveAll(a => a.StartsWith(condition));
                    }
                }

                else if (command == "Exercise")
                {
                    if (lessons.Contains(condition))
                    {
                        int index = lessons.IndexOf(condition);
                        lessons.Insert(index+1, condition + "-Exercise");
                    }
                    else
                    {
                        lessons.Add(condition);
                        lessons.Add(condition + "-Exercise");
                    }
                }

                else if (command == "Swap")
                {
                    string lesson1 = currentCommands[1];
                    string lesson2 = currentCommands[2];

                    if (!lessons.Contains(lesson1) || !lessons.Contains(lesson2))
                    {
                        continue;
                    }
                    else
                    {
                        int indexLesson1 = lessons.IndexOf(lesson1);
                        int indexLesson2 = lessons.IndexOf(lesson2);

                        lessons[indexLesson1] = lesson2;
                        lessons[indexLesson2] = lesson1;

                        if (lessons.Contains(lesson1+ "-Exercise"))
                        {
                            lessons.Remove(lesson1 + "-Exercise");
                            lessons.Insert(indexLesson2+1, lesson1 + "-Exercise");
                        }

                        if (lessons.Contains(lesson2 + "-Exercise"))
                        {
                            lessons.Remove(lesson2 + "-Exercise");
                            lessons.Insert(indexLesson1 + 1, lesson2 + "-Exercise");
                        }
                    }
                }

                else if (command == "course start")
                {
                    int number = 1;

                    foreach (var item in lessons)
                    {
                        Console.WriteLine($"{number}.{item}");
                        number++;
                    }

                    break;
                }
            }
        }
    }
}
