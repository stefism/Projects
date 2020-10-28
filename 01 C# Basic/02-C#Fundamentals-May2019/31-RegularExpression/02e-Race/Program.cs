using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _02e_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var character = new Regex("[A-Za-z]");
            var digit = new Regex("[0-9]");

            string[] names = Console.ReadLine().Split(", ");

            var namesAndKm = new Dictionary<string, double>();

            while (true)
            {
                string inputString = Console.ReadLine();

                var charMatch = character.Matches(inputString);
                var digitMatch = digit.Matches(inputString);

                if (inputString == "end of race")
                {
                    namesAndKm = namesAndKm.OrderByDescending(x => x.Value)
                        .ToDictionary(x => x.Key, x => x.Value);

                    Console.WriteLine($"1st place: {namesAndKm.ElementAt(0).Key}");
                    Console.WriteLine($"2nd place: {namesAndKm.ElementAt(1).Key}");
                    Console.WriteLine($"3rd place: {namesAndKm.ElementAt(2).Key}");

                    break;
                }

                string currentName = string.Join("", charMatch);

                if (names.Contains(currentName))
                {
                    int[] numbers = digitMatch.Select(x => x.Value).Select(int.Parse).ToArray();
                    int sum = numbers.Sum();

                    if (!namesAndKm.ContainsKey(currentName))
                    {
                        namesAndKm[currentName] = 0;
                    }

                    namesAndKm[currentName] += sum;
                }
            }
        }
    }
}
