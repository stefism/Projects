using _05_FootballTeam_Daskal.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_FootballTeam_Daskal.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            players = new List<Player>();
        }

        public Team(string name) : this()
        {
            Name = name;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }

                name = value;
            }
        }

        public int Rating 
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                return (int)(Math.Round(players.Average(x => x.OverallSkill), 0));
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = players.FirstOrDefault(x => x.Name == name);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException
                    (string.Format
                    (ExceptionMessages
                    .MissingPlayerException, 
                    name, Name));
            }

            players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
