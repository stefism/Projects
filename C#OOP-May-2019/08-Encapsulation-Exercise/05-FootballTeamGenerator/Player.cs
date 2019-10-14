using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            Name = name;
            this.stats = stats;
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
    }
}
