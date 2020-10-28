using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Students_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> allStudents = new List<Students>();

            while (true)
            {
                List<string> currentStudent = Console.ReadLine().Split().ToList();

                if (currentStudent[0] == "end")
                {
                    break;
                }

                bool isStudentExitst = IsStudentExist(allStudents, currentStudent[0], currentStudent[1]);

                if (isStudentExitst)
                {
                    Students student = GetStudents(allStudents, currentStudent[0], currentStudent[1]);

                    student.FirstName = currentStudent[0];
                    student.LastName = currentStudent[1];
                    student.Age = currentStudent[2];
                    student.HomeTown = currentStudent[3];

                }
                else
                {
                    Students student = new Students();

                    student.FirstName = currentStudent[0];
                    student.LastName = currentStudent[1];
                    student.Age = currentStudent[2];
                    student.HomeTown = currentStudent[3];

                    allStudents.Add(student);
                }
            }

            string homeTown = Console.ReadLine();

            foreach (var item in allStudents)
            {
                if (item.HomeTown == homeTown)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }
        }
        static Students GetStudents(List<Students> allStudents, string firstName, string lastName)
        {
            Students existingStudent = null;

            foreach (var item in allStudents)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    existingStudent = item;
                }
            }

            return existingStudent;
        }
        static bool IsStudentExist(List<Students> allStudents, string firstName, string lastName)
        {
            foreach (var item in allStudents)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
    class Students
    {
        public string FirstName;
        public string LastName;
        public string Age;
        public string HomeTown;
    }
}
