using Suls.Data;
using Suls.ViewModels.Submissions;
using System;
using System.Linq;

namespace Suls.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code) //Lector
        {
            var problemMaxPoints = db.Problems.Where(x => x.Id == problemId).Select(x => x.Points).FirstOrDefault();

            var submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                AchievedResult = (ushort)random.Next(0, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow,
            };

            db.Submissions.Add(submission);
            db.SaveChanges();
        }

        public void CreateSubmission(string ProblemId, string code, string userId, ushort achievedResult) // Me
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

        public void DeleteSubmissions(string id)
        {
            var submission = db.Submissions.FirstOrDefault(s => s.Id == id);
            db.Submissions.Remove(submission);
            db.SaveChanges();
        }

        public Problem GetProblemById(string id)
        {
            return db.Problems.FirstOrDefault(p => p.Id == id);
        }
    }
}
