using System;
using System.Text.RegularExpressions;

namespace _02_MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"\+359([ -])2\1\d{3}\1\d{4}\b");

            string phones = Console.ReadLine();

            var matches = regex.Matches(phones);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
