using System;
using System.Linq;

namespace _03_CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            string[] splittedText = inputText.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(IsFirstIsCapital).ToArray();

            if (inputText.Length == 0)
            {
                return;
            }

            Console.WriteLine(string.Join(Environment.NewLine, splittedText));
        }

        static Func<string, bool> IsFirstIsCapital = x =>
        {
            if (char.IsUpper(x[0]))
            {
                return true;
            }

            return false;
        };
    }
}
