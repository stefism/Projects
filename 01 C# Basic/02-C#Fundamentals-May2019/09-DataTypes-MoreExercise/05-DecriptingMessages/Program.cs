using System;

namespace _05_DecriptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLetters = int.Parse(Console.ReadLine());

            string outputMessage = "";

            for (int i = 0; i < numberOfLetters; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                int realChar = currentChar + key;

                //numberB.Add(int.Parse(right[j].ToString()));
                outputMessage += (char)realChar;
                //Console.Write((char)realChar);
            }

            Console.WriteLine(outputMessage);
        }
    }
}
