using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private List<IAquarium> aquariums;
        private DecorationRepository decorationRepository;

        public Controller()
        {
            aquariums = new List<IAquarium>();
            decorationRepository = new DecorationRepository();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium") //TODO ИЛИТА => ||
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium currAquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                currAquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                currAquarium = new SaltwaterAquarium(aquariumName);
            }

            aquariums.Add(currAquarium);

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant") //TODO ИЛИТА! => ||
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            IDecoration currDec = null;

            if (decorationType == "Ornament")
            {
                currDec = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                currDec = new Plant();
            }

            decorationRepository.Add(currDec);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            IAquarium currAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            IFish currFish = null;

            if (fishType == "FreshwaterFish")
            {
                currFish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                currFish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            string aquariumType = currAquarium.GetType().Name;

            if (aquariumType == "FreshwaterAquarium" && fishType == "SaltwaterFish")
            {
                return "Water not suitable.";
            }

            if (aquariumType == "SaltwaterAquarium" && fishType == "FreshwaterFish")
            {
                return "Water not suitable.";
            }

            currAquarium.AddFish(currFish);

            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium currAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal fishPrices = 0;
            decimal decorPrices = 0;

            foreach (var currFish in currAquarium.Fish)
            {
                fishPrices += currFish.Price;
            }

            foreach (var decor in currAquarium.Decorations)
            {
                decorPrices += decor.Price;
            }

            decimal totalPrice = fishPrices + decorPrices;

            return $"The value of Aquarium {aquariumName} is {totalPrice:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium currAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            int fishEatCount = 0;

            foreach (var currFish in currAquarium.Fish)
            {
                currFish.Eat();
                fishEatCount++;
            }

            return $"Fish fed: {fishEatCount}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration currDec = decorationRepository
                .Models.FirstOrDefault(d => d.GetType()
                .Name == decorationType);

            if (currDec == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            IAquarium currAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            currAquarium.AddDecoration(currDec);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currAquarium in aquariums)
            {
                sb.AppendLine(currAquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
