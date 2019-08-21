using System;
using System.Linq;
using System.Collections.Generic;

namespace _05_CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!symbols.ContainsKey(input[i]))
                {
                    symbols[input[i]] = 0;
                }

                symbols[input[i]]++;
            }

            Console.WriteLine(string.Join(Environment.NewLine, symbols
                .Select(x => $"{x.Key}: {x.Value} time/s")));
        }
    }
}
