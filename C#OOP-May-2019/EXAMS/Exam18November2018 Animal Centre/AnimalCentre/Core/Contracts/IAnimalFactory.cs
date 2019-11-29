﻿using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core.Contracts
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string type, string name, int energy, 
            int happiness, int procedureTime);
    }
}
