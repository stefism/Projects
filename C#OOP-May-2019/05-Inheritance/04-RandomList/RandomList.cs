using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList: List<string>
    {
        private Random rnd; //TODO: Add constructor

        public RandomList()
        {
            rnd = new Random();
        }

        public string RandomString()
        {
            int index = rnd.Next(0, this.Count);

            string str = this[index];

            this.RemoveAt(index);

            return str;
        }
    }
    //public class RandomList<T> : List<T>
    //{
    //    public T RandomString()
    //    {
    //        Random random = new Random();

    //        int index = random.Next(0, Count);

    //        T element = this[index];

    //        RemoveAt(index);

    //        return element;
    //    }
    //}
}
