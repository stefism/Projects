using System;
using System.Collections.Generic;
using System.Text;

namespace CustomClass
{
    public class Doubly
    {
        public class Nodes
        {
            Doubly head;
            Doubly tail;
            public int Count { get; private set; } = 0;

            public void AddFirst(int value)
            {
                if (Count == 0)
                {
                    head = new Doubly();
                    head.Value = value;
                }
                else
                {
                    head.prevValue = value;
                    head.Value = value;
                }

                Count++;
            }
        }

        public int Value { get; set; }
        private int prevValue;
        private int nextValue;

        //public Doubly(int value)
        //{
        //    Value = value;
        //}
    }
}
