﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    public class HardDrive : Product
    {
        private const double DefaultWeight = 1;
        public HardDrive(double price) 
            : base(price, DefaultWeight)
        {
        }
    }
}
