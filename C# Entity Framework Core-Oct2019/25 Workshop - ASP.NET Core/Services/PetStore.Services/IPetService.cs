namespace PetStore.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Data.Models;
    using PetStore.Services.Models.Pet;

    public interface IPetService
    {
        IEnumerable<PetListingServiceModel> All();

        void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId);

        void SellPet(int petId, int userId);

        bool Exists(int petId);
    }
}
