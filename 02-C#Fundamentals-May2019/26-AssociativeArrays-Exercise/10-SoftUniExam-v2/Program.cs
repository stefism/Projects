using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Student
    {

        public string Course { get; set; }
        public int Points { get; set; }


        public Student(string course, int pionts)
        {
            Course = course;
            Points = pionts;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> dictMax = new Dictionary<string, Student>();
            Dictionary<string, int> dictCount = new Dictionary<string, int>();

            string comand = Console.ReadLine();

            while (comand != "exam finished")
            {
                string[] info = comand.Split('-');
                string name = info[0];

                if (info[1] == "banned")
                {
                    dictMax = dictMax.Where(x => x.Key != name).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                }
                else
                {
                    string course = info[1];
                    int points = int.Parse(info[2]);

                    if (!dictCount.ContainsKey(course))
                    {
                        dictCount[course] = 0;
                    }
                    dictCount[course]++;

                    if (!dictMax.ContainsKey(name))
                    {
                        dictMax[name] = new Student(course, points);
                    }

                    foreach (var item in dictMax.Where(x => x.Key == name && x.Value.Course == course))
                    {
                        if (item.Value.Points < points)
                        {
                            item.Value.Points = points;
                        }
                    }
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var item in dictMax.OrderByDescending(x => x.Value.Points).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value.Points}");
            }

            Console.WriteLine("Submissions:");

            foreach (var item in dictCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

        }
    }
}