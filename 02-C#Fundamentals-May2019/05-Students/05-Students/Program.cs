using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Students
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

                Students student = new Students();

                student.FirstName = currentStudent[0];
                student.LastName = currentStudent[1];
                student.Age = currentStudent[2];
                student.HomeTown = currentStudent[3];

                allStudents.Add(student);
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
    }
    class Students
    {
        public string FirstName;
        public string LastName;
        public string Age;
        public string HomeTown;
    }
}
