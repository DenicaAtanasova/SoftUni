namespace SIS.MvcFramework.Result
{
    using System.Text;
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;

    public class TextResult : HttpResponse
    {
        private const string ContentType = "text/plain; charset=utf-8";

        public TextResult(string content, HttpResponseStatusCode responseStatusCode,
            string contentType = ContentType) : base(responseStatusCode)
        {
            Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
            Content = Encoding.UTF8.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponseStatusCode responseStatusCode,
            string contentType = ContentType) : base(responseStatusCode)
        {
            Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
            Content = content;
        }
    }
}