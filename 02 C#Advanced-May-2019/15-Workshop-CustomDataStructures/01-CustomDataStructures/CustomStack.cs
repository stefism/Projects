using System;
using System.Collections.Generic;
using System.Text;

namespace CustomClass
{
    public class CustomStack
    {
        /// <summary>
        /// Default size of iternal array.
        /// </summary>
        private const int defaultSize = 4;

        /// <summary>
        /// Iternal array.
        /// </summary>
        private int[] innerArr;

        /// <summary>
        /// Number of element in stack.
        /// </summary>
        public int Count { get; private set; } = 0;

        public CustomStack()
        {
            innerArr = new int[defaultSize];
        }

        public void Push(int element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        public int Peek()
        {
            CheckIfEmpty();

            return innerArr[Count - 1];
        }

        public int Pop()
        {
            CheckIfEmpty();
            Count--;
            int tempElement = innerArr[Count];
            innerArr[Count] = default;

            return tempElement;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(innerArr[i]);
            }
        }

        #region Private

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

        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        #endregion
    }
}
