using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
           Type playerType = Assembly.GetCallingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name == type);

            IPlayer player = (IPlayer)Activator
                .CreateInstance(playerType, new CardRepository(), username);

            return player;
        }
    }
}
