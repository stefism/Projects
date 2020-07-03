using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            Homeworks = new HashSet<Homework>();

            StudentCourses = new HashSet<StudentCourse>();

            Resources = new HashSet<Resource>();
        }

        public int CourseId { get; set; }

        [MaxLength(80), Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Homework> Homeworks { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}
