using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class DistributionCenter : Storage
    {
        private const int DefaultCapacity = 2;
        private const int DefaultGarageSlots = 5;
        public DistributionCenter(string name) 
            : base(name, DefaultCapacity, DefaultGarageSlots,
                  new List<Vehicle>
                  {
                      new Van(),
                      new Van(),
                      new Van()
                  })
        {

        }
    }
}
