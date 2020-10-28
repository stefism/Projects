using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Immutable;

namespace AnimalCentre.Entities
{
    public class Hotel : IHotel
    {
        private const int capacity = 10;

        private readonly Dictionary<string, IAnimal> animals;
        public IReadOnlyDictionary<string, IAnimal> Animals 
            => animals.ToImmutableDictionary();

        public Hotel()
        {
            animals = new Dictionary<string, IAnimal>();
        }

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            animals[animal.Name] = animal;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            animals[animalName].Owner = owner;
            animals[animalName].IsAdopt = true;
            animals.Remove(animalName);
        }
    }
}
