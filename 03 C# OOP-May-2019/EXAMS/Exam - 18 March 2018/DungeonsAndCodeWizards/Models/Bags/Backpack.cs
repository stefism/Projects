using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Backpack : Bag
    {
        private const int DefaultCapacity = 100;
        public Backpack() : base(DefaultCapacity)
        {
        }
    }
}
