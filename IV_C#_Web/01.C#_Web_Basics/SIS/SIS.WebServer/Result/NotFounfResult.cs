namespace SIS.MvcFramework.Result
{
    using SIS.HTTP.Enums;
    using System.Text;

    public class NotFounfResult : ActionResult
    {
        public NotFounfResult(string message, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.NotFound)
            : base(httpResponseStatusCode)
        {
            this.Content = Encoding.UTF8.GetBytes(message);
        }
    }
}