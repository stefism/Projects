using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter
{
    public class MergeSorter<T> : ISorterStrategy<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            Console.WriteLine("Merge sort");

            return collection;
        }
    }
}
