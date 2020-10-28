using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre  
{  
    public class StartUp 
    {
        public static void Main(string[] args)
        {
            IAnimal animal = new Cat("Pena", 90, 90, 200);
        }
    }
}
