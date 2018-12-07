
namespace SIS.WebServer.Results
{
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;
    using System;
    using System.Text;

    public class InternalServerErrorResult : HttpResponse
    {
        private const string DefaultErrorHeading = "<h1>Internal Server Error occured, see details</h1>";

        public InternalServerErrorResult(string content)
            : base(HttpResponseStatusCode.InternalServerError)
        {
            content = DefaultErrorHeading + Environment.NewLine + content;
            this.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/html"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
