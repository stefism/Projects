using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;

        public StackOfStrings()
        {
            stack = new Stack<string>();
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public Stack<string> AddRange(params string[] param)
        {
            for (int i = 0; i < param.Length; i++)
            {
                stack.Push(param[i]);
            }

            return stack;
        }
    }
}
