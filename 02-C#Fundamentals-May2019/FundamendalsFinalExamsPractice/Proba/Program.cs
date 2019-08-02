using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _03_Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            // Programming Fundamentals Exam - 09 July 2017 Part 2

            var secondRegexLetters = new Regex(@"[A-Za-z]+-[A-Za-z]+");
            var firstRegexOther = new Regex(@"[^A-Za-z-]+");

            string input = Console.ReadLine();

            string manipulatedString = input;

            while (manipulatedString != "")
            {
                var firstOtherMatch = firstRegexOther.Match(manipulatedString);
                var secondLettersMatch = secondRegexLetters.Match(manipulatedString);

                if (!firstOtherMatch.Success && !secondLettersMatch.Success)
                {
                    break;
                }

                string firstMatch = firstOtherMatch.Value;
                Console.WriteLine(firstMatch);

                int firstIndex = manipulatedString.IndexOf(firstMatch);

                manipulatedString = manipulatedString.Remove(0, firstIndex + firstMatch.Length);

                if (manipulatedString == "")
                {
                    break;
                }

                string secondMatch = secondLettersMatch.Value;
                Console.WriteLine(secondMatch);

                int secondIndex = manipulatedString.IndexOf(secondMatch);

                manipulatedString = manipulatedString.Remove(0, secondIndex + secondMatch.Length);
            }
        }
    }
}
