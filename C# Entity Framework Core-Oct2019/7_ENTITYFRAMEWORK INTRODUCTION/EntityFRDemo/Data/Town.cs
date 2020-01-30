using System;
using System.Collections.Generic;

namespace EntityFRDemo.Data
{
    public  class Town
    {
        public Town()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int TownId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
