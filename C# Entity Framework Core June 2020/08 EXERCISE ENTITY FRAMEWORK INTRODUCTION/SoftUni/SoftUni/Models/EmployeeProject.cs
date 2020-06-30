﻿using System;
using System.Collections.Generic;

namespace SoftUni.Models
{
    using SoftUni.Data;
    public partial class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
