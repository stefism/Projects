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

        private Dictionary<string, int> productInCurrentStorage;

        public StorageMaster()
        {
            storages = new List<IStorage>();
            productPool = new List<IProduct>();

            productFactory = new ProductFactory();
            storageFactory = new StorageFactory();

            productInCurrentStorage = new Dictionary<string, int>();
        }

        public string AddProduct(string type, double price)
        {
            IProduct product = productFactory.CreateProduct(type, price);

            productPool.Add(product);

            return $"Added {type} to pool";
        }

        public string GetStorageStatus(string storageName)
        {
            IStorage storage = storages.FirstOrDefault(s => s.Name == storageName);

            foreach (var product in storage.Products)
            {
                if (!productInCurrentStorage.ContainsKey(product.GetType().Name))
                {
                    productInCurrentStorage[product.GetType().Name] = 0;
                }

                productInCurrentStorage[product.GetType().Name]++;
            }

            StringBuilder sb = new StringBuilder();

            double totalProductWeight = storage.Products.Select(x => x.Weight).Sum();
            int storageCapacity = storage.Capacity;

            productInCurrentStorage = productInCurrentStorage
                .OrderByDescending(p => p.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            sb.Append($"Stock ({totalProductWeight}/{storageCapacity}): [");

            foreach (var currProduct in productInCurrentStorage)
            {
                sb.Append($"{currProduct.Key} ({currProduct.Value}), ");
            }

            sb.Remove(sb.Length-2, 2);
            sb.AppendLine("]");

            sb.Append("Garage: [");

            foreach (var vehicle in storage.Garage)
            {
                string result = vehicle.Value != null
                    ? $"{vehicle.Value.GetType().Name}"
                    : "empty";

                sb.Append($"{result}|");
            }

            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine("]");

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var storage in storages.OrderByDescending(s => s.Products.Select(p => p.Price).Sum()))
            {
                sb.AppendLine($"{storage.Name}:");

                double storageSum = storage.Products.Select(p => p.Price).Sum();
                sb.AppendLine($"Storage worth: ${storageSum:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        { 
            IProduct product = null;

            foreach (var currentProduct in productNames)
            {
                product = productPool
                    .FirstOrDefault(p => p.GetType().Name == currentProduct);

                if (product == null)
                {
                    throw new InvalidOperationException($"Error: {currentProduct} is out of stock!");
                }
            }

            int loadedProductCount = 0;

            foreach (var currentProduct in productNames)
            {
                product = productPool.Last(p => p.GetType().Name == currentProduct);

                double freeVehicleCapacity = currentVehicle.Capacity;
                
                if (freeVehicleCapacity >= product.Weight)
                {
                    currentVehicle.LoadProduct((Product)product);
                    productPool.Remove(product);
                    loadedProductCount++;
                    freeVehicleCapacity -= product.Weight;
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
                throw new InvalidOperationException("Error: Invalid source storage!");
            }

            if (!storages.Any(s => s.Name == destinationName))
            {
                throw new InvalidOperationException("Error: Invalid destination storage!");
            }

            IStorage sourceStorage = storages.First(s => s.Name == sourceName);
            Storage destinationStorage = (Storage)storages.First(s => s.Name == destinationName);

            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            string vehicleType = vehicle.GetType().Name;

            int destinationSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicleType} to {destinationName} (slot {destinationSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            IStorage storage = storages.First(s => s.Name == storageName);

            var vehicle = storage.Garage[garageSlot];
            int initialVehicleTrunkCount = vehicle.Trunk.Count;

            int unloadedProducts = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProducts}/{initialVehicleTrunkCount} products at {storageName}";
        }
    }
}
