using AnimalCentre.Core.Contracts;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, 
            int happiness, int procedureTime)
        {
            List<Type> animalTypes = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(Animal)).ToList();

            Type currentAnimalType = animalTypes.First(t => t.Name == type);

            return (IAnimal)Activator.CreateInstance(currentAnimalType, name, energy, happiness, procedureTime);
        }
    }
}
