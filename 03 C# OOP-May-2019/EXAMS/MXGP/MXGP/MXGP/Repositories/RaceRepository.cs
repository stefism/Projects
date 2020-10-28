using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> races;

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        => races.ToList();

        public IRace GetByName(string name)
        => races.FirstOrDefault(r => r.Name == name);

        public bool Remove(IRace model)
        => races.Remove(model);
    }
}
