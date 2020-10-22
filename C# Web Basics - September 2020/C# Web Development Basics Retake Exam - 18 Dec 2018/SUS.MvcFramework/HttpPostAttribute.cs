using SUS.HTTP;

namespace SUS.MvcFramework
{
    public class HttpPostAttribute : BaseHttpAttribute
    {
        public HttpPostAttribute()
        {

        }

        public HttpPostAttribute(string url)
        {
            Url = url;
        }

        public override HttpMethod Method => HttpMethod.Post;
    }
}
