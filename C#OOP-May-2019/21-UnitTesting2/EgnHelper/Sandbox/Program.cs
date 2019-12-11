using EgnHelper;
using System;

namespace Sandbox
{
    public class Program
    {
        static IEgnValidator Validator = new EgnValidator();
        public static void Main()
        {
            string egn = Console.ReadLine();

            ValidateFromUser(Validator, egn);

            string info = GetEgnInformation(egn);

            Console.WriteLine(info);
        }

        public static string GetEgnInformation(string egn)
        {
            EgnInformationExtractor information = new EgnInformationExtractor(Validator);

            EgnInformation egnInfo = information.Extract(egn);

            return egnInfo.ToString();
        }

        public static void ValidateFromUser(IEgnValidator validator, string egn)
        {
            Console.WriteLine("Valid: " + validator.IsValid(egn));
        }
    }
}
