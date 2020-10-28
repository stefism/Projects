using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeesTasks = new HashSet<EmployeeTask>();
        }

        public int Id { get; set; }
        //•	Id - integer, Primary Key

        [Required, MaxLength(40)] // TODO: REGEX
        public string Username { get; set; }
        //•	Username - text with length [3, 40]. Should contain only lower or upper case letters and/or digits. (required)

        [Required]
        public string Email { get; set; }
        //•	Email – text (required). Validate it! There is attribute for this job.

        [Required]
        public string Phone { get; set; } // TODO: REGEX
        //•	Phone - text. Consists only of three groups (separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
        //•	EmployeesTasks - collection of type EmployeeTask
    }
}
