using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;
        public int Count => players.Count;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Players 
        {
            get 
            {
                return players.AsReadOnly();
            }
        }

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (players.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = players.FirstOrDefault(p => p.Username == username);

            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null"); // Е тука нещо с ретърна?
            }

            players.Remove(player);
            return true;
        }
    }
}
