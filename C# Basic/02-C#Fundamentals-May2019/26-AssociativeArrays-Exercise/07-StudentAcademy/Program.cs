using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudent = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudent; i++)
            {
                string studentName = Console.ReadLine();
                double studentAverage = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentName))
                {
                    students[studentName] = new List<double>();
                }

                students[studentName].Add(studentAverage);
            }

            //students = students.OrderByDescending(x => x.Value).
                //ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine(string.Join(Environment.NewLine, students
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .Select(x => $"{x.Key} -> {x.Value.Average():F2}")));
        }
    }
}
