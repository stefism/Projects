using Suls.Services;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionService submissionService;

        public SubmissionsController(ISubmissionService submissionService)
        {
            this.submissionService = submissionService;
        }

        public HttpResponse Create(string id)
        {
            var problem = submissionService.GetProblemById(id);

            var viewModel = new ShowSubmissionViewModel
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return View(viewModel);
        }

        [HttpPost("/Submissions/Create")]
        public HttpResponse DoCreate(string ProblemId, string code)
        {
            var problem = submissionService.GetProblemById(ProblemId);
            var result = new Random().Next(0, problem.Points + 1);

            submissionService.CreateSubmission(ProblemId, code, GetUserId(), (ushort)result);
            
            return Redirect("/");
        }
    }
}
