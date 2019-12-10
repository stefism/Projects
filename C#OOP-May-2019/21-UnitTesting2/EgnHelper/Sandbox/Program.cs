using EgnHelper;
using System;

namespace Sandbox
{
    class AlwaysValidEgnValidator : IEgnValidator
    {
        public bool IsValid(string egn)
        {
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ValidateFromUser(new EgnValidator());
        }

        public static void ValidateFromUser(IEgnValidator validator)
        {
            string egn = Console.ReadLine();
            Console.WriteLine("Valid: " + validator.IsValid(egn));
        }
    }
}
