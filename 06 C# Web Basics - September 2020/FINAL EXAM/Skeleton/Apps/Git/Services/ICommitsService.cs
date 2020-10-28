using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        void CreateCommit(string repositoryId, string userId, string description);

        void DeleteCommit(string id);

        ICollection<ShowAllCommitsViewModel> ShowAllCommits();

        string GetRepositoryName(string id);
    }
}
