using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _02_MessageEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());

            // ([*@])(?<request>[A-Z][a-z]{3,})\1: \[(?<code1>[A-Za-z])\]\|\[(?<code2>[A-Za-z])\]\|\[(?<code3>[A-Za-z])\]\|$

            var regex = new Regex(@"([*@])(?<request>[A-Z][a-z]{3,})\1: \[(?<code1>[A-Za-z])\]\|\[(?<code2>[A-Za-z])\]\|\[(?<code3>[A-Za-z])\]\|$");

            for (int i = 0; i < numberOfInput; i++)
            {
                string input = Console.ReadLine();

                var matches = regex.Match(input);

                if (matches.Success)
                {
                    string request = matches.Groups["request"].Value;

                    char code1 = char.Parse(matches.Groups["code1"].Value);
                    char code2 = char.Parse(matches.Groups["code2"].Value);
                    char code3 = char.Parse(matches.Groups["code3"].Value);

                    int code1Int = code1;
                    int code2Int = code2;
                    int code3Int = code3;

                    Console.WriteLine($"{request}: {code1Int} {code2Int} {code3Int}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
