using Suls.Data;
using Suls.ViewModels.Problems;
using System.Collections.Generic;
using System.Linq;

namespace Suls.Services
{
    public class ProblemService : IProblemService
    {
        //Ако не сработи някое проперти във формите, например Id, виж дали си го подал (взел) където трябва.
        private readonly ApplicationDbContext db;

        public ProblemService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, ushort points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            db.Problems.Add(problem);
            db.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> ListAllProblemsOnHomePage()
        {
            return db.Problems.Select(x => new HomePageProblemViewModel
            {
                Id = x.Id, // Гледай къде ще ти трябват ай дитата и не ги забравай. В случая това ще ти трябва нататъка по формите и като не е зето, другите форми няма да сработят! То се генерира, но ще ти трябва да го вземеш за следващите форми да работиш с него.
                Name = x.Name,
                Count = x.Submissions.Count()
            }).ToList();
        }

        public IEnumerable<ProblemDetailsViewModel> ProblemDetails(string id)
        {
            var problems = db.Submissions
                .Where(s => s.Problem.Id == id).Select(s => new ProblemDetailsViewModel
                {
                    Name = s.Problem.Name,
                    Username = s.User.Username,
                    MaxPoints = s.Problem.Points,
                    AchievedResult = s.AchievedResult,
                    CreatedOn = s.CreatedOn.ToString("dd/MM/yyyy"),
                    SubmissionId = s.Id
                }).ToList();

            if (problems.Count() == 0)
            {
                return new List<ProblemDetailsViewModel>
                {
                    new ProblemDetailsViewModel
                    {
                        Name = "---",
                        Username = "---",
                        MaxPoints = 0,
                        AchievedResult = 0,
                        CreatedOn = "---",
                        SubmissionId = "---"
                    }
                }.ToList();
            }

            return problems;
        }
    }
}
