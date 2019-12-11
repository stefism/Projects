using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int DefaultBulletsPerBarrel = 50;
        private const int DefaultTotalBullets = 500;
        private const int BulletsPerFire = 5;
        public Rifle(string name) 
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
