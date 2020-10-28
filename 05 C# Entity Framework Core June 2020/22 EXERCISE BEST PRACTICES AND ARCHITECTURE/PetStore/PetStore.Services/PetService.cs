using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enums;
using PetStore.Services.Contracts;
using PetStore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Services
{
    public class PetService : IPetService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public PetService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddPet(PetViewModel petToAdd)
        {
            Pet pet = mapper.Map<Pet>(petToAdd);

            var client = dbContext.Clients.FirstOrDefault(c => c.Id == petToAdd.ClientId);

            if (client == null)
            {
                throw new InvalidOperationException("Client with this Id is not exist. Please add client first.");
            }

            var bread = dbContext.Breeds.FirstOrDefault(b => b.Name == petToAdd.Breed);

            if (bread == null)
            {
                bread = new Breed { Name = petToAdd.Breed };
            }

            pet.Breed = bread;

            dbContext.Pets.Add(pet);
            dbContext.SaveChanges();
        }

        public ICollection<PetViewModel> GetAllPets()
        {
            var allPets = dbContext.Pets
                .ProjectTo<PetViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return allPets;
        }
    }
}
