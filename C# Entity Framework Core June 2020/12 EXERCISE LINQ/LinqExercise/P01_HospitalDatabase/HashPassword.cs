using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace P01_HospitalDatabase
{
    public static class HashPassword
    {
        public static string HashPass(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            SHA256Managed hasString = new SHA256Managed();
            byte[] hash = hasString.ComputeHash(bytes);

            string hashedString = string.Empty;

            foreach (byte x in hash)
            {
                hashedString += String.Format("{0:x2}", x);
            }

            return hashedString;
        }
        
        public static bool IsPasswordValid(string password, string storedPassword)
        {
            string hashedPassword = HashPass(password);

            return hashedPassword == storedPassword;
        }     
    }
}
