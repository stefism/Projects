using System;

namespace _04_Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public string Number { get; private set; }

        public string WebAddress { get; private set; }
        
        public string Browsing(string webAddress)
        {
            if (!IsWebAddressIsNotValid(webAddress))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {webAddress}!";
        }

        public string Calling(string number)
        {
            if (!IsNumberIsNotValid(number))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }

        private bool IsWebAddressIsNotValid(string address)
        {
            for (int i = 0; i < address.Length; i++)
            {
                if (char.IsDigit(address[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsNumberIsNotValid(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
