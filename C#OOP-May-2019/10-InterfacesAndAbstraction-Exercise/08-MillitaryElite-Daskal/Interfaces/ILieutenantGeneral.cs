using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MillitaryElite_Daskal
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);
        
    }
}
