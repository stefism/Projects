﻿using Suls.Data;
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

        IEnumerable<ProblemDetailsViewModel> ProblemDetails(string id);

        string GetNameById(string id); //Lector sample

        public ProblemViewModel GetById(string id); //Lector sample
    }
}
