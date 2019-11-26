using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Common;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            Validator.ValidateAnimalProcedureTime(animal, procedureTime);

            animal.Happiness -= 3;
            animal.Energy += 10;

            animal.ProcedureTime -= procedureTime;
        }
    }
}
