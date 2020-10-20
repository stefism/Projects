using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Problems
{
    public class SubmissionViewModel //Lector
    {
        public string Username { get; set; }

        public ushort AchievedResult { get; set; }

        public ushort MaxPoints { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SubmissionId { get; set; }
    }
}
