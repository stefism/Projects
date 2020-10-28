using System;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, 
            int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        #region SetProp

        public int Endurance
        {
            get => endurance;

            private set
            {
                ValidateStatRange(value, "Endurance");
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;

            private set
            {
                ValidateStatRange(value, "Sprint");
                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;

            private set
            {
                ValidateStatRange(value, "Dribble");
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;

            private set
            {
                ValidateStatRange(value, "Passing");
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;

            private set
            {
                ValidateStatRange(value, "Shooting");
                shooting = value;
            }
        }

        #endregion

        public double CalculateStatsValue()
        {
            double value = (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

            return value;
        }

        private void ValidateStatRange(int value, string statName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }
    }
}
