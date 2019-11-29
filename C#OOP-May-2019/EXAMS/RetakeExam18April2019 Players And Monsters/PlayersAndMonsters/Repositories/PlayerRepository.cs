using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> playersByName;

        //private readonly List<IPlayer> players;
        public int Count => playersByName.Count;

        public PlayerRepository()
        {
            playersByName = new Dictionary<string, IPlayer>();
            //players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Players 
            => playersByName.Values.ToList();
        //{
        //    get 
        //    {
        //        return players.AsReadOnly();
        //    }
        //}

        public void Add(IPlayer player)
        {
            Validator.ThrowObjectCannotBeNull(player, ExceptionMessages
                .PlayerCannotBeNull);

            if (playersByName.ContainsKey(player.Username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages
                    .PlayerAllreadyExist, player.Username));
            }

            playersByName[player.Username] = player;
            //players.Add(player);
        }

        public IPlayer Find(string username)
        {
            //IPlayer player = players.FirstOrDefault(p => p.Username == username);
            //return player;

            IPlayer player = null;

            if (playersByName.ContainsKey(username))
            {
                player = playersByName[username];
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            Validator.ThrowObjectCannotBeNull(player, ExceptionMessages
                .PlayerCannotBeNull);

            bool hasRemoved = playersByName.Remove(player.Username);
            //players.Remove(player);
            return hasRemoved;
        }
    }
}
