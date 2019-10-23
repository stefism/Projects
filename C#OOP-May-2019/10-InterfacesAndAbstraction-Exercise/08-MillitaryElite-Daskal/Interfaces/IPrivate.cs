using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MillitaryElite_Daskal
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
