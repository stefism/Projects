using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;



namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        public IDictionary<string, IList<IAnimal>> ProcedureHistory { get; protected set; }

        public abstract void DoService(IAnimal animal, int procedureTime);
        
        public string History()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var procedure in ProcedureHistory)
            {
                sb.AppendLine(procedure.Key);

                foreach (var animal in procedure.Value)
                {
                    sb.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
