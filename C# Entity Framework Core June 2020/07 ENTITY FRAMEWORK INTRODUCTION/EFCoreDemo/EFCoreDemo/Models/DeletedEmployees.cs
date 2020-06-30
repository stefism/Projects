using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDemo.Models
{
    [Table("Deleted_Employees")]
    public partial class DeletedEmployees
    {
        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
    }
}
