namespace SIS.MvcFramework.Result
{
    using HTTP.Responses;
    using SIS.HTTP.Enums;

    public abstract class ActionResult : HttpResponse
    {
        protected ActionResult(HttpResponseStatusCode httpResponseStatusCode)
            : base(httpResponseStatusCode)
        {
        }
    }
}