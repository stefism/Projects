using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Students_2_0
{

    class Program
    {
        static bool IfExist = false;
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

                string firstName = inputStudent[0];
                string lastName = inputStudent[1];
                int studentAge = int.Parse(inputStudent[2]);
                string homeTown = inputStudent[3];

                currentStudent.FirstName = firstName;
                currentStudent.LastName = lastName;
                currentStudent.Age = studentAge;
                currentStudent.HomeTown = homeTown;

                IfExist = false;

                students = FindAndReplaceExistingStudents(students, firstName, lastName, studentAge, homeTown);

                if (!IfExist)
                {
                    students.Add(currentStudent);
                }
                
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

        static List<Students> FindAndReplaceExistingStudents(List<Students> students, string firstName, string lastName, int age, string homeTown)
        {
            foreach (var item in students)
            {
                if (firstName == item.FirstName && lastName == item.LastName)
                {
                    IfExist = true;
                    item.FirstName = firstName;
                    item.LastName = lastName;
                    item.Age = age;
                    item.HomeTown = homeTown;
                }
            }

            return students;
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
