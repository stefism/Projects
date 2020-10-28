using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {          
            var viewModel = repositoriesService.ShowAllPepositories(GetUserId(), IsUserSignedIn());            
            
            return View(viewModel);
        }

        public HttpResponse Create()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 10)
            {
                return Error("Invalid repository name. Name should be between 3 and 10 characters long.");
            }

            repositoriesService.CreareRepository(name, repositoryType, GetUserId());

            return Redirect("/Repositories/All");
        }
    }
}
