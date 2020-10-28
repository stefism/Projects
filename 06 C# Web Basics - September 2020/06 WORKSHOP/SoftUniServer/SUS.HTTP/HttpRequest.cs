using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            Headers = new List<Header>();
            Cookies = new List<Cookie>();

            string[] lines = requestString.Split(new string[] { HttpConstants.NewLine }, StringSplitOptions.None);

            string headerLine = lines[0];
            string[] headerLineParts = headerLine.Split(' ');

            Method = (HttpMethod)Enum
                .Parse(typeof(HttpMethod), headerLineParts[0], true);
            
            Path = headerLineParts[1];

            int lineIndex = 1;
            bool isInHeaders = true;
            var bodyBuilder = new StringBuilder();

            while (lineIndex < lines.Length)
            {
                string line = lines[lineIndex];
                lineIndex++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;
                    continue;
                }

                if (isInHeaders)
                {
                    Headers.Add(new Header(line));
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }                           
            }

            if (Headers.Any(x => x.Name == HttpConstants.RequestCookieHeader))
            {
                string cookiesAsString = Headers
                    .FirstOrDefault(x => x.Name == HttpConstants.RequestCookieHeader).Value;

                string[] cookies = cookiesAsString
                    .Split(new string[] { "; " }, StringSplitOptions
                    .RemoveEmptyEntries);

                foreach (var cookieAsString in cookies)
                {
                    Cookies.Add(new Cookie(cookieAsString));
                }
            }

            Body = bodyBuilder.ToString();
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public string Body { get; set; }
    }
}
