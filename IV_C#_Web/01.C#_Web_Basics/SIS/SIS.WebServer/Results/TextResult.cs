namespace SIS.WebServer.Results
{
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;
    using System.Text;

    public class TextResult : HttpResponse
    {
        private const string DefaulContentTypeHeaderValue = "text/plain; charset=utf-8";
        public TextResult(string content, HttpResponseStatusCode responseStatusCode, string contentType = DefaulContentTypeHeaderValue)
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
            this.Content = Encoding.UTF8.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponseStatusCode responseStatusCode, string contentType = DefaulContentTypeHeaderValue)
            :base(responseStatusCode)
        {
            this.Content = content;
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, contentType));
        }
    }
}