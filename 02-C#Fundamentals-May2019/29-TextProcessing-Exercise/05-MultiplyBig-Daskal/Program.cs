using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_MultiplyBig_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberAsString = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();

            for (int i = numberAsString.Length-1; i >= 0; i--)
            {
                int lastDigit = int.Parse(numberAsString[i].ToString());

                int result = lastDigit * multiplier;

                builder.Append(result);
            }
        }
    }
}
