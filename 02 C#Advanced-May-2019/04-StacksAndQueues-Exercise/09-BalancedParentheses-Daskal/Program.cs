using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_BalancedParentheses_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> stackOfParenteses = new Stack<char>();

            char[] openPareneteses = new char[] { '(', '{', '[' };

            bool isValid = true;

            foreach (var item in input)
            {
                if (openPareneteses.Contains(item))
                {
                    stackOfParenteses.Push(item);
                    continue;
                }

                if (stackOfParenteses.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stackOfParenteses.Peek() == '(' && item == ')')
                {
                    stackOfParenteses.Pop();
                }

                else if (stackOfParenteses.Peek() == '[' && item == ']')
                {
                    stackOfParenteses.Pop();
                }

                else if (stackOfParenteses.Peek() == '{' && item == '}')
                {
                    stackOfParenteses.Pop();
                }

                else
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
