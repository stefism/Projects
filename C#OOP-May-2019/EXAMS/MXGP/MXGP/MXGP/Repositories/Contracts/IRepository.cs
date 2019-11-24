using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories.Contracts
{
    public interface IRepository<T>
    {
        T GetByName(string name);

        IReadOnlyCollection<T> GetAll();

        void Add(T model);

        bool Remove(T model);
    }
}
