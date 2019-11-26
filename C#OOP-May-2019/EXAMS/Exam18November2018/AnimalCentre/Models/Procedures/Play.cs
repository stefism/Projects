using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Common;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            Validator.ValidateAnimalProcedureTime(animal, procedureTime);

            animal.Energy -= 6;
            animal.Happiness += 12;

            animal.ProcedureTime -= procedureTime;
        }
    }
}
