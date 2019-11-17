using ViceCity.Common;
using ViceCity.Models.Guns.Contracts;

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
                Validator.ThrowIfStringIsNullOrEmpty
                    (value, ExceptionMessages.InvalidGunName);

                name = value;
            }
        }

        public int BulletsPerBarrel 
        {
            get => bulletsPerBarrel;

            protected set
            {
                Validator.ThrowsIfIntBelowZero
                    (value, ExceptionMessages.BulletsCannotBelowZero);

                bulletsPerBarrel = value;
            }
        }

        public int TotalBullets 
        {
            get => totalBullets;

            protected set
            {
                Validator.ThrowsIfIntBelowZero
                    (value, ExceptionMessages.TotalBulletCannotBelowZero);

                totalBullets = value;
            }
        }

        public bool CanFire => TotalBullets == 0; // TotalBullets == 0

        public virtual int Fire()
        {
            return 0;
        }
    }
}
