using System;

using _05_FootballTeam_Daskal.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace _05_FootballTeam_Daskal
{
    public class Stat
    {
        private const int MIN_STAT_VALUE = 0;
        private const int MAX_STAT_VALUE = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;

            private set
            {
                ValidateStat(value, nameof(Endurance));

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;

            private set
            {
                ValidateStat(value, nameof(Sprint));

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;

            private set
            {
                ValidateStat(value, nameof(Dribble));

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;

            private set
            {
                ValidateStat(value, nameof(Passing));

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;

            private set
            {
                ValidateStat(value, nameof(Shooting));

                shooting = value;
            }
        }

        public double OverallStat => (Endurance + Sprint
            + Dribble + Passing + Shooting) / 5.0;

        private void ValidateStat(int value, string name)
        {
            if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages
                    .InvalidStatException, name, MIN_STAT_VALUE, MAX_STAT_VALUE));
            }
        }
    }
}
