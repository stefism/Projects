using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;

        public CommitsController(ICommitsService commitsService)
        {
            this.commitsService = commitsService;
        }

        public HttpResponse Create(string id)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string repositoryName = commitsService.GetRepositoryName(id);

            var model = new CreateCommitViewModel
            {
                Id = id,
                Name = repositoryName
            };


            return View(model);
        }

        [HttpPost("/Commits/Create")]
        public HttpResponse CreateCommit(string id, string description)
        {
            commitsService.CreateCommit(id, GetUserId(), description);

            return Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = commitsService.ShowAllCommits();

            return View(viewModel);
        }

        public HttpResponse Delete(string id)
        {
            commitsService.DeleteCommit(id);

            return Redirect("/Commits/All");
        }
    }
}
