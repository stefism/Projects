using SpaceStation.Factories.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using SpaceStation.Models.Astronauts;

namespace SpaceStation.Factories
{
    public class AstronautFactory : IAstronautFactory
    {
        public IAstronaut CreateAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }

            //Type astronautType = Assembly.GetCallingAssembly().GetTypes()
            //    .FirstOrDefault(a => a?.Name == type);

            //if (astronautType == null)
            //{
            //    return null;
            //}

            //IAstronaut astronaut = (IAstronaut)Activator
            //    .CreateInstance(astronautType, astronautName);

            return astronaut;
        }
    }
}
