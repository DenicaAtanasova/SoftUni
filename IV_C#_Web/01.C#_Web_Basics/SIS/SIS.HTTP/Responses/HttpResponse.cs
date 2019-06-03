﻿namespace SIS.HTTP.Responses
{
    using Common;
    using Cookies;
    using Enums;
    using Extensions;
    using Headers;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        private readonly IHttpHeaderCollection headers;
        private readonly IHttpCookieCollection cookies;

        public HttpResponse()
        {
            this.headers = new HttpHeaderCollection();
            this.cookies = new HttpCookieCollection();
            this.Content = new byte[0];
        }

        public HttpResponse(HttpResponseStatusCode statusCode) : this()
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.headers.AddHeader(header);
        }

        public void AddCookie(HttpCookie cookie)
        {
            this.cookies.AddCookie(cookie);
        }

        public byte[] GetBytes()
        {
            var httpResponseBytesWithoutBody = Encoding.UTF8.GetBytes(this.ToString());

            var httpResponseBytesWithBody = new byte[httpResponseBytesWithoutBody.Length + this.Content.Length];

            for (int i = 0; i < httpResponseBytesWithoutBody.Length; i++)
            {
                httpResponseBytesWithBody[i] = httpResponseBytesWithoutBody[i];
            }

            for (int i = 0; i < httpResponseBytesWithBody.Length - httpResponseBytesWithoutBody.Length; i++)
            {
                httpResponseBytesWithBody[i + httpResponseBytesWithoutBody.Length] = this.Content[i];
            }

            return httpResponseBytesWithBody;
        }

        public override string ToString()
        {

            var result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetStatusLine()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append($"{this.headers}").Append(GlobalConstants.HttpNewLine);

            if (this.cookies.HasCookies())
            {
                result.Append($"{this.cookies}").Append(GlobalConstants.HttpNewLine);
            }

            result.Append(GlobalConstants.HttpNewLine);

            return result.ToString();
        }
    }
}