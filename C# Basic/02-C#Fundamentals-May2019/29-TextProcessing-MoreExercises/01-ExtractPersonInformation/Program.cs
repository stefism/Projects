using System;

namespace _01_ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();

                int nameFirstSymbol = input.IndexOf('@') + 1;
                int nameLastSymbol  = input.IndexOf('|') - 1;
                int nameLength = (nameLastSymbol - nameFirstSymbol) + 1;

                string name = input.Substring(nameFirstSymbol, nameLength);

                int ageFirstSymbol = input.IndexOf('#') + 1;
                int ageLastSymbol = input.IndexOf('*') - 1;
                int ageLength = (ageLastSymbol - ageFirstSymbol) + 1;

                string age = input.Substring(ageFirstSymbol, ageLength);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
