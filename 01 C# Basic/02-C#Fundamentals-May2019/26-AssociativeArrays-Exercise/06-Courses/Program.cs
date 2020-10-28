using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var cousesAndStudents = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] courseInformation = Console.ReadLine().Split(" : ");
                string currentCourse = courseInformation[0];

                if (currentCourse == "end")
                {
                    cousesAndStudents = cousesAndStudents.OrderByDescending(x => x.Value.Count)
                        .ToDictionary(x => x.Key, x => x.Value);

                    foreach (var item in cousesAndStudents)
                    {
                        item.Value.Sort();
                    }

                    foreach (var item in cousesAndStudents)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value.Count}");
                        Console.WriteLine($"-- {string.Join(Environment.NewLine + "-- ", item.Value)}");
                    }
                    break;
                }

                string currentStudent = courseInformation[1];

                if (!cousesAndStudents.ContainsKey(currentCourse))
                {
                    cousesAndStudents[currentCourse] = new List<string>();
                }

                cousesAndStudents[currentCourse].Add(currentStudent);
            }
        }
    }
}
