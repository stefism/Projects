using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
        }
        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => decorations.Select(d => d.Comfort).Sum();

        public ICollection<IDecoration> Decorations
            => decorations.AsReadOnly();

        public ICollection<IFish> Fish
            => fishes.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            //string fishType = fish.GetType().Name;
            //string aquariumType = this.GetType().Name;

            if (fishes.Count >= this.Capacity)
            {
                throw new InvalidOperationException(OutputMessages.NotEnoughCapacity);
            }

            //if (aquariumType == "FreshwaterAquarium" && fishType == "SaltwaterFish")
            //{
            //    throw new InvalidOperationException(OutputMessages.NotEnoughCapacity);
            //}

            //if (aquariumType == "SaltwaterAquarium" && fishType == "FreshwaterFish")
            //{
            //    throw new InvalidOperationException(OutputMessages.NotEnoughCapacity);
            //}

            fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string aquariumType = this.GetType().Name;

            string fishesResult = fishes.Count() == 0 
                ? "None" : string.Join(", ", fishes);

            sb.AppendLine($"{this.Name} ({aquariumType}):")
                .AppendLine($"Fish: {fishesResult}".TrimEnd())
                .AppendLine($"Decorations: {decorations.Count()}")
                .AppendLine($"Comfort: {Comfort}".TrimEnd());

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        => fishes.Remove(fish);
    }
}
