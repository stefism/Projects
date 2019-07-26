using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02_SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            // (?<artist>[A-Z]\s*[\s*'?a-z]*):
            // :(?<song>[\s*A-Z]*)

            var artistRegex = new Regex(@"^(?<artist>[A-Z]\s*[\s*'?a-z]*):");
            var songRegex = new Regex(@":(?<song>[\s*A-Z]*)");

            while (true)
            {
                string inputAsString = Console.ReadLine();

                if (inputAsString == "end")
                {
                    break;
                }

                var artistMatch = artistRegex.Match(inputAsString);
                var songMatch = songRegex.Match(inputAsString);

                if (artistMatch.Success && songMatch.Success)
                {
                    string[] input = inputAsString.Split(":");

                    string artist = input[0];
                    string song = input[1]; // ?

                    int key = artist.Length;

                    string output = string.Empty;

                    for (int i = 0; i < inputAsString.Length; i++)
                    {
                        if (inputAsString[i] == ':')
                        {
                            output += '@';
                            continue;
                        }

                        else if (inputAsString[i] == ' ')
                        {
                            output += ' ';
                            continue;
                        }

                        else if (inputAsString[i] == '\'')
                        {
                            output += '\'';
                            continue;
                        }

                        if (inputAsString[i] >= 97 && inputAsString[i] <= 122 && key + inputAsString[i] > 122)
                        {
                            output += (char)((key + inputAsString[i]) - 26);
                        }

                        else if (inputAsString[i] >= 65 && inputAsString[i] <= 90 && key + inputAsString[i] > 90)
                        {
                            output += (char)((key + inputAsString[i]) - 26);
                        }

                        else
                        {
                            output += (char)(inputAsString[i] + key);
                        }
                    }

                    Console.WriteLine($"Successful encryption: {output}");
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
