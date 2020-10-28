using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Factories.Contracts
{
    public interface IAstronautFactory
    {
        IAstronaut CreateAstronaut(string type, string astronautName);
    }
}
