using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MillitaryElite_Daskal
{
    public class InvalidStateException : Exception
    {
        private const string EX_MESSAGE = "Invalid mission state!";

        public InvalidStateException() : base(EX_MESSAGE)
        {

        }

        public InvalidStateException(string message) 
            : base(message)
        {

        }
    }
}
