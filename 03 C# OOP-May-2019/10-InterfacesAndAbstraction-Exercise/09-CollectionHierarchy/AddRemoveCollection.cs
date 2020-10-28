using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy
{
    public class AddRemoveCollection : AddCollection
    {
        protected int Count = 0;

        public override int Add(string item)
        {
            Collection.Insert(Index, item);
            Count++;
            return Index;
        }

        public override string Remove()
        {
            string removed = Collection[Count-1];

            Collection.RemoveAt(Count-1);

            Count--;

            return removed;
        }
    }
}
