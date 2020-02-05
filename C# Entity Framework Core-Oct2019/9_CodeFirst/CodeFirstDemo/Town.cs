using CodeFirstDemo.Data;
using CodeFirstDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstDemo
{
    using static DataValidations.Town;

    public class Town
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        // Града има много на брой студенти;
        public ICollection<Student> Students { get; set; }
            = new HashSet<Student>(); 
        
        // HasSet е най-оптимално от към бързодействие, затова ползваме него. -> Това ни е връзката "много". Казваме, че града има много на брой студенти.
        // Студента има един град и той се описва първо със форен кия като колона и после с навигационно проперти за удобство. Това се прави в класа студент.
        // *** Задължително след това в класа StudentsDbContext в метода OnModelCreating трябва да се опише връзката между двете.
    }
}
