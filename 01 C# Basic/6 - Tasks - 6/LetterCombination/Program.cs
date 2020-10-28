using System;

namespace LetterCombination
{
    class Program
    {
        static void Main(string[] args)
        {
        
            char startLetter = char.Parse(Console.ReadLine());
            char endLetter = char.Parse(Console.ReadLine());
            char missingLetter = char.Parse(Console.ReadLine());

            int combinationCounter = 0;

            for (int letter1 = startLetter; letter1 <= endLetter; letter1++)
            {
                for (int letter2 = startLetter; letter2 <= endLetter; letter2++)
                {
                    for (int letter3 = startLetter; letter3 <= endLetter; letter3++)
                    {
                        if (letter1 != missingLetter && letter2 != missingLetter && letter3 != missingLetter)
                        {
                            combinationCounter++; 
                            Console.Write($"{(char)letter1}{(char)letter2}{(char)letter3} ");
                        }
                    }
                }
            }
            Console.Write(combinationCounter);

        }
    }
}
