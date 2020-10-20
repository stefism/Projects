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
        private readonly IProblemService problemService;

        public SubmissionsController(ISubmissionService submissionService, IProblemService problemService)
        {
            this.submissionService = submissionService;
            this.problemService = problemService;
        }

        public HttpResponse Delete(string id)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            submissionService.DeleteSubmissions(id);

            return Redirect("/");
        }

        public HttpResponse Create(string id)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            var viewModel = new ShowSubmissionViewModel
            {
                ProblemId = id,
                Name = problemService.GetNameById(id)
            };

            return View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return Error("Text code should be between 30 and 800 characters.");
            }

            submissionService.Create(problemId, GetUserId(), code);
            return Redirect("/");
        }



        //------------------------------------------- Me
        public HttpResponse Create1(string id)
        {
            var problem = submissionService.GetProblemById(id);

            var viewModel = new ShowSubmissionViewModel
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return View(viewModel);
        }

        //[HttpPost("/Submissions/Create")]
        public HttpResponse DoCreate1(string ProblemId, string code)
        {
            var problem = submissionService.GetProblemById(ProblemId);
            var result = new Random().Next(0, problem.Points + 1);

            submissionService.CreateSubmission(ProblemId, code, GetUserId(), (ushort)result);

            return Redirect("/");
        }
    }
}
