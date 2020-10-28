using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MilitaryElite
{
    public interface ICommando
    {
        List<Mission> missions { get; }
        string Corps { get; }
    }
}
