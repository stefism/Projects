using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public int TeamCount => players.Count;

        public IReadOnlyCollection<Player> Players
        {
            get
            {
                return players.AsReadOnly();
            }
        }

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        public Player ReturnPlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);

            return player;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
