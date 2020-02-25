using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace _03_SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Programming FundamentaAdditional Retake Exam - 10 January 2019 Part II

            int key = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string decodedString = string.Empty;

                for (int i = 0; i < input.Length; i++)
                {
                    decodedString += (char)(input[i] - key);
                }

                var regex = new Regex(@"@(?<name>[A-Za-z]+)[^@\-!:>]+!(?<gOrN>[GN])!");

                var matches = regex.Match(decodedString);

                if (matches.Success)
                {
                    string name = matches.Groups["name"].Value;
                    string behavior = matches.Groups["gOrN"].Value;

                    if (behavior == "G")
                    {
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}
