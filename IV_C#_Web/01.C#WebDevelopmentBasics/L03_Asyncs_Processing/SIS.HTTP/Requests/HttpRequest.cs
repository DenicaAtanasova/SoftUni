
namespace SIS.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Extensions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Requests.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(Environment.NewLine, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0]
                 .Trim()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();
            this.ParseHeader(splitRequestContent.Skip(1).ToArray());
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private void ParseRequestParameters(string requestLine)
        {
            ParseQueryParamethers();

            ParseFormDataParameters(requestLine);
        }

        private void ParseFormDataParameters(string requestLine)
        {
            if (String.IsNullOrEmpty(requestLine))
            {
                return;
            }

            var parameters = requestLine.Split('&');

            foreach (var parameter in parameters)
            {
                var parameterTockens = parameter.Split('=');

                var parameterKey = parameterTockens[0];
                var parameterValue = parameterTockens[1];

                this.FormData.Add(parameterKey, parameterValue);
            }
        }

        private void ParseQueryParamethers()
        {
            var queryString = this.Url.Split('?');
            if (queryString.Length <= 1)
            {
                return;
            }

            var queryParameters = queryString.Last().Split('&');

            if (IsValidRequestQueryString(queryString.Last(), queryParameters))
            {
                throw new BadRequestException();
            }

            foreach (var parameter in queryParameters)
            {
                var parameterArgs = parameter.Split("=");

                var parameterKey = parameterArgs[0];
                var parameterValue = parameterArgs[1];

                this.QueryData.Add(parameterKey, parameterValue);
            }
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters) => !String.IsNullOrEmpty(queryString) && queryParameters.Length < 1;

        private void ParseHeader(string[] requestLine)
        {
            int index = 0;

            while (!String.IsNullOrEmpty(requestLine[index]))
            {
                var headerParams = requestLine[index]
                    .Split(':');
                var headerKey = headerParams[0];
                var headerValue = headerParams[1];

                var header = new HttpHeader(headerKey, headerValue);

                this.Headers.Add(header);

                index++;
            }

            if (!this.Headers.ContainsHeader(GlobalConstants.HostHeaderKey))
            {
                throw new BadRequestException();
            }
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url
                .Split("?", StringSplitOptions.RemoveEmptyEntries)
                .First()
                .ToString();
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var requestMethodString = requestLine[0].Capitalize();

            bool IsRequestMethodParsed = Enum.TryParse(typeof(HttpRequestMethod), requestMethodString, out var requestMethod);

            if (!IsRequestMethodParsed)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = (HttpRequestMethod)requestMethod;
            
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3
            && requestLine[2] == GlobalConstants.HttpOneProtocolFragment;
        }

    }
}
