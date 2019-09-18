using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;

        public int Count => list.Count;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T element)
        {
            list.Add(element);
        }

        public T Remove()
        {
            var rem = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return rem;
        }
    }
}
