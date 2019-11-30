using StorageMaster.Entities.Contracts;
using StorageMaster.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace StorageMaster.Factories
{
    public class ProductFactory : IProductFactory
    {
        public IProduct CreateProduct(string type, double price)
        {
            Type productType = Assembly.GetCallingAssembly()
                .GetTypes().FirstOrDefault(p => p.Name == type);

            if (productType == null)
            {
                throw new InvalidOperationException("Error: Invalid product type!");
            }

            return (IProduct)Activator.CreateInstance(productType, price);
        }
    }
}
