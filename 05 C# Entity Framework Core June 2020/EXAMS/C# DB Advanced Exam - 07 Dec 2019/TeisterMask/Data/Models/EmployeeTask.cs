﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class EmployeeTask
    {
        public int EmployeeId { get; set; }
        //•	EmployeeId - integer, Primary Key, foreign key (required)

        public virtual Employee Employee { get; set; }
        //•	Employee -  Employee

        public int TaskId { get; set; }
        //•	TaskId - integer, Primary Key, foreign key (required)

        public virtual Task Task { get; set; }
        //•	Task - Task
    }
}
