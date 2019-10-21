using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public interface IEngineer
    {
        List<Repair> Repairs { get; }
        string Corps { get; }
    }
}
