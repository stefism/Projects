using System;
using System.Collections.Generic;
using System.Text;

namespace _01_CustomListClass
{
    /// <summary>
    /// Integer List
    /// </summary>
    public class CustomList
    {
        /// <summary>
        /// Dafault size of internal Array
        /// </summary>
        private const int defaultSize = 2;

        /// <summary>
        /// Internal array
        /// </summary>
        private int[] innerArr;

        /// <summary>
        /// Number of element in the list
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Create custom integer list with default size
        /// </summary>
        public CustomList()
        {
            innerArr = new int[defaultSize];
        }

        /// <summary>
        /// Custom initial size of the list
        /// </summary>
        /// <param name="initialSize">Custom initial size</param>
        public CustomList(int initialSize)
        {
            innerArr = new int[initialSize];
        }

        /// <summary>
        /// Add element to list
        /// </summary>
        /// <param name="element">Add integer</param>
        public void Add(int element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        public void AddRange(int[] list)
        {
            if (list.Length + Count >= innerArr.Length)
            {
                if (list.Length + Count > innerArr.Length * 2)
                {
                    Grow(list.Length + Count);
                }
                else
                {
                    Grow();
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                innerArr[Count] = list[i];
                Count++;
            }
        }

        public void RemoveAt(int index)
        {

        }

        #region private

        private void Grow()
        {
            Grow(innerArr.Length * 2);
        }

        private void Grow(int newSize)
        {
            int[] tempArr = new int[newSize];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }

        #endregion
    }
}
