using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int DefaultBulletsPerBarrel = 10;
        private const int DefaultTotalBullets = 100;
        private const int BulletsPerFire = 1;
        public Pistol(string name) 
            : base(name, DefaultBulletsPerBarrel, DefaultTotalBullets)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel < BulletsPerFire)
            {
                Reload(DefaultBulletsPerBarrel);
            }

            int firedBullets = DecreaseBullets(BulletsPerFire);

            return firedBullets;
        }
    }
}
