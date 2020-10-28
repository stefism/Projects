using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Telephony
{
    class InvalidPhoneNumberException : Exception
    {
        private const string EX_MESSAGE = "Invalid number!";

        public InvalidPhoneNumberException() : base(EX_MESSAGE)
        {
        }

        public InvalidPhoneNumberException(string message) 
            : base(message)
        {
        }
    }
}
