using PetStore.Services.ViewModels;
using System.Collections.Generic;

namespace PetStore.Services.Contracts
{
    public interface IPetService
    {
        void AddPet(PetViewModel petToAdd);

        ICollection<PetViewModel> GetAllPets();
    }
}
