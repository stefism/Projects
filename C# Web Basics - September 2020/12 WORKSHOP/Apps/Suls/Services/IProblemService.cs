using Suls.Data;
using Suls.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface IProblemService
    {
        void CreateProblem(string name, ushort points);

        IEnumerable<HomePageProblemViewModel> ListAllProblemsOnHomePage();       
    }
}
