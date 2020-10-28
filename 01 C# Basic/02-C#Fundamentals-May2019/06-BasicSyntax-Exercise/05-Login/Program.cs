using System;

namespace _05_Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = Console.ReadLine();

            string reversePassword = ReversePassword(userName);
            int wrongPassword = 0;
            bool isBlocked = false;

            while (password != reversePassword)
            {
                wrongPassword++;

                if (wrongPassword > 3)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    isBlocked = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    password = Console.ReadLine();
                }
            }

            if (!isBlocked)
            {
                Console.WriteLine($"User {userName} logged in.");
            }
         }

        static string ReversePassword(string password)
        {
            char[] reversePassword = password.ToCharArray();
            Array.Reverse(reversePassword);
            return new string(reversePassword);
        }
    }
}
