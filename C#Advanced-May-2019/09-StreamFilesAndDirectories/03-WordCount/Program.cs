using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = File.ReadAllText("words.txt");
            string[] splitedWords = words.Split();

            string inputFile = File.ReadAllText("text.txt");

            foreach (var word in splitedWords)
            {
                Regex regex = new Regex(word);

                int currentWordCount = regex.Matches(inputFile).Count();
                Console.WriteLine($"{word} - {currentWordCount}");
            }
        }
    }
}
