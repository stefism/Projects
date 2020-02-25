using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_MorseCodeTranslator
{
    class Program
    {
        static Dictionary<string, char> MorseCodeInfo = new Dictionary<string, char>();
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .ToLower()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

            InitialiseCodeDictionary();

            var output = new StringBuilder();

            foreach (var word in input)
            {
                string[] splitedWord = word.Split();

                for (int i = 0; i < splitedWord.Length; i++)
                {
                    if (MorseCodeInfo.ContainsKey(splitedWord[i]))
                    {
                        output.Append(MorseCodeInfo[splitedWord[i]]);
                    }
                }

                output.Append(" ");
            }

            Console.WriteLine(output.ToString().ToUpper());
        }

        static void InitialiseCodeDictionary()
        {
            MorseCodeInfo[".-"] = 'a';
            MorseCodeInfo["-..."] = 'b';
            MorseCodeInfo["-.-."] = 'c';
            MorseCodeInfo["-.."] = 'd';
            MorseCodeInfo["."] = 'e';
            MorseCodeInfo["..-."] = 'f';
            MorseCodeInfo["--."] = 'g';
            MorseCodeInfo["...."] = 'h';
            MorseCodeInfo[".."] = 'i';
            MorseCodeInfo[".---"] = 'j';
            MorseCodeInfo["-.-"] = 'k';
            MorseCodeInfo[".-.."] = 'l';
            MorseCodeInfo["--"] = 'm';
            MorseCodeInfo["-."] = 'n';
            MorseCodeInfo["---"] = 'o';
            MorseCodeInfo[".--."] = 'p';
            MorseCodeInfo["--.-"] = 'q';
            MorseCodeInfo[".-."] = 'r';
            MorseCodeInfo["..."] = 's';
            MorseCodeInfo["-"] = 't';
            MorseCodeInfo["..-"] = 'u';
            MorseCodeInfo["...-"] = 'v';
            MorseCodeInfo[".--"] = 'w';
            MorseCodeInfo["-..-"] = 'x';
            MorseCodeInfo["-.--"] = 'y';
            MorseCodeInfo["--.."] = 'z';
            MorseCodeInfo["-----"] = '0';
            MorseCodeInfo[".----"] = '1';
            MorseCodeInfo["..---"] = '2';
            MorseCodeInfo["...--"] = '3';
            MorseCodeInfo["....-"] = '4';
            MorseCodeInfo["....."] = '5';
            MorseCodeInfo["-...."] = '6';
            MorseCodeInfo["--..."] = '7';
            MorseCodeInfo["---.."] = '8';
            MorseCodeInfo["----."] = '9';
        }
    }
}
