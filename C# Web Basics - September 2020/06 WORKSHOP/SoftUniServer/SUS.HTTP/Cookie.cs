using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class Cookie
    {
        public Cookie(string cookieAsString)
        {
            string[] cookieParts = cookieAsString.Split(new char[] { '=' }, 2);

            Name = cookieParts[0];
            Value = cookieParts[1];
        }


        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}
