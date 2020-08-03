using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        //•	Id - integer, Primary Key

        [Required, MaxLength(40)]
        public string Name { get; set; }
        //•	Name - text with length [2, 40] (required)

        public DateTime OpenDate { get; set; }
        //•	OpenDate - date and time (required)

        public DateTime? DueDate { get; set; }
        //•	DueDate - date and time (can be null)

        public virtual ICollection<Task> Tasks { get; set; }
        //•	Tasks - collection of type Task
    }
}
