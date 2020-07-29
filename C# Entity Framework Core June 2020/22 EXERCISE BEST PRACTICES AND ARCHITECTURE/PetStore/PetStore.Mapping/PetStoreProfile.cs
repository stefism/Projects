using AutoMapper;
using PetStore.Models;
using PetStore.Services.ViewModels;

namespace PetStore.Mapping
{
    public class PetStoreProfile : Profile
    {
        public PetStoreProfile()
        {
            CreateMap<AddProductViewModel, Product>();

            CreateMap<Product, ListAllProductByTypeViewModel>();

            CreateMap<Product, ListAllProductsViewModel>()
                .ForMember(
                vm => vm.ProductType,
                opt => opt.MapFrom(p => p.ProductType.ToString()));
        }
    }
}
