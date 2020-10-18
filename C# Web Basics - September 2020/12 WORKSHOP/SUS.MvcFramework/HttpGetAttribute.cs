using SUS.HTTP;

namespace SUS.MvcFramework
{
    public class HttpGetAttribute : BaseHttpAttribute
    {
        public HttpGetAttribute()
        {

        }

        public HttpGetAttribute(string url)
        {
            Url = url;
        }

        public override HttpMethod Method => HttpMethod.Get;
    }
}
