using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class Warehouse : Storage
    {
        private const int DefaultCapacity = 10;
        private const int DefaultGarageSlots = 10;
        public Warehouse(string name) 
            : base(name, DefaultCapacity, DefaultGarageSlots,
                  new List<Vehicle>
                  {
                      new Semi(),
                      new Semi(),
                      new Semi()
                  })
        {
        }
    }
}
