using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Entities
{
    public class Hotel : IHotel
    {
        public int Capacity => 10;

        public IDictionary<string, IAnimal> Animals { get; private set; }

        public Hotel()
        {
            Animals = new Dictionary<string, IAnimal>();
        }

        public void Accommodate(IAnimal animal)
        {
            if (Capacity == 0)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            Animals[animal.Name] = animal;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            Animals[animalName].Owner = owner;
            Animals[animalName].IsAdopt = true;
            Animals.Remove(animalName);
        }
    }
}
