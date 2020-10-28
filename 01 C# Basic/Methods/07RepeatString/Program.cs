using System;

namespace _07RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToPrint = Console.ReadLine();
            int repeat = int.Parse(Console.ReadLine());
            RepeatStringByNumber(stringToPrint, repeat);
        }

        static void RepeatStringByNumber(string stringToPrint, int repeat)
        {
            for (int i = 0; i < repeat; i++)
            {
                Console.Write(stringToPrint);
            }
        }
    }
}
