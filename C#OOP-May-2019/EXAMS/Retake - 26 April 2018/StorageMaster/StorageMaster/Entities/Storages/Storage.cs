using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Immutable;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage : IStorage
    {
        private Dictionary<int, IVehicle> vehicles;
        private readonly List<IProduct> products;

        public Storage(string name, int capacity, int garageSlots, 
            IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            
            InitalizeGarageWithSlotsAndVehicles(vehicles, garageSlots);
            products = new List<IProduct>();
        }
        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull => products.Select(p => p.Weight).Sum() >= Capacity;

        public IReadOnlyDictionary<int, IVehicle> Garage
            => vehicles.ToImmutableDictionary();

        public IReadOnlyCollection<IProduct> Products
            => products.AsReadOnly();

        public  Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException("Error: Invalid garage slot!");
            }

            if (vehicles[garageSlot] == null)
            {
                throw new InvalidOperationException("Error: No vehicle in this garage slot!");
            }

            return (Vehicle)vehicles[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation) 
        {
            IVehicle vehilcle = GetVehicle(garageSlot);

            if (deliveryLocation.Garage.Any(x => x.Value == null) == false) // TODO И това да се провери дали работи правилно
            {
                throw new InvalidOperationException("Error: No room in garage!");
            }

            vehicles[garageSlot] = null;

            int firstFreeGarageSlotInDeliveryLocation = deliveryLocation.Garage.First(x => x.Value == null).Key;

            deliveryLocation.vehicles[firstFreeGarageSlotInDeliveryLocation] = vehilcle;

            //deliveryLocation.UnloadVehicle(firstFreeGarageSlotInDeliveryLocation);

            return firstFreeGarageSlotInDeliveryLocation;
        }

        public int UnloadVehicle(int garageSlot) 
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Error: Storage is full!");
            }

            IVehicle vehilcle = GetVehicle(garageSlot);

            int productCount = 0;

            for (int i = 0; i < vehilcle.Trunk.Count; i++)
            {
                products.Add(vehilcle.Unload());
                productCount++;
                i--;
            }

            return productCount;
        }

        private void InitalizeGarageWithSlotsAndVehicles
            (IEnumerable<Vehicle> currVehicles, int garageSlots)
        {
            vehicles = new Dictionary<int, IVehicle>();

            for (int i = 0; i < garageSlots; i++)
            {
                if (i < currVehicles.Count())
                {
                    vehicles[i] = currVehicles.ToList()[i];
                }
                else
                {
                    vehicles[i] = null;
                }
            }
        }
    }
}
