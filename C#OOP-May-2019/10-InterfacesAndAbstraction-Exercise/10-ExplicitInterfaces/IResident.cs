using System;
using System.Collections.Generic;
using System.Text;

namespace _10_ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }
        string GetName(string mrs);
    }
}
