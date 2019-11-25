using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        public ICollection<string> Items { get; protected set; }

        public Backpack()
        {
            Items = new List<string>();
        }
    }
}
