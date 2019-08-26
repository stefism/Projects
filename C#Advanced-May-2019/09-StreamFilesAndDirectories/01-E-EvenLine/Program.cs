using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _01_E_EvenLine
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter("output.txt"))
            {
                int counter = 0;

                using (var reader = new StreamReader("text.txt"))
                {
                    string currentLine = reader.ReadLine();

                    while (currentLine != null)
                    {
                        if (counter % 2 == 0)
                        {
                            //Console.WriteLine(currentLine);

                            currentLine = ReplaceSymbols(currentLine);
                            currentLine = ReverseWords(currentLine);

                            Console.WriteLine(currentLine);
                            writer.WriteLine(currentLine);
                        }

                        currentLine = reader.ReadLine();

                        counter++;
                    }
                }
            }
        }

        static string ReverseWords(string currentLine)
        {
            string[] splittedLine = currentLine.Split();

            List<string> words = new List<string>();

            foreach (var word in splittedLine)
            {
                words.Add(word);
            }

            words.Reverse();

            currentLine = string.Join(" ", words);

            return currentLine;
            
            // Същото но само с един ред;
            //return string.Join(" ", currentLine.Split().Reverse());
        }

        static string ReplaceSymbols(string currentLine)
        {
            return currentLine.Replace("-", "@").Replace(",", "@")
                .Replace(".", "@").Replace("!", "@").Replace("?", "@");
        }
    }
}
