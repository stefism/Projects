using System;
using System.Linq;
using System.Text;

namespace _02_ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Retake Final Exam - 20 December 2018

            string[] input = Console.ReadLine().Split("&");

            var sb = new StringBuilder();

            foreach (var keys in input)
            {
                bool isKeysValid = IsKeysValid(keys);

                if (isKeysValid)
                {
                    GenerateKey(sb, keys);

                    sb.Append(", ");
                }
            }

            string output = sb.ToString().ToUpper();

            output = output.Substring(0, output.Length - 2);

            Console.WriteLine(output);
        }

        private static void GenerateKey(StringBuilder sb, string keys)
        {
            for (int i = 0; i <= keys.Length-1; i++)
            {
                char currentChar = keys[i];

                if (i > 0)
                {
                    if (keys.Length == 16)
                    {
                        if (i % 4 == 0)
                        {
                            sb.Append("-");
                        }
                    }
                    else if (keys.Length == 25)
                    {
                        if (i % 5 == 0)
                        {
                            sb.Append("-");
                        }
                    }
                }

                if (char.IsLetter(currentChar))
                {
                    sb.Append(currentChar);
                }
                else
                {
                    string currentDigitAsString = keys[i].ToString();
                    int currentDigit = 9 - int.Parse(currentDigitAsString);
                    sb.Append(currentDigit);
                }
            }
        }

        static bool IsKeysValid(string keys)
        {
            if (keys.Length < 16 && keys.Length > 25)
            {
                return false;
            }

            for (int i = 0; i < keys.Length; i++)
            {
                if (!char.IsLetterOrDigit(keys[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
