using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            if (!input.Contains('(') && !input.Contains('[') && !input.Contains('{')) // Ако не съдържа нито едно от трите.
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == '{' || currentChar == '[' || currentChar == '(')
                {
                    brackets.Push(currentChar);
                }
                else if (currentChar == '}' || currentChar == ']' || currentChar == ')')
                {
                    if (brackets.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    char lastStackChar = brackets.Peek();

                    if ((lastStackChar == '(' && currentChar == ')') || (lastStackChar == '[' && currentChar == ']') || (lastStackChar == '{' && currentChar == '}'))
                    {
                        brackets.Pop();
                        input = input.Remove(i-1, 2);
                        i -= 2;
                    }
                    else
                    {
                        //Console.WriteLine("NO");
                        break;
                    }
                }
            }

            if (brackets.Count == 0)
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
