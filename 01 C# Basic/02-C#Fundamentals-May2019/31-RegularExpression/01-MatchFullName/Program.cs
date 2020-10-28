using System;
using System.Text.RegularExpressions;

namespace _01_MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+");
            string names = Console.ReadLine();

            var matches = regex.Matches(names);

            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
