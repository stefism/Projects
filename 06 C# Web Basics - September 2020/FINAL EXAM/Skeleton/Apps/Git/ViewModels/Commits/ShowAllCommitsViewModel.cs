using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Commits
{
    public class ShowAllCommitsViewModel
    {
        public string CommitId { get; set; }

        public string RepositoryName { get; set; }

        public string CommitDescription { get; set; }

        public string CommitCreatedOn { get; set; }
    }
}
