using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _02_EmojiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            int[] emojiCodeNumbers = Console.ReadLine().Split(":").Select(int.Parse).ToArray();
            string emojiCode = string.Empty;

            for (int i = 0; i < emojiCodeNumbers.Length; i++)
            {
                char currentChar = (char)emojiCodeNumbers[i];
                emojiCode += currentChar;
            }

            var regex = new Regex(@" :[a-z]{4,}:[ ,.!?]");

            //Здравей,
            //може да прочетеш за Lookahead и Lookbehind и да пробваш с този regex:
            //(?<=[\s])(:[a - z]{ 4,}:)(?=[\s,.! ?])
            //Поздрави:) - Това да видя също!
            // Да прочета пак условието на задачата и да разгадая израза.


            var matches = regex.Matches(inputText);

            List<string> matchesWords = new List<string>();

            AddMatchesToList(matches, matchesWords);

            int totalSum = 0;
            int countCode = 0;

            //bool isEmojiContainsCode = false;

            foreach (var item in matchesWords)
            {
                if (item == emojiCode)
                {
                    countCode += 2;
                    //isEmojiContainsCode = true;
                }

                int currentWordSum = 0;

                for (int i = 0; i < item.Length; i++)
                {
                    currentWordSum += item[i];
                }

                totalSum += currentWordSum;
            }

            if (countCode > 0) // !!! Евентуално може да има повече от едно съвпадение с кодовата дума!!!
            {
                totalSum *= countCode;
            }

            if (matchesWords.Count > 0)
            {
                Console.WriteLine($"Emojis found: :{string.Join(":" + ", " + ":",  matchesWords)}:");
            }

            Console.WriteLine($"Total Emoji Power: {totalSum}");
        }

        private static void AddMatchesToList(MatchCollection matches, List<string> matchesWords)
        {
            foreach (Match item in matches)
            {
                string currentWord = item.ToString();
                int firstIndex = currentWord.IndexOf(":");
                int lastIndex = currentWord.LastIndexOf(":");
                currentWord = currentWord.Substring(firstIndex + 1, lastIndex - 2);

                matchesWords.Add(currentWord);
            }
        }
    }
}
