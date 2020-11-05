using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.ViewModels.Home
{
    public class IndexViewModel
    {
        public int Year { get; set; }

        public int UsersCount { get; set; }

        public int ProcessorCount { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Descripton { get; set; }
    }
}
