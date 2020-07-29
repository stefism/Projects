using AutoMapper;
using PetStore.Models;
using PetStore.Services.ViewModels;

namespace PetStore.Mapping
{
    public class PetStoreProfile : Profile
    {
        public PetStoreProfile()
        {
            //Products
            CreateMap<AddProductViewModel, Product>();

            CreateMap<Product, ListAllProductByTypeViewModel>();

            CreateMap<Product, ListAllProductsViewModel>()
                .ForMember(
                vm => vm.ProductType,
                opt => opt.MapFrom(p => p.ProductType.ToString()));

            //Pets
            CreateMap<PetViewModel, Pet>()
                .ForMember(
                pet => pet.Breed,
                vm => vm.MapFrom(p => p.Breed.ToString()))
                .ReverseMap();

            //Clients
            CreateMap<AddClientViewModel, Client>();

            CreateMap<Client, GetAllClientViewModel>();
        }
    }
}
