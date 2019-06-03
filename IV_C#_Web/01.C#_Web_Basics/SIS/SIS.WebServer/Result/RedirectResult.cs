﻿namespace SIS.MvcFramework.Result
{
    using HTTP.Enums;
    using HTTP.Headers;

    public class RedirectResult : ActionResult
    {
        public RedirectResult(string location) : base(HttpResponseStatusCode.SeeOther)
        {
            this.AddHeader(new HttpHeader(HttpHeader.Location, location));
        }
    }
}