using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    public class SelectionSorter<T> : ISorterStrategy<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            Console.WriteLine("Selection sorter");

            return collection;
        }
    }
}
