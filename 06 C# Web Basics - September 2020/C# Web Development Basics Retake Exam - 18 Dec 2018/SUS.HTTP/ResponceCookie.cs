using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class ResponceCookie : Cookie
    {
        public ResponceCookie(string name, string value)
            : base(name, value)
        {
            Path = "/";
        }

        public int MaxAge { get; set; }

        public bool HttpOnly { get; set; }

        public string Domain { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            var cookieBuilder = new StringBuilder();

            cookieBuilder.Append($"{Name}={Value}; Path={Path};");

            if (MaxAge != 0)
            {
                cookieBuilder.Append($" Max-Age={MaxAge};");
            }

            if (HttpOnly)
            {
                cookieBuilder.Append(" HttpOnly;");
            }

            if (!string.IsNullOrEmpty(Domain))
            {
                cookieBuilder.Append($" Domain={Domain};");
            }

            return cookieBuilder.ToString();
        }
    }
}
