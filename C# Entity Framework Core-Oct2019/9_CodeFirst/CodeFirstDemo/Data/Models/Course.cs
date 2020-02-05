using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstDemo.Data.Models
{
    using static DataValidations.Course;
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<StudentInCourse> Students { get; set; } 
            = new HashSet<StudentInCourse>();

        public ICollection<Homework> Homeworks { get; set; } 
            = new HashSet<Homework>();
    }
}
