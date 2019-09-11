using System;
using System.Collections.Generic;
using System.Text;

namespace CustomClass
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

        public int this[int index]
        {
            get
            {
                CheckIndexRange(index);
                return innerArr[index];
            }

            set
            {
                CheckIndexRange(index);
                innerArr[index] = value;
            }
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

        /// <summary>
        /// Add range of element to list
        /// </summary>
        /// <param name="list">Array of elements to add</param>
        public void AddRange(int[] list)
        {
            if (list.Length + Count >= innerArr.Length)
            {
                if (list.Length + Count > innerArr.Length * 2)
                {
                    Grow((list.Length + Count) * 2);
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

        /// <summary>
        /// Removes element at given position
        /// </summary>
        /// <param name="index">Position</param>
        /// <exception cref="IndexOutOfRangeException">The position is out of range</exception>
        public void RemoveAt(int index)
        {
            CheckIndexRange(index);

            ShiftLeft(index);
            Shrink();
            Count--;
        }

        /// <summary>
        /// Insert element at given position
        /// </summary>
        /// <param name="index">Position to insert element</param>
        /// <param name="element">Element to insert at position</param>
        public void InsertAt(int index, int element)
        {
            CheckIndexRange(index);
            ShiftRight(index);
            innerArr[index] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (innerArr[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Swap value of first and second index of the list.
        /// </summary>
        /// <param name="firstIndex">First index</param>
        /// <param name="secondIndex">Second index</param>
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex > Count - 1)
            {
                throw new Exception("First index is out of range in the array. Operation cannot be complete.");
            }

            if (secondIndex < 0 || secondIndex > Count - 1)
            {
                throw new Exception("Second index is out of range in the array. Operation cannot be complete.");
            }

            if (firstIndex == secondIndex)
            {
                throw new Exception("First and second index cannot be a same number.");
            }

            int tempElement = innerArr[firstIndex];
            innerArr[firstIndex] = innerArr[secondIndex];
            innerArr[secondIndex] = tempElement;
        }

        /// <summary>
        /// Execute function for each element in the list.
        /// </summary>
        /// <param name="action">Function</param>
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(innerArr[i]);
            }
        }

        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < Count; i++)
            {
                output += innerArr[i] + " ";
            }

            return output;
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

        private void ShiftLeft(int position)
        {
            if (position < Count - 1)
            {
                for (int i = position; i < Count - 1; i++)
                {
                    innerArr[i] = innerArr[i + 1];
                }
            }

            innerArr[Count - 1] = default;
        }

        private void ShiftRight(int position)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            for (int i = Count; i >= position; i--)
            {
                innerArr[i + 1] = innerArr[i];
            }

            innerArr[position] = default;
        }

        private void CheckIndexRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Shrink()
        {
            if (innerArr.Length / 4 > Count)
            {
                int[] tempArr = new int[innerArr.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    tempArr[i] = innerArr[i];
                }

                innerArr = tempArr;
            }
        }

        #endregion
    }
}
