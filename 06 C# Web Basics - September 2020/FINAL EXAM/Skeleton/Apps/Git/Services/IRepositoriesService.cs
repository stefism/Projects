using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        string CreareRepository(string name, string repositoryType, string ownerId);

        ICollection<ShowAllViewModel> ShowAllPepositories(string userId, bool isUserSignedIn);
    }
}
