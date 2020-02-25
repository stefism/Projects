using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                PrintYellow(i.ToString(), (ConsoleColor)(i % 16));
            }
        }

        static void PrintNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void PrintYellow(string textToPrint, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(textToPrint);
            Console.ResetColor();
        }

    }
}
