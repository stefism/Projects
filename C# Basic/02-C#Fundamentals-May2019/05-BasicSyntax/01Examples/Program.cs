using System;

namespace _01Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            bool parseResult = int.TryParse(Console.ReadLine(), out int result);
            Console.WriteLine(parseResult);
            Console.WriteLine(result);
            //Опитва се да парсне входа към число и ако успее, променливата result връща нула или едно.
            // Conditional BreakPoint! Спира само ако дадено условие е изпълнено.

        }
    }
}
