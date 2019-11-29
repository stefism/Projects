using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> listOfGuns;

        public GunRepository()
        {
            listOfGuns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models 
            => listOfGuns.AsReadOnly();

        public void Add(IGun model)
        {
            if (!listOfGuns.Contains(model))
            {
                listOfGuns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            IGun gun = listOfGuns.FirstOrDefault(g => g.Name == name);

            return gun;
        }

        public bool Remove(IGun model)
        {
            return listOfGuns.Remove(model);
        }
    }
}
