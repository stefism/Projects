using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (var word in usernames)
            {
                bool isUserNameValid = IsUserNameValid(word);

                if (isUserNameValid)
                {
                    Console.WriteLine(word);
                }
            }
        }

        static bool IsUserNameValid(string username)
        {
            bool isValidLenght = false;
            bool isLetterOrDigit = true;

            if (username.Length >= 3 && username.Length <= 16)
            {
                isValidLenght = true;
            }

            for (int i = 0; i < username.Length; i++)
            {
                if (!char.IsLetterOrDigit(username[i]) && username[i] != '_' && username[i] != '-')
                {
                    isLetterOrDigit = false;
                }

                //if (username[i] == '_' || username[i] == '-')
                //{
                //    isLetterOrDigit = true;
                //}
            }

            if (isValidLenght && isLetterOrDigit)
            {
                return true;
            }

            return false;
        }
    }
}
