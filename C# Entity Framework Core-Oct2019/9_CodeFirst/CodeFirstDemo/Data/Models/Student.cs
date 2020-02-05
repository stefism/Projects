using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstDemo.Data.Models
{
    using static DataValidations.Student;
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(NameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public bool HasScholarship { get; set; }

        public DateTime RegistrationDate { get; set; }

        public StudentType Type { get; set; }

        public int TownId { get; set; } // Като сложим името на класа и до него Id, той се сеща, че това е ForeignKey. Това беше int? в началото, защото имахме добавен един студент и след това добавихме това проперти. Затова в началото трябва да е нул за да не гърми, а после като се ъпнейтне базата (добавени са градове на всички студенти), можем да го върнем да не е нул и да си направим миграция за да го ъпдейтнем.

        public Town Town { get; set; } // Навигационно проперти за да са по-лесни заявките.
                                       // Когато се прави едно към много, от страна на едното, слагам int \името на класа\ Id към което се реферира и пропърти, което е директния клас.
                                       // След това трябва да отидем в Town да кажем, че има много на брой студенти.
                                       // *** Задължително след това в класа StudentsDbContext в метода OnModelCreating трябва да се опише връзката между двете.

        public ICollection<StudentInCourse> Courses { get; set; }
            = new HashSet<StudentInCourse>();

        public ICollection<Homework> Homeworks { get; set; } 
            = new HashSet<Homework>();

        [NotMapped]
        public string FullName
        {
            get
            {
                if (MiddleName == null)
                {
                    return $"{FirstName} {LastName}";
                }

                return $"{FirstName} {MiddleName} {LastName}";
            }
        }
    }
}
