using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace Sorter
{
    public class Sorter<T>
    {
        public Sorter(string type)
        {
            ISorterStrategy<T> sorterStrategy = null;



            if (type == "merge")
            {
                sorterStrategy = new MergeSorter<T>();
            }
            else if (type == "selection")
            {
                sorterStrategy = new SelectionSorter<T>();
            }
            else if (type == "bogo")
            {
                sorterStrategy = new BogoSorter<T>();
            }

            sorterStrategy.Sort(new List<T>());
        }
    }
}
