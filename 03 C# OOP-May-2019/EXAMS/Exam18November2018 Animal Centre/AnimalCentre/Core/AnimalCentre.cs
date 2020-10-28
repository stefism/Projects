using AnimalCentre.Core.Contracts;
using AnimalCentre.Entities;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre : IAnimalCentre
    {
        private IHotel hotel;
        private IProcedure procedure;
        private IAnimalFactory animalFactory;
        public AnimalCentre()
        {
            hotel = new Hotel();
            animalFactory = new AnimalFactory();
        }
        public string Adopt(string animalName, string owner)
        {
            ValidateIfAnimalExistInTheHotel(animalName);

            IAnimal animal = GetAnimalFromHotel(animalName);

            hotel.Adopt(animalName, owner);

            string adoptResult = animal.IsChipped
                ? $"{owner} adopted animal with chip"
                : $"{owner} adopted animal without chip";

            return adoptResult;
        }

        public string Chip(string name, int procedureTime)
        {
            ValidateIfAnimalExistInTheHotel(name);

            IAnimal animal = GetAnimalFromHotel(name);

            procedure = new Chip();
            procedure.DoService(animal, procedureTime);

            return $"{name} had chip procedure";
        }

        public string DentalCare(string name, int procedureTime)
        {
            ValidateIfAnimalExistInTheHotel(name);

            IAnimal animal = GetAnimalFromHotel(name);

            procedure = new DentalCare();
            procedure.DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            ValidateIfAnimalExistInTheHotel(name);

            IAnimal animal = GetAnimalFromHotel(name);

            procedure = new Fitness();
            procedure.DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string History(string type)
        {
            string procedureHistory = string.Empty;

            if (procedure != null)
            {
                procedureHistory = procedure.History();
            }

            return procedureHistory;
        }

        public string NailTrim(string name, int procedureTime)
        {
            ValidateIfAnimalExistInTheHotel(name);

            IAnimal animal = GetAnimalFromHotel(name);

            procedure = new NailTrim();
            procedure.DoService(animal, procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Play(string name, int procedureTime)
        {
            ValidateIfAnimalExistInTheHotel(name);

            IAnimal animal = GetAnimalFromHotel(name);

            procedure = new Play();
            procedure.DoService(animal, procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            if (hotel.Animals.Any(a => a.Key == name))
            {
                throw new ArgumentException($"Animal {name} already exist");
            }

            IAnimal animal = animalFactory.CreateAnimal(type, name, energy, 
                happiness, procedureTime);

            //switch (type)
            //{
            //    case "Cat":
            //        animal = new Cat(name, energy, happiness, procedureTime);
            //        break;

            //    case "Dog":
            //        animal = new Dog(name, energy, happiness, procedureTime);
            //        break;

            //    case "Lion":
            //        animal = new Lion(name, energy, happiness, procedureTime);
            //        break;

            //    case "Pig":
            //        animal = new Pig(name, energy, happiness, procedureTime);
            //        break;
            //}

            hotel.Accommodate(animal);
            return $"Animal {name} registered successfully";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            ValidateIfAnimalExistInTheHotel(name);

            IAnimal animal = GetAnimalFromHotel(name);

            procedure = new Vaccinate();
            procedure.DoService(animal, procedureTime);

            return $"{name} had vaccination procedure";
        }

        private IAnimal GetAnimalFromHotel(string name)
        {
            IAnimal animal = hotel.Animals.Values.First(a => a.Name == name);

            return animal;
        }
        private void ValidateIfAnimalExistInTheHotel(string name)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }
    }
}
