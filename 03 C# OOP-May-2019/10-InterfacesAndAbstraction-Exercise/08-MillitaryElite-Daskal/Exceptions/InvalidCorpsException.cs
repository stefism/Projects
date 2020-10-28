using System;
using System.Collections.Generic;
using System.Text;

namespace _08_MillitaryElite_Daskal
{
    public class InvalidCorpsException : Exception
    {
        private const string EX_MESSAGE = "Invalid corps!";

        public InvalidCorpsException() : base(EX_MESSAGE)
        {

        }

        public InvalidCorpsException(string message) 
            : base(message)
        {

        }
    }
}
