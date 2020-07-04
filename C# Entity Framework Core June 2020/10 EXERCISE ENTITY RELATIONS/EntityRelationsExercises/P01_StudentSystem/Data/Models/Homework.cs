using System;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int ContentType { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student Students { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Courses { get; set; }
    }
}
