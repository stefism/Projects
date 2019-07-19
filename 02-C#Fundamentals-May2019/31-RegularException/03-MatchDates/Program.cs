using System;
using System.Text.RegularExpressions;

namespace _03_MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"\b(\d{2})([-.\/])([A-Z][a-z]{2})\2(\d{4})\b");

            // @"\b(\d{2})([-.\/])([A-Z][a-z]{2})\2(\d{4})\b" - Работи.
            // \b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b - Не работи.

            string dates = Console.ReadLine();

            var matches = regex.Matches(dates);

            //Console.WriteLine(string.Join(", ", matches));

            foreach (Match item in matches)
            {
                Console.WriteLine($"Day: {item.Groups["1"].Value}, Month: {item.Groups["3"].Value}, Year: {item.Groups["4"].Value}");
                //Console.WriteLine(item.Groups["3"].Value);
                //Console.WriteLine(item.Groups["4"].Value);
            }
        }
    }
}
