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
        IReadOnlyCollection<IVehicle> Garage { get; }
        IReadOnlyCollection<IProduct> Products { get; }
        Vehicle GetVehicle(int garageSlot);
        int SendVehicleTo(int garageSlot, Storage deliveryLocation); //TODO Евентуално IStorage
        int UnloadVehicle(int garageSlot);
    }
}
