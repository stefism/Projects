using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage : IStorage
    {
        private readonly List<IVehicle> garage;

        public Storage(string name, int capacity, int garageSlots, 
            IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            garage = new List<IVehicle>(vehicles);
        }
        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull => throw new NotImplementedException();

        public IReadOnlyCollection<IVehicle> Garage
            => garage.AsReadOnly();

        public IReadOnlyCollection<IProduct> Products => throw new NotImplementedException();

        public Vehicle GetVehicle(int garageSlot)
        {
            throw new NotImplementedException();
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            throw new NotImplementedException();
        }

        public int UnloadVehicle(int garageSlot)
        {
            throw new NotImplementedException();
        }
    }
}
