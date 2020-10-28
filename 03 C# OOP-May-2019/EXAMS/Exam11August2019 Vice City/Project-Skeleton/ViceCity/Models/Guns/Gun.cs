using ViceCity.Common;
using ViceCity.Models.Guns.Contracts;
using System;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            Name = name;
            BulletsPerBarrel = bulletsPerBarrel;
            TotalBullets = totalBullets;
        }

        public string Name 
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidGunName);
                }

                name = value;
            }
        }

        public int BulletsPerBarrel 
        {
            get => bulletsPerBarrel;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.BulletsCannotBelowZero);
                }

                bulletsPerBarrel = value;
            }
        }

        public int TotalBullets 
        {
            get => totalBullets;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.TotalBulletCannotBelowZero);
                }

                totalBullets = value;
            }
        }

        //public bool CanFire => TotalBullets != 0; // Мое.
        public bool CanFire => BulletsPerBarrel > 0;
        // Тука е направено ако BulletsPerBarrel > 0, а не както при мене TotalBullets != 0.

        public abstract int Fire();
    }
}
