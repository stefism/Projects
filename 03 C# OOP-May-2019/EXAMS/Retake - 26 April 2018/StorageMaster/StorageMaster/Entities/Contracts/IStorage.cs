using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Contracts
{
    public interface IStorage
    {
        string Name { get; }
        int Capacity { get; }
        int GarageSlots { get; }
        bool IsFull { get; }
        IReadOnlyDictionary<int, IVehicle> Garage { get; }
        IReadOnlyCollection<IProduct> Products { get; }
        Vehicle GetVehicle(int garageSlot);
        int SendVehicleTo(int garageSlot, Storage deliveryLocation); 
        int UnloadVehicle(int garageSlot);
    }
}
