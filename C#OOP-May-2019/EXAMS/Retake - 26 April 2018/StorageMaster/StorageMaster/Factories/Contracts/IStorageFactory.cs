using StorageMaster.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories.Contracts
{
    public interface IStorageFactory
    {
        IStorage CreateStorage(string type, string name);
    }
}
