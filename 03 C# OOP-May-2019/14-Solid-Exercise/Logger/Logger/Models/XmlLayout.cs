using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class XmlLayout : Ilayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            var sb = new StringBuilder();

            sb.AppendLine("<log>")
                .AppendLine("\t<date>{0}</date>")
                .AppendLine("\t<level>{1}</level>")
                .AppendLine("\t<message>{2}</message>")
                .Append("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
