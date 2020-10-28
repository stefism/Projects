using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Telephony
{
    public class InvalidURLException : Exception
    {
        private const string EX_MESSAGE =  "Invalid URL!";

        public InvalidURLException() : base(EX_MESSAGE)
        {

        }

        public InvalidURLException(string message) 
            : base(message)
        {

        }
    }
}
