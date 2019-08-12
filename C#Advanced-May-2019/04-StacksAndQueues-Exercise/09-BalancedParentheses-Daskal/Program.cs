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

            char[] openPareneteses = new char[] { '(', '{', '[' };

            bool isValid = true;

            if (!openPareneteses.Contains(input[0]))
            {
                isValid = false;
            }
        }
    }
}
