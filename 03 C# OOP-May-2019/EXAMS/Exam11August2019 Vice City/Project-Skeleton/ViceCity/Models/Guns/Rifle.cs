﻿using System;
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
            if (BulletsPerBarrel > 0)
            {
                BulletsPerBarrel -= RifleShootBullets;

                return RifleShootBullets;
            }
            else
            {
                if (TotalBullets >= RifleBulletsPerBarrel)
                {
                    BulletsPerBarrel = RifleBulletsPerBarrel;
                    TotalBullets -= RifleBulletsPerBarrel;

                    BulletsPerBarrel -= RifleShootBullets;

                    return RifleShootBullets;
                }
            }

            return 0;
        }
    }
}
