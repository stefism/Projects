using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private readonly List<IProduct> trunk;

        public Vehicle(int capacity)
        {
            Capacity = capacity;
            trunk = new List<IProduct>();
        }
        public int Capacity { get; private set; }

        public IReadOnlyCollection<IProduct> Trunk
            => trunk.AsReadOnly();

        public bool IsFull => trunk.Select(p => p.Weight).Sum() >= Capacity;

        public bool IsEmpty => trunk.Count == 0;

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Error: Vehicle is full!");
            }

            trunk.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Error: No products left in vehicle!");
            }

            IProduct product = trunk.Last();
            trunk.Remove(product); //TODO Тука може да върне нул!

            return (Product)product;
        }
    }
}
