namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;
    public interface IProcedure
    {
       IDictionary<string, IList<IAnimal>> ProcedureHistory { get; }
        string History();
        void DoService(IAnimal animal, int procedureTime);
    }
}
