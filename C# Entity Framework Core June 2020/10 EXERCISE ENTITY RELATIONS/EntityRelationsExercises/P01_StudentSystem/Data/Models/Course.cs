using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            HomeworkSubmissions = new HashSet<Homework>();

            StudentsEnrolled = new HashSet<StudentCourse>();

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

        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
        // Колекциите се правят виртуални за да се помогне на EF в зареждането им после. Виртуалните методи могат да се override-ват.
        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }        
    }
}
