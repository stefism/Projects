using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Common;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        private const int AddedHappiness = 12;
        private const int AddedEnergy = 10;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            Validator.ValidateAnimalProcedureTime(animal, procedureTime);

            animal.Happiness += AddedHappiness;
            animal.Energy += AddedEnergy;

            animal.ProcedureTime -= procedureTime;
        }
    }
}
