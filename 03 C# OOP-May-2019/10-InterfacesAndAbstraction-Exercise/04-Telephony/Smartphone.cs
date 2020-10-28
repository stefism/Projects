using System;
using System.Linq;

namespace _04_Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public string Number { get; private set; }

        public string WebAddress { get; private set; }
        
        public string Browsing(string webAddress)
        {
            if (webAddress.Any(x => char.IsDigit(x))) // Замества метода, който написах.
                // Ако някой от чаровете в стринга е цифра, връща false.

                //!IsWebAddressIsNotValid(webAddress)
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {webAddress}!";
        }

        public string Calling(string number)
        {
            if (!number.All(x => char.IsDigit(x))) // По същия начин като горното.
                // Връща true ако всичките са цифри.

                //!IsNumberIsNotValid(number)
            {
                throw new InvalidPhoneNumberException();
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
