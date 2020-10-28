using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class ShowAllViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string OwnerId { get; set; }

        public string CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        public int CommitsCount { get; set; }
    }
}
