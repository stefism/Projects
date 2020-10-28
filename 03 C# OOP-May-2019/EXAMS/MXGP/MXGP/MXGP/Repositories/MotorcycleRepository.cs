using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            motorcycles = new List<IMotorcycle>();
        } 
        public void Add(IMotorcycle model)
        {
            motorcycles.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return motorcycles.ToList();
        }

        public IMotorcycle GetByName(string name)
        {
            IMotorcycle motorcycle = motorcycles.FirstOrDefault(m => m.Model == name);

            return motorcycle;
        }

        public bool Remove(IMotorcycle model)
        {
            bool isRemove = motorcycles.Remove(model);

            return isRemove;
        }
    }
}
