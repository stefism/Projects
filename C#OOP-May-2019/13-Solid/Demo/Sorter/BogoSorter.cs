using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    public class BogoSorter<T> : ISorterStrategy<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            Console.WriteLine("Bogo bogo");

            return collection;
        }
    }
}
