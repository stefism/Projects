using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, 
            byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            StatusCode = statusCode;
            Body = body;
            Headers = new List<Header>
            {
                { new Header( "Content-Type", contentType) },
                { new Header( "Content-Length", body.Length.ToString()) },
            };
        }

        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            var responseBuilder = new StringBuilder();

            responseBuilder.Append($"HTTP/1.1 {(int)StatusCode} {StatusCode}" + HttpConstants.NewLine);

            foreach (var header in Headers)
            {
                responseBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }

            responseBuilder.Append(HttpConstants.NewLine);

            return responseBuilder.ToString();
        }
    }
}
