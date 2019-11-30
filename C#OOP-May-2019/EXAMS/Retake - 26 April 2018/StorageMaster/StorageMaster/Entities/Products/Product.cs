using StorageMaster.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    public abstract class Product : IProduct
    {
        private double price;
        public double Price
        {
            get => price;
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Error: Price cannot be negative!");
                }

                price = value;
            }
        }

        protected Product(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        public double  Weight { get; private set; }
    }
}
