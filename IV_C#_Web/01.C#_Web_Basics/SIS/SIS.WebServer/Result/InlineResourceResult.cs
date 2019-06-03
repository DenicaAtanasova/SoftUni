namespace SIS.MvcFramework.Result
{
    using HTTP.Enums;
    using HTTP.Headers;

    public class InlineResourceResult : ActionResult
    {
        public InlineResourceResult(byte[] content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentLength, content.Length.ToString()));
            this.AddHeader(new HttpHeader(HttpHeader.ContentDisposition, "inline"));
            this.Content = content;
        }
    }
}