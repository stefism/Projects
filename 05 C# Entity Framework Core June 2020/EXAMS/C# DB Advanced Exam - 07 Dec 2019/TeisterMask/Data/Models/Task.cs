using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
    public class Task
    {
        public Task()
        {
            EmployeesTasks = new HashSet<EmployeeTask>();
        }

        public int Id { get; set; }
        //•	Id - integer, Primary Key

        [Required, MaxLength(40)]
        public string Name { get; set; }
        //•	Name - text with length [2, 40] (required)

        public DateTime OpenDate { get; set; }
        //•	OpenDate - date and time (required)

        public DateTime DueDate { get; set; } //TODO: Maybe NULL ???
        //•	DueDate - date and time (required)

        public ExecutionType ExecutionType { get; set; }
        //•	ExecutionType - enumeration of type ExecutionType, with possible values (ProductBacklog, SprintBacklog, InProgress, Finished) (required)

        public virtual LabelType LabelType { get; set; }
        //•	LabelType - enumeration of type LabelType, with possible values (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)

        public int ProjectId { get; set; }
        //•	ProjectId - integer, foreign key (required)

        public virtual Project Project { get; set; }
        //•	Project - Project 

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
        //•	EmployeesTasks - collection of type EmployeeTask
    }
}
