using SpaceStation.Factories.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace SpaceStation.Factories
{
    public class AstronautFactory : IAstronautFactory
    {
        public IAstronaut CreateAstronaut(string type, string astronautName)
        {
            Type astronautType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(a => a?.Name == type);

            if (astronautType == null)
            {
                return null;
            }

            IAstronaut astronaut = (IAstronaut)Activator
                .CreateInstance(astronautType, astronautName);

            return astronaut;
        }
    }
}
