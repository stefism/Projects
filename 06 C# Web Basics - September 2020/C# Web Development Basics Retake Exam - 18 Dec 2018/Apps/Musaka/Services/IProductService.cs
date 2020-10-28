using Musaka.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musaka.Services
{
    public interface IProductService
    {
        void CreateProduct(CreateProductInputModel inputModel);

        ICollection<AllProductsViewModel> ShowAllProducts();

        void AddOrder(long barcode, int quantity, string userId);

        ProductWithSumViewModel ShowOrders(string userId);
    }
}
