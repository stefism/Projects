using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            ProcedureHistory = new List<IAnimal>();
        }
        protected ICollection<IAnimal> ProcedureHistory { get; }
        //public IDictionary<string, IList<IAnimal>> ProcedureHistory { get; protected set; }

        public abstract void DoService(IAnimal animal, int procedureTime);
        
        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GetType().Name);

            foreach (var animal in ProcedureHistory)
            {
                sb.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
