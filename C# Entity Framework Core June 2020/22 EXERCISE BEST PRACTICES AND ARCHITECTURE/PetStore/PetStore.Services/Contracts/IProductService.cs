using PetStore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Contracts
{
    public interface IProductService
    {
        void AddProduct(AddProductViewModel product);

        ICollection<ListAllProductByTypeViewModel> ListAllByProductType(string type);

        ICollection<ListAllProductsViewModel> GetAllProducts();

        string RemoveProductByName(string name);
    }
}
