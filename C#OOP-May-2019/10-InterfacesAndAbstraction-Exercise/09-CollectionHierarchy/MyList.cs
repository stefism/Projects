using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy
{
    public class MyList : AddRemoveCollection
    {
        public int Used => Count;

        public override string Remove()
        {
            string removed = Collection[0];
            Collection.RemoveAt(0);
            Count--;

            return removed;
        }
    }
}
