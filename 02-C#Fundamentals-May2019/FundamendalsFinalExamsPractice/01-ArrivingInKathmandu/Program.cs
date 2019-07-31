using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_ArrivingInKathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Final Exam - 14 April 2019 Group I

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Last note")
                {
                    break;
                }

                string[] peakAndCodeInDigit = input.Split("=");
                int geohachcodeDigit = -2;

                if (peakAndCodeInDigit.Length == 1)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }
                else
                {
                    int index = peakAndCodeInDigit[1].IndexOf("<<"); // Евентуално тука ако взима само първото <
                    string code = peakAndCodeInDigit[1].Substring(0, index);
                    bool codeInDigit = int.TryParse(code, out int parsedCode);

                    if (codeInDigit)
                    {
                        geohachcodeDigit = parsedCode;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                }

                string[] geohashcodeString = input.Split("<<");
                string geohashcode = geohashcodeString[1]; // Тука ако няма нищо след <<?

                if (geohashcode.Length != geohachcodeDigit)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }



                string encodedPeak = peakAndCodeInDigit[0];

                string decodedPeak = string.Empty;

                bool isPeakNameValid = true;

                for (int i = 0; i < encodedPeak.Length; i++)
                {
                    if (!char.IsLetterOrDigit(encodedPeak[i]) && encodedPeak[i] != '!' &&
                        encodedPeak[i] != '@' && encodedPeak[i] != '#' && encodedPeak[i] != '$'
                        && encodedPeak[i] != '?')
                    {
                        isPeakNameValid = false;
                        break;
                    }
                    else
                    {
                        if (char.IsLetterOrDigit(encodedPeak[i]))
                        {
                            decodedPeak += (char)encodedPeak[i];
                        }
                    }
                }

                if (!isPeakNameValid)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                Console.WriteLine($"Coordinates found! {decodedPeak} -> {geohashcode}");
            }
        }
    }
}
