using System;
using System.Collections.Generic;
using System.Text;

namespace CustomClass
{
    public class DoublyLinkedList
    {
        public int Count { get; private set; }
        private LinkNode head;
        private LinkNode tail;

        public void AddFirst(object value)
        {
            LinkNode newHead = new LinkNode(value);

            if (Count == 0)
            {
                tail = newHead;
                head = newHead;
            }
            else
            {
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(object value)
        {
            LinkNode newTail = new LinkNode(value);

            if (Count == 0)
            {
                tail = newTail;
                head = newTail;
            }
            else
            {
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }

            Count++;
        }

        public void Print(Action<object> action)
        {
            LinkNode currentNode = head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public object RemoveFirst()
        {
            CheckIfEmptyThrowException();

            object firstElement = head.Value;
            head = head.NextNode;

            if (head == null)
            {
                tail = null;
            }
            else
            {
                head.PreviousNode = null;
            }

            Count--;

            return firstElement;
        }

        public object RemoveLast()
        {
            CheckIfEmptyThrowException();

            object lastElement = tail.Value;
            tail = tail.PreviousNode;

            if (tail == null)
            {
                head = null;
            }
            else
            {
                tail.NextNode = null;
            }

            Count--;

            return lastElement;
        }

        public object[] ToArray()
        {
            object[] array = new object[Count];

            LinkNode currentNode = head;
            int counter = 0;

            while (currentNode != null)
            {
                array[counter++] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
        }

        public bool Contains(object value)
        {
            LinkNode currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        #region Private

        private void CheckIfEmptyThrowException()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is empty.");
            }
        }

        private class LinkNode
        {
            public object Value { get; private set; }
            public LinkNode NextNode { get; set; }
            public LinkNode PreviousNode { get; set; }

            public LinkNode(object value)
            {
                Value = value;
            }
        }

        #endregion
    }
}
