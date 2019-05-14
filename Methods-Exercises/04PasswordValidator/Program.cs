using System;

namespace _04PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();

            bool isBetweenSixAndTenChars = StringLenghtChecker(inputPassword);
            bool isOnlyLettersAndDigits = StringCharChecker(inputPassword);
            bool isHaveAtLeastTwoDigit = DigitCountChecher(inputPassword);

            if (!isBetweenSixAndTenChars)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!isOnlyLettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!isHaveAtLeastTwoDigit)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isBetweenSixAndTenChars && isOnlyLettersAndDigits && isHaveAtLeastTwoDigit)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool DigitCountChecher(string inputPassword)
        {
            int countDigit = 0;

            for (int i = 0; i < inputPassword.Length; i++)
            {
                if (char.IsDigit(inputPassword[i]))
                {
                    countDigit++;
                }
            }

            if (countDigit >= 2)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private static bool StringCharChecker(string inputPassword)
        {
            for (int i = 0; i < inputPassword.Length; i++)
            {
                if (!char.IsLetterOrDigit(inputPassword[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool StringLenghtChecker(string inputPassword)
        {
            if (inputPassword.Length >= 6 && inputPassword.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
