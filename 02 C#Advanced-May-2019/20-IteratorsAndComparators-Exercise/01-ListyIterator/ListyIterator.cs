using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;

        public void Create (params T[] param)
        {
            list = new List<T>(param);
        }

        public bool Move()
        {
            if (index < list.Count - 1)
            {
                index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (list.Count > 0)
            {
                Console.WriteLine(list[index]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public bool HasNext()
        {
            if (index < list.Count-1)
            {
                return true;
            }

            return false;
        }
    }
}
