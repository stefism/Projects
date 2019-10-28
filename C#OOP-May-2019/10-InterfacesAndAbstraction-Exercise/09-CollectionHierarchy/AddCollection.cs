using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy
{
    public class AddCollection : IAddable
    {
        public int Index { get; private set; }

        public List<string> Collection { get; private set; }

        public virtual int Add(string item)
        {
            throw new NotImplementedException();
        }
    }
}
