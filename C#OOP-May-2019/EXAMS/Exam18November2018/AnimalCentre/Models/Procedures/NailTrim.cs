using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Common;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            Validator.ValidateAnimalProcedureTime(animal, procedureTime);

            animal.Happiness -= 7;

            animal.ProcedureTime -= procedureTime;
        }
    }
}
