namespace SIS.MvcFramework.Result
{
    using System.Text;
    using HTTP.Enums;
    using HTTP.Headers;

    public class TextResult : ActionResult
    {
        private const string ContentType = "text/plain; charset=utf-8";

        public TextResult(string content, HttpResponseStatusCode responseStatusCode,
            string contentType = ContentType) : base(responseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
            this.Content = Encoding.UTF8.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponseStatusCode responseStatusCode,
            string contentType = ContentType) : base(responseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
            this.Content = content;
        }
    }
}