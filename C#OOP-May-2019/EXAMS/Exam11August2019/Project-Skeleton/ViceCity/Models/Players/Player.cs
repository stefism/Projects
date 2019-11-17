using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Common;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int livePoints;

        public Player(string name, int lifePoints)
        {
            Name = name;
            LifePoints = lifePoints;
            GunRepository = new GunRepository();
        }

        public string Name 
        {
            get => name;
            private set 
            {
                Validator.ThrowIfStringIsNullOrWhitespace
                    (value, ExceptionMessages.InvalidPlayerName);

                name = value;
            }
        }

        public bool IsAlive => livePoints <= 0;

        public IRepository<IGun> GunRepository { get; private set; }

        public int LifePoints
        {
            get => livePoints;

            protected set
            {
                Validator.ThrowsIfIntBelowZero
                    (value, ExceptionMessages.PlayerLivePointsBelowZero);

                livePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            LifePoints = Math.Max(LifePoints-points, 0);
        }
    }
}
