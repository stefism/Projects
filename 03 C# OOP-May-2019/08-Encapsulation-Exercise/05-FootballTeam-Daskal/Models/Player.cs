using System;

using _05_FootballTeam_Daskal.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace _05_FootballTeam_Daskal.Models
{
    public class Player
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.EmptyNameException);
                }

                name = value;
            }
        }

        public Player(string name, Stat stat)
        {
            Name = name;
            Stat = stat;
        }

        public double OverallSkill => Stat.OverallStat;

        public Stat Stat { get; private set; }
    }
}
