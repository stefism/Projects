using MXGP.Core.Contracts;
using MXGP.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MXGP.Models.Races.Contracts;
using MXGP.IO.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Models.Riders;
using MXGP.Utilities.Messages;
using MXGP.Repositories.Contracts;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IMotorcycle> motorcycleRepository;
        private readonly IRepository<IRace> raceRepository;
        private readonly IRepository<IRider> riderRepository;

        public ChampionshipController()
        {
            motorcycleRepository = new MotorcycleRepository();
            raceRepository = new RaceRepository();
            riderRepository = new RiderRepository();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var ridersInRace = race.Riders;
            
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var orderedRiders = ridersInRace.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToList();
            // TO LIST Е ФАТКАТА !!!! За да можеш да ги взимаш по индекс!

            //var firstRider = orderedRiders.First();
            //IRider secondRider = (IRider)orderedRiders.Skip(1).SkipLast(1);
            //var thirdRider = orderedRiders.Last();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rider {orderedRiders[0]} wins {raceName} race.")
                .AppendLine($"Rider {orderedRiders[1]} is second in {race.Name} race.")
                .AppendLine($"Rider {orderedRiders[2]} is third in {race.Name} race.");

            raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }

        public string AddRiderToRace(string riceName, string riderName)
        {
            IRace race = raceRepository.GetByName(riceName);
            IRider rider = riderRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {riceName} could not be found.");
            }

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {riderName} added in {riceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = motorcycleRepository.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created");
            }

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            motorcycleRepository.Add(motorcycle);

            return $"{motorcycle.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);

            raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string CreateRider(string ridesName)
        {
            IRider rider = new Rider(ridesName);
            IRider tempName = riderRepository.GetByName(ridesName);

            if (tempName != null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.RiderIsAlreadyCreated, ridesName));
            }

            riderRepository.Add(rider);

            return $"Rider {ridesName} is created.";
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = riderRepository.GetByName(riderName);
            IMotorcycle motorCycle = motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if (motorCycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorCycle);

            return $"Rider {riderName} received motorcycle {motorcycleModel}";
        }
    }
}
