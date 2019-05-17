﻿namespace SIS.HTTP.Requests
{
    using Common;
    using Contracts;
    using Enums;
    using Exceptions;
    using Extensions;
    using Headers;
    using Headers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters) =>
            !string.IsNullOrEmpty(queryString) && queryParameters.Length > 0;

        private void ParseRequestQueryParameters()
        {
            if (!this.Url.Contains('?'))
                return;

            var queryString = this.Url
                .Split(new[] { '?' }, StringSplitOptions.None)[1];

            var queryParameters = queryString.Split('&');

            if (!this.IsValidRequestQueryString(queryString, queryParameters))
                return;

            queryParameters
                .Select(plainQueryParameter => plainQueryParameter.Split('='))
                .ToList()
                .ForEach(queryParameterKeyValurPair => this.QueryData.Add(queryParameterKeyValurPair[0], queryParameterKeyValurPair[1]));
        }
        
        private void ParseRequestFormDataParameters(string formData)
        {
            if (string.IsNullOrEmpty(formData))
                return;

            var formDataParams = formData
                .Split('&')
                .Select(plainQueryParameter => plainQueryParameter.Split('='))
                .ToList();

            foreach (var formDataParameter in formDataParams)
            {
                if (this.FormData.ContainsKey(formDataParameter[0]))
                {
                    if (this.FormData[formDataParameter[0]] is string)
                    {
                        this.FormData[formDataParameter[0]] = this.FormData[formDataParameter[0]]
                            .ToString()
                            .Split()
                            .ToList();
                    }

                    ((List<string>)this.FormData[formDataParameter[0]]).Add(HttpUtility.UrlDecode(formDataParameter[1]));
                }
                else
                {
                    this.FormData.Add(formDataParameter[0], HttpUtility.UrlDecode(formDataParameter[1]));
                }
            }
        }

        private void ParseRequestParameters(string formData)
        {
            this.ParseRequestQueryParameters();
            this.ParseRequestFormDataParameters(formData);
        }

        private void ParseRequestCookies()
        {
            throw new NotImplementedException();
        }

        private void ParseRequestHeaders(string[] requestContent)
        {
            int currentIndex = 0;

            while (!string.IsNullOrEmpty(requestContent[currentIndex]))
            {
                var headerArguments = requestContent[currentIndex++].Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                this.Headers.AddHeader(new HttpHeader(headerArguments[0], headerArguments[1]));
            }
        }

        private void ParseRequestPath() =>
            this.Path = this.Url.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries)[0];

        private void ParseRequestUrl(string[] requestLineParams) =>
            this.Url = requestLineParams[1];

        private void ParseRequestMethod(string[] requestLineParams)
        {
            var isValidRequestMethod = Enum.TryParse<HttpRequestMethod>(requestLineParams[0].Capitalize(), out var requestMethod);
            if (!isValidRequestMethod)
                throw new BadRequestException(string.Format(GlobalConstants.UnsupportedHttpMethodExceptionMessage, requestLineParams[0]));

            this.RequestMethod = requestMethod;
        }

        private bool IsValidRequestLine(string[] requestLineParams) =>
            requestLineParams.Length == 3 && requestLineParams[2] == GlobalConstants.HttpOneProtocolFragment;

        private void ParseRequest(string requestString)
        {
            var splitRequestContent = requestString
                .Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            var requestLineParams = splitRequestContent[0]
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLineParams))
                throw new BadRequestException();

            this.ParseRequestMethod(requestLineParams);
            this.ParseRequestUrl(requestLineParams);
            this.ParseRequestPath();

            this.ParseRequestHeaders(splitRequestContent.Skip(1).ToArray());
            //TODO this.ParseRequestCookies();

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }
    }
}