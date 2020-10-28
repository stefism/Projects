using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Problems
{
    public class ProblemDetailsViewModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public ushort AchievedResult { get; set; }

        public ushort MaxPoints { get; set; }

        public string CreatedOn { get; set; }

        public string SubmissionId { get; set; }

        public int Percentage =>
            (int)Math.Round(AchievedResult * 100.0m / MaxPoints);
    }
}
