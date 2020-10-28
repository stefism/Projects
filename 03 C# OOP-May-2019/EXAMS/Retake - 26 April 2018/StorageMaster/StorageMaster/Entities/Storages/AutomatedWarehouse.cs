using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Vehicles;
using System.Linq;

namespace StorageMaster.Entities.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultGarageSlots = 2;
        
        public AutomatedWarehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, 
                  new List<Vehicle> 
                  { 
                      new Truck() 
                  })
        {
            
        }
    }
}
