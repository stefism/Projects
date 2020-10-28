using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Factories.Contracts;
using ViceCity.Models.Guns.Contracts;
using System.Reflection;
using System.Linq;
using ViceCity.Models.Guns;

namespace ViceCity.Factories
{
    public class GunFactory : IGunFactory
    {
        public IGun CreateGun(string type, string name)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }

            return gun;
        }
    }
}
