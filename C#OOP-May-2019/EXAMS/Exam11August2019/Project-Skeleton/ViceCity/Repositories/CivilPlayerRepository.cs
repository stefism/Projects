using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class CivilPlayerRepository : ICivilPlayerRepository<IPlayer>
    {
        private IList<IPlayer> civilPlayers;

        public CivilPlayerRepository()
        {
            civilPlayers = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> CivilPlayers 
            => (List<IPlayer>)civilPlayers;

        public void Add(IPlayer player)
        {
            civilPlayers.Add(player);
        }
    }
}
