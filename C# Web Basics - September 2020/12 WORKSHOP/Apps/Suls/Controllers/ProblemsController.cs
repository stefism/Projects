using Suls.Services;
using Suls.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;
using System.Linq;

namespace Suls.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        public HttpResponse Create()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Create(string name, ushort points)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 5 || name.Length > 20)
            {
                return Error("Name should be between 5 and 20 characters.");
            }

            if (points < 50 || points > 300)
            {
                return Error("Points should be between 50 and 300.");
            }

            problemService.CreateProblem(name, points);

            return Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            var problems = problemService.ProblemDetails(id);
                        
            return View(problems);
        }
    }
}
