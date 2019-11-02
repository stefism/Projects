using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    public interface ISorterStrategy<T>
    {
        IEnumerable<T> Sort(IEnumerable<T> collection);
    }
}
