namespace SIS.MvcFramework.Result
{
    using HTTP.Enums;
    using HTTP.Headers;

    public class FileResult : ActionResult
    {
        public FileResult(byte[] fileContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok) 
            : base(httpResponseStatusCode)
        {
            this.AddHeader(new HttpHeader(HttpHeader.ContentLength, fileContent.Length.ToString()));
            this.AddHeader(new HttpHeader(HttpHeader.ContentDisposition, "Attachment"));
            this.Content = fileContent;
        }
    }
}