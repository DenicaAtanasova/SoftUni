﻿namespace SIS.Demo
{
    using HTTP.Enums;
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using WebServer.Results;

    public class HomeController
    {
        public HomeController()
        {
        }

        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello, World!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}