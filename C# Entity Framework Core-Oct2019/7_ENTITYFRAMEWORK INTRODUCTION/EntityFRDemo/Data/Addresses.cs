using System;
using System.Collections.Generic;

namespace EntityFRDemo.Data
{
    public partial class Addresses
    {
        public Addresses()
        {
            Employees = new HashSet<Employees>();
        }

        public int AddressId { get; set; }
        public string AddressText { get; set; }
        public int? TownId { get; set; }

        public virtual Town Town { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
