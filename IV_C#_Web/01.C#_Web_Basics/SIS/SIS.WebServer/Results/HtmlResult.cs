namespace SIS.WebServer.Results
{
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;
    using System.Text;

    public class HtmlResult : HttpResponse
    {
        private const string DefaulContentTypeHeaderValue = "text/html; charset=utf-8";
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentType, DefaulContentTypeHeaderValue));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}