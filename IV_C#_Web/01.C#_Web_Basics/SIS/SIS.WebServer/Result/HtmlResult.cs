﻿namespace SIS.MvcFramework.Result
{
    using System.Text;
    using HTTP.Enums;
    using HTTP.Headers;

    public class HtmlResult : ActionResult
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode = HttpResponseStatusCode.Ok) : base(responseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentType, "text/html; charset=utf-8"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}