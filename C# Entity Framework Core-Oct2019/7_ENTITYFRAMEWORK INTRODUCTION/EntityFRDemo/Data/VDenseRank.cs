using System;
using System.Collections.Generic;

namespace EntityFRDemo.Data
{
    public partial class VDenseRank
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public long? Rank { get; set; }
    }
}
