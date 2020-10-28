using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03_Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] stack;
        public int Count { get; private set; } = -1;

        public Stack(T[] elements)
        {
            stack = elements;
        }

        public Stack()
        {

        }

        public T Pop()
        {
            try
            {
                if (stack == null)
                {
                    Count = -1;
                    throw new ArgumentException("No elements");
                }

                T popElement = stack[stack.Length - 1];

                if (stack.Length > 1)
                {
                    T[] tempArray = new T[stack.Length - 1];
                    Count = 1;

                    for (int i = 0; i < stack.Length - 1; i++)
                    {
                        tempArray[i] = stack[i];
                    }

                    stack = tempArray;

                    return popElement;
                }

                else
                {
                    popElement = stack[0];
                    stack = null;
                    Count = -1;
                    return popElement;
                }
            }

            catch (Exception exeption)
            {

                Console.WriteLine(exeption.Message);
            }

            T[] temp = new T[2];

            return temp[0];
        }

        public void Push(T[] elements)
        {
            if (stack == null)
            {
                stack = new T[elements.Length];

                for (int i = 0; i < elements.Length; i++)
                {
                    stack[i] = elements[i];
                }
            }
            else
            {
                T[] tempArray = new T[stack.Length + elements.Length];

                for (int i = 0; i < stack.Length; i++)
                {
                    tempArray[i] = stack[i];
                }

                int count = stack.Length;

                for (int i = 0; i < elements.Length; i++)
                {
                    tempArray[count] = elements[i];
                    count++;
                }

                stack = tempArray;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Length - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
