using System;
using System.Text.RegularExpressions;

namespace _03_MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b");

            string dates = Console.ReadLine();

            var matches = regex.Matches(dates);

            Console.WriteLine(string.Join(", ", matches));

            foreach (Match item in matches)
            {
                Console.WriteLine(item.Groups["day"].Value);
            }
        }
    }
}
