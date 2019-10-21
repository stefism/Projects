using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public interface ISoldier
    {
        long Id { get; }
        string FirstName { get; }
        string LastName { get; }
        decimal Salary { get; }
    }
}
