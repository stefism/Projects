using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Factories.Contracts
{
    public interface IGunFactory
    {
        IGun CreateGun(string type, string name);
    }
}
