using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Suls.Data
{
    public class Submission
    {
        public Submission()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(800)]
        public string Code { get; set; }

        public ushort AchievedResult  { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }

        public virtual Problem Problem { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
