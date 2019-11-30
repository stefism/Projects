using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Contracts
{
    public interface IVehicle
    {
        int Capacity { get; }
        IReadOnlyCollection<IProduct> Trunk { get; }
        bool IsFull { get;  } 
        bool IsEmpty { get;  }
        void LoadProduct(Product product);
        Product Unload();
    }
}
