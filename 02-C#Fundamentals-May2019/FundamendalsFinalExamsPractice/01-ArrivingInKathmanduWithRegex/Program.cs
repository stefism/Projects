using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01_ArrivingInKathmanduWithRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            //Technology Fundamentals Final Exam - 14 April 2019 Group I

            var regex = new Regex(@"^(?<peak>[A-Za-z!@#$?]+)=(?<codeLength>\d+)<<(?<code>.+)");

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Last note")
                {
                    break;
                }

                var matches = regex.Match(input);

                if (matches.Success)
                {
                    string peak = matches.Groups["peak"].Value;
                    int codeLenght = int.Parse(matches.Groups["codeLength"].Value);
                    string code = matches.Groups["code"].Value;

                    if (codeLenght != code.Length)
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }

                    string decodedPeak = string.Empty;

                    for (int i = 0; i < peak.Length; i++)
                    {
                        if (char.IsLetterOrDigit(peak[i]))
                        {
                            decodedPeak += peak[i];
                        }
                    }

                    Console.WriteLine($"Coordinates found! {decodedPeak} -> {code}");
                }

                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
