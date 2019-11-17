using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun, IGun
    {
        private const int RifleBulletsPerBarrel = 50;
        private const int RifleTotalBullets = 500;
        private const int RifleShootBullets = 5;
        public Rifle(string name) 
            : base(name, RifleBulletsPerBarrel, RifleTotalBullets)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel == 0 && TotalBullets >= BulletsPerBarrel)
            {
                BulletsPerBarrel = RifleBulletsPerBarrel;
                TotalBullets -= RifleBulletsPerBarrel;
            }

            BulletsPerBarrel -= RifleShootBullets;

            if (TotalBullets < BulletsPerBarrel)
            {
                TotalBullets = 0;
            }

            return RifleShootBullets;
        }
    }
}
