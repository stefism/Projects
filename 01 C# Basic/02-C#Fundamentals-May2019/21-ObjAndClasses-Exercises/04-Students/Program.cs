using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            List<Students> students = new List<Students>();

            for (int i = 0; i < countOfStudents; i++)
            {
                List<string> currentStudent = Console.ReadLine().Split().ToList();

                string firstName = currentStudent[0];
                string lastName = currentStudent[1];
                double grade = double.Parse(currentStudent[2]);

                Students student = new Students(firstName, lastName, grade);

                students.Add(student);
            }

            students = students.OrderByDescending(a => a.Grade).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, students));
        }
    }
    class Students
    {
        public string FirstName;
        public string SecondName;
        public double Grade;

        public Students(string firstName, string secondName, double grade)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName}: {this.Grade:F2}";
        }
    }
}
