using PetStore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Contracts
{
    public interface IProductService
    {
        void AddProduct(AddProductViewModel product);

        ListAllProductsViewModel GetById(string id);

        ICollection<ListAllProductByTypeViewModel> ListAllByProductType(string type);

        ICollection<ListAllProductsViewModel> GetAllProducts();

        ICollection<ListAllProductsViewModel> SearchByName(string name);

        string RemoveProductByName(string name);
    }
}
