using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02_Emoji_Daskal
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emojiCodeAsSrt = Console.ReadLine();

            int[] asciiCodes = emojiCodeAsSrt.Split(":").Select(int.Parse).ToArray();

            string emojiCode = ":";

            for (int i = 0; i < asciiCodes.Length; i++)
            {
                emojiCode += (char)asciiCodes[i];
            }

            emojiCode += ":";

            //string pattern = @":[a-z]{4,}:( |,|\.|!!\?)";

            //MatchCollection matches = Regex.Matches(text, pattern);

            var regex = new Regex(@"(?<emoji>:(?<emojiValue>[a-z]{4,}):)( |,|\.|!!\?)");
            var matches = regex.Matches(text);

            List<string> emojis = matches.Select(x => x.Groups["emoji"].Value).ToList();

            int totalAsciiSum = 0;

            foreach (var emoji in emojis)
            {
                foreach (var symbol in emoji)
                {
                    if (symbol != ':')
                    {
                    totalAsciiSum += symbol;
                    }
                }
            }

            if (emojis.Contains(emojiCode))
            {
                totalAsciiSum *= 2;
            }

            if (emojis.Any())
            {
                Console.WriteLine("Emojis found: " + string.Join(", ", emojis));
            }

            Console.WriteLine($"Total Emoji Power: {totalAsciiSum}");
        }
    }
}
