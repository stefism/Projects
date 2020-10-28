using System;
using System.Collections.Generic;

namespace _08_MillitaryElite_Daskal
{
    public interface IEngineer : ISoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
