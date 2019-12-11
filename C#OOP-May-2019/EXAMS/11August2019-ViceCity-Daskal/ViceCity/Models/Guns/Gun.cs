using System;
using System.Collections.Generic;
using System.Text;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
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
                    throw new ArgumentException("Bullets cannot be below zero!");
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
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }

                totalBullets = value;
            }
        }

        public bool CanFire => BulletsPerBarrel > 0 || TotalBullets > 0;

        public abstract int Fire();

        protected void Reload (int bullets)
        {
            if (TotalBullets >= bullets)
            {
                BulletsPerBarrel = bullets;
                TotalBullets -= bullets;
            }
        }

        protected int DecreaseBullets(int bullets)
        {
            int firedBullets = 0;

            if (BulletsPerBarrel - bullets >= 0)
            {
                BulletsPerBarrel -= bullets;
                firedBullets = bullets;
            }

            return firedBullets;
        }
    }
}
