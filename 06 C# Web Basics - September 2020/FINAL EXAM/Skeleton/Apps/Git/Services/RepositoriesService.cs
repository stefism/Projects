using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreareRepository(string name, string repositoryType, string ownerId)
        {
            var repository = new Repository
            {
                Name = name,
                OwnerId = ownerId,
                CreatedOn = DateTime.UtcNow
            };

            if (repositoryType == "Public")
            {
                repository.IsPublic = true;
            }
            else
            {
                repository.IsPublic = false;
            }

            db.Repositories.Add(repository);
            db.SaveChanges();

            return repository.Id;
        }

        public ICollection<ShowAllViewModel> ShowAllPepositories(string userId, bool isUserSignedIn)
        {
            var repositories = db.Repositories
                .Select(r => new ShowAllViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    OwnerId = r.OwnerId,
                    IsPublic = r.IsPublic,
                    CreatedOn = r.CreatedOn.ToString(),
                    CommitsCount = r.Commits.Count()
                }).ToList();

            if (!isUserSignedIn)
            {
                return repositories
                    .Where(r => r.IsPublic == true).ToList();
            }

            return repositories
                    .Where(r => r.IsPublic == true || r.OwnerId == userId).ToList();
        }
    }
}
