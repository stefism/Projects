using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03_TheIsleOfManTTRace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Евентуално дали не го чупи след дължината на кода.
            // ([#$%*&])(?<racer>[A-Za-z]+)\1.*=(?<codeLength>\d+)!!(?<code>.+)

            var regex = new Regex(@"([#$%*&])(?<racer>[A-Za-z]+)\1.*=(?<codeLength>\d+)!!(?<code>.+)");

            while (true)
            {
                string inputMessage = Console.ReadLine();

                var matches = regex.Match(inputMessage);

                

                if (matches.Success)
                {
                    string racer = matches.Groups["racer"].Value;
                    int codeLength = int.Parse(matches.Groups["codeLength"].Value);
                    string code = matches.Groups["code"].Value;

                    if (codeLength == code.Length)
                    {
                        string decryptedCode = string.Empty;

                        for (int i = 0; i < code.Length; i++)
                        {
                            decryptedCode += (char)(code[i] + codeLength);
                        }

                        Console.WriteLine($"Coordinates found! {racer} -> {decryptedCode}");

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }

        }
    }
}
