using StorageMaster.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories.Contracts
{
    public interface IProductFactory
    {
        IProduct CreateProduct(string type, double price);
    }
}
