using System;
using System.IO;
using System.Linq;

namespace _02_E_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("text.txt");
            string[] outputText = new string[text.Length];

            int counter = 1;
            

            for (int i = 0; i < text.Length; i++)
            {
                int lettersNumber = text[i].Count(char.IsLetter);
                int punctNumber = text[i].Count(char.IsPunctuation);

               // int lettersNumber = CountLetters(text[i]);
               // int punctNumber = CountPunctoationMarks(text[i]);

               outputText[i] = $"Line {counter++}: {text[i]} ({lettersNumber})({punctNumber})";
            }

            File.WriteAllLines("output.txt", outputText);
        }

        static int CountPunctoationMarks(string currentLine)
        {
            int punctCounter = 0;

            for (int i = 0; i < currentLine.Length; i++)
            {
                if (char.IsPunctuation(currentLine[i]))
                {
                    punctCounter++;
                }
            }

            return punctCounter;
        }

        static int CountLetters(string currentLine)
        {
            int lettersCounter = 0;

            for (int i = 0; i < currentLine.Length; i++)
            {
                if (char.IsLetter(currentLine[i]))
                {
                    lettersCounter++;
                }
            }

            return lettersCounter;
        }
    }
}
