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
            IsAlive = true; // Другото.
            GunRepository = new GunRepository();
        }

        public string Name 
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        (ExceptionMessages.InvalidPlayerName);
                }

                name = value;
            }
        }

        //public bool IsAlive => livePoints > 0; // Мое.
        public bool IsAlive { get; private set; } // Другото.
        // Була се сетва в конструктора на true.

        public IRepository<IGun> GunRepository { get; private set; }

        public int LifePoints
        {
            get => livePoints;

            private set
            {
                if (LifePoints < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.PlayerLivePointsBelowZero);
                }

                livePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            // Разлика тука. IsAlive го дава на false ако LifePoints = 0.
            if (LifePoints - points <= 0)
            {
                LifePoints = 0;
                IsAlive = false;
            }
            else
            {
                LifePoints -= points;
            }

            //LifePoints = Math.Max(LifePoints-points, 0); // Моето.
        }
    }
}
