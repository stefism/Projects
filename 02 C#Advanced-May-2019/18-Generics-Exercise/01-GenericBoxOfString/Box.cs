using System;
using System.Collections.Generic;

namespace _01_GenericBoxOfString
{
    public class Box<T> where T : IComparable
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Swap(int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public int CountThatGreaterByValue(T value)
        {
            int count = 0;

            foreach (var item in list)
            {
                int isBigger = item.CompareTo(value);

                if (isBigger == 1)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            string output = string.Empty;

            var type = list[0].GetType();

            foreach (var item in list)
            {
               output += $"{type}: {item}{Environment.NewLine}";
            }

            return output;
        }
    }
}
