using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _03_E_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputText = File.ReadAllLines("text.txt".ToLower()); // Тука ToLower не работи незнайно що.
            string[] wordsToFind = File.ReadAllLines("words.txt".ToLower()); // Щото не се присвоява най-вероятно.

            var wordsCount = new Dictionary<string, int>();

            foreach (var word in wordsToFind)
            {
                wordsCount[word] = 0;
            }

            foreach (var line in inputText)
            {
                string[] splittedLine = line.Split(new char[] { ',', ' ', '.', ';', '-', '!', '?', ':', '\'' });

                foreach (var currentWord in splittedLine)
                {
                    string currentWordToLower = currentWord.ToLower();

                    if (wordsCount.ContainsKey(currentWordToLower))
                    {
                        wordsCount[currentWordToLower]++;
                    }
                }
            }

            foreach (var word in wordsCount)
            {
                File.AppendAllText("actualResult.txt", $"{word.Key} - {word.Value}{Environment.NewLine}");
            }

            wordsCount = wordsCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var word in wordsCount)
            {
                File.AppendAllText("expectedResult.txt", $"{word.Key} - {word.Value}{Environment.NewLine}");
            }
        }
    }
}
