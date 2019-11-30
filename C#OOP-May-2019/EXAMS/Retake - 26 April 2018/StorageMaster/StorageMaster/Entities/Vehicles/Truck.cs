using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        private const int DefaultCapacity = 5;
        public Truck() : base(DefaultCapacity)
        {
        }
    }
}
