namespace SIS.MvcFramework.Result
{
    using HTTP.Enums;
    using HTTP.Headers;
    using HTTP.Responses;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location) : base(HttpResponseStatusCode.SeeOther)
        {
            Headers.AddHeader(new HttpHeader(HttpHeader.Location, location));
        }
    }
}