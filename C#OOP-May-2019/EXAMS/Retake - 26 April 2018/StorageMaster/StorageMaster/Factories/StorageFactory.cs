using StorageMaster.Entities.Contracts;
using StorageMaster.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMaster.Factories
{
    public class StorageFactory : IStorageFactory
    {
        public IStorage CreateStorage(string type, string name)
        {
            Type storageType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(s => s.Name == type);

            if (storageType == null)
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            return (IStorage)Activator.CreateInstance(storageType, name);
        }
    }
}
