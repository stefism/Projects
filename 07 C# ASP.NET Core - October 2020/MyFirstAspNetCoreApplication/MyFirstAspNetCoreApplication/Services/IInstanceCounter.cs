﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Services
{
    public interface IInstanceCounter
    {
        public int Instances { get; }
    }
}
