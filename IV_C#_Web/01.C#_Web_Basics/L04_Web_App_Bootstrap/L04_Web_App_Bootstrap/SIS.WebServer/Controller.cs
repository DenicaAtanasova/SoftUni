namespace SIS.WebServer
{
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using Result;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Dictionary<string, object> ViewData;

        public Controller()
        {
            this.ViewData = new Dictionary<string, object>();
        }

        private string ParseTemplate(string viewContent)
        {
            foreach (var param in this.ViewData)
            {
                viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
            }

            return viewContent;
        }

        protected bool IsLoggedIn(IHttpRequest httpRequst)
        {
            return httpRequst.Session.ContainsParameter("username");
        }

        protected void SignIn(IHttpRequest httpRequest, string id, string username, string email)
        {
            httpRequest.Session.AddParameter("id", id);
            httpRequest.Session.AddParameter("username", username);
            httpRequest.Session.AddParameter("email", email);
        }

        protected void SignOut(IHttpRequest httpRequest)
        {
            httpRequest.Session.ClearParameters();
        }

        protected IHttpResponse View([CallerMemberName] string view = null)
        {
            var controllerName = GetType().Name.Replace("Controller", string.Empty);
            var viewName = view;

            var viewContent = File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");

            viewContent = ParseTemplate(viewContent);

            var htmlResult = new HtmlResult(viewContent, HTTP.Enums.HttpResponseStatusCode.Ok);

            return htmlResult;
        }
         
        protected IHttpResponse Redirect(string url) =>
            new RedirectResult(url);
    }
}