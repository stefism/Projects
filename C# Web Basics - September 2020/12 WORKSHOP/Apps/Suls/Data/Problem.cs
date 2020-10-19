using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data
{
    public class Problem
    {
        public Problem()
        {
            Id = Guid.NewGuid().ToString();
            Submissions = new HashSet<Submission>();
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public ushort Points { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
