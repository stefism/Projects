using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateCommit(string repositoryId, string userId, string description)
        {
            var commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = repositoryId
            };

            db.Commits.Add(commit);
            db.SaveChanges();
        }

        public void DeleteCommit(string id)
        {
            var commit = db.Commits.FirstOrDefault(c => c.Id == id);

            db.Commits.Remove(commit);
            db.SaveChanges();
        }

        public string GetRepositoryName(string id)
        {
            var name = db.Repositories.Where(r => r.Id == id)
                .Select(r => r.Name)
                .FirstOrDefault();

            return name;
        }

        public ICollection<ShowAllCommitsViewModel> ShowAllCommits()
        {
            var commits = db.Commits
                .Select(c => new ShowAllCommitsViewModel
                {
                    CommitId = c.Id,
                    RepositoryName = c.Repository.Name,
                    CommitDescription = c.Description,
                    CommitCreatedOn = c.CreatedOn.ToString()
                }).ToList();

            return commits;
        }
    }
}
