using System;
using System.Collections.Generic;
using System.Text;
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

        protected Player(string name, int lifePoints)
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        ("Player's name cannot be null or a whitespace!");
                }

                name = value;
            }
        }

        public bool IsAlive => LifePoints > 0;

        public IRepository<IGun> GunRepository { get; }

        public int LifePoints 
        {
            get => livePoints;

            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        ("Player life points cannot be below zero!");

                    // Внимавай много с грешките, които хвърляш! Като даде автоматично друга грешка и не я видиш и до там после! Много внимавай за грешките които се показват!
                }

                livePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            livePoints -= points;

            if (livePoints < 0)
            {
                livePoints = 0;
            }
        }
    }
}
