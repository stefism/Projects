using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] currentStudent = Console.ReadLine().Split();

                string studentName = currentStudent[0];
                double studentGrade = double.Parse(currentStudent[1]);

                if (!students.ContainsKey(studentName))
                {
                    students[studentName] = new List<double>();
                }

                students[studentName].Add(studentGrade);
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => $"{x:F2}"))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}
