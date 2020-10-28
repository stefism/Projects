using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Common;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int removedHappiness = 5;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            Validator.ValidateAnimalProcedureTime(animal, procedureTime);

            animal.Happiness -= removedHappiness;
            animal.IsChipped = true;

            animal.ProcedureTime -= procedureTime;

            ProcedureHistory.Add(animal);
        }
    }
}
