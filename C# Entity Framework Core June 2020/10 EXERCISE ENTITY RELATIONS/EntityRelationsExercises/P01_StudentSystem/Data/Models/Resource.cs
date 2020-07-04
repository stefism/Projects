using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int ResourceType { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Courses { get; set; }
    }
}
