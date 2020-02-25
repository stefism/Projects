using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = new List<Students>();

            while (true)
            {
                string[] inputStudent = Console.ReadLine().Split();

                if (inputStudent[0] == "end")
                {
                    break;
                }

                Students currentStudent = new Students();
                int studentAge = int.Parse(inputStudent[2]);

                currentStudent.FirstName = inputStudent[0];
                currentStudent.LastName = inputStudent[1];
                currentStudent.Age = studentAge;
                currentStudent.HomeTown = inputStudent[3];

                students.Add(currentStudent);
            }

            string town = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.HomeTown == town)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Students
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string HomeTown;
    }
}
