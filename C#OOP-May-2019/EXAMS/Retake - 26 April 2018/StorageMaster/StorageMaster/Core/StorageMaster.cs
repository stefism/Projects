using StorageMaster.Core.Contracts;
using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Storages;
using StorageMaster.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using StorageMaster.Entities.Products;
using StorageMaster.Factories;

namespace StorageMaster.Core
{
    public class StorageMaster : IStorageMaster
    {
        private IList<IStorage> storages;
        private IList<IProduct> productPool;

        private IProductFactory productFactory;
        private IStorageFactory storageFactory;

        private IVehicle currentVehicle;

        public StorageMaster()
        {
            storages = new List<IStorage>();
            productPool = new List<IProduct>();

            productFactory = new ProductFactory();
            storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            IProduct product = productFactory.CreateProduct(type, price);

            productPool.Add(product);

            return $"Added {type} to pool";
        }

        public string GetStorageStatus(string storageName)
        {
            throw new NotImplementedException();
        }

        public string GetSummary()
        {
            throw new NotImplementedException();
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        { //TODO Евентуално да промениме този метод. Не съм сигурен как работи правилно.
            IProduct product = null;

            foreach (var currentProduct in productNames)
            {
                product = productPool
                    .FirstOrDefault(p => p.GetType().Name == currentProduct);

                if (product == null)
                {
                    throw new InvalidOperationException($"{productNames} is out of stock!");
                }
            }

            int loadedProductCount = 0;

            foreach (var currentProduct in productNames)
            {
                product = productPool.Last(p => p.GetType().Name == currentProduct);
                
                if (currentVehicle.Capacity >= product.Weight)
                {
                    currentVehicle.LoadProduct((Product)product);
                    productPool.Remove(product);
                }
            }

            return $"Loaded {loadedProductCount}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string RegisterStorage(string type, string name)
        {
            IStorage storage = storageFactory.CreateStorage(type, name);

            storages.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            IStorage storage = storages.FirstOrDefault(s => s.Name == storageName);

            currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName,
            int sourceGarageSlot, string destinationName)
        {
            if (!storages.Any(s => s.Name == sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!storages.Any(s => s.Name == destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            IStorage sourceStorage = storages.First(s => s.Name == sourceName);
            Storage destinationStorage = (Storage)storages.First(s => s.Name == destinationName);

            var vehicle = sourceStorage.Garage[sourceGarageSlot];
            string vehicleType = vehicle.GetType().Name;

            int destinationSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicleType} to {destinationName} (slot {destinationSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            IStorage storage = storages.First(s => s.Name == storageName);

            var vehicle = storage.Garage[garageSlot];

            int unloadedProducts = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProducts}/{vehicle.Trunk.Count} products at {storageName}";
        }
    }
}
