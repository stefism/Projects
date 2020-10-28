using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Common;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            Validator.ValidateAnimalProcedureTime(animal, procedureTime);

            animal.Energy -= 8;
            animal.IsVaccinated = true;

            animal.ProcedureTime -= procedureTime;

            ProcedureHistory.Add(animal);
        }
    }
}
