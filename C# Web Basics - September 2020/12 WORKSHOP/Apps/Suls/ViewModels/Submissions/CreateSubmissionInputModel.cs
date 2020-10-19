using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Submissions
{
    public class CreateSubmissionInputModel
    {
        public string Code { get; set; }

        public ushort AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }

        public string UserId { get; set; }
    }
}
