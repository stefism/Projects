using System;

namespace _06_TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastLetter = int.Parse(Console.ReadLine());

            for (int firstLetter = 97; firstLetter < 97 + lastLetter; firstLetter++)
            {
                for (int middleLetter = 97; middleLetter < 97+lastLetter; middleLetter++)
                {
                    for (int thirthLetter = 97; thirthLetter < 97+lastLetter; thirthLetter++)
                    {
                        Console.Write((char)firstLetter);
                        Console.Write((char)middleLetter);
                        Console.WriteLine((char)thirthLetter);
                    }
                }
            }
        }
    }
}
