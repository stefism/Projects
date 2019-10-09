using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private List<Student> studentsDictionary;

        public StudentSystem()
        {
            studentsDictionary = new List<Student>();
        }

        public void CreateStudent(Student student)
        {
            if (!studentsDictionary.Contains(student))
            {
                studentsDictionary.Add(student);
            }
        }

        public string ShowStudent(string studentName)
        {
            Student student = studentsDictionary
                .FirstOrDefault(s => s.Name == studentName);

            return student.ToString();
        }

        public void Exit()
        {
            Environment.Exit(1);
        }
    }
}
