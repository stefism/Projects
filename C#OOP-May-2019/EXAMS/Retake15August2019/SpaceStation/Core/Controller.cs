using SpaceStation.Core.Contracts;
using SpaceStation.Factories;
using SpaceStation.Factories.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronauts;
        private readonly IRepository<IPlanet> planets;

        private IAstronautFactory astronautFactory;
        private IMission mission;
        private int exploredPlanetCount;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            astronautFactory = new AstronautFactory();
            mission = new Mission();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = astronautFactory.CreateAstronaut(type, astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);

            return $"Successfully added {astronaut.GetType().Name}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            if (items.Length != 0)
            {
                items.ToList().ForEach(x => planet.Items.Add(x));
            }

            planets.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var suitableAstronauts = astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidAstronautCount);
            }

            var planetToExplore = planets.FindByName(planetName);

            mission.Explore(planetToExplore, suitableAstronauts);

            int deadAstronauts = astronauts.Models
                .Where(x => x.Oxygen <= 0).Count();

            exploredPlanetCount++;

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetCount} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);

            return $"Astronaut {astronautName} was retired!";
        }
    }
}
