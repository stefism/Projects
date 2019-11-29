using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Repositories.Contracts
{
    public interface ICivilPlayerRepository<T>
    {
        IReadOnlyCollection<T> CivilPlayers { get; }

        void Add(IPlayer player);
    }
}
