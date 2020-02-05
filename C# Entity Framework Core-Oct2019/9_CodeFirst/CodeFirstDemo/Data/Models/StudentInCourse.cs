using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstDemo.Data.Models
{
    public class StudentInCourse
    {
        // Първо връзката към студента - едно към много;
        // После в студента трябва да направим колекцията от курсовете.
        public int StudentId { get; set; }

        public Student Student { get; set; }

        // После за курса;
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
