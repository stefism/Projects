using Suls.Data;
using Suls.ViewModels.Submissions;
using System;
using System.Linq;

namespace Suls.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext db;

        public SubmissionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateSubmission(string ProblemId, string code, string userId, ushort achievedResult)
        {
            var submission = new Submission
            {
                Code = code,
                ProblemId = ProblemId,
                UserId = userId,
                CreatedOn = DateTime.UtcNow,
                AchievedResult = achievedResult
            };

            db.Submissions.Add(submission);
            db.SaveChanges();
        }

        public Problem GetProblemById(string id)
        {
            return db.Problems.FirstOrDefault(p => p.Id == id);
        }
    }
}
