using System;

namespace _03CharacterInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());

            CharacterInRange(a, b);
        }

        static void CharacterInRange(char a, char b)
        {
            int numberA = a;
            int numberB = b;

            if (numberB < numberA)
            {
                for (int i = b + 1; i <= a - 1; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = a + 1; i <= b - 1; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}
