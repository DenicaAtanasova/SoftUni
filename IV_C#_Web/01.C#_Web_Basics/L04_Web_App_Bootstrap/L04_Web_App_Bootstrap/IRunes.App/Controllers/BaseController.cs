namespace IRunes.App.Controllers
{
    using IRunes.Models;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Result;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    public abstract class BaseController
    {
        protected Dictionary<string, object> ViewData;

        public BaseController()
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

        protected void SignIn(IHttpRequest httpRequest, User user)
        {
            httpRequest.Session.AddParameter("id", user.Id);
            httpRequest.Session.AddParameter("username", user.Username);
            httpRequest.Session.AddParameter("email", user.Email);
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

            var htmlResult = new HtmlResult(viewContent, HttpResponseStatusCode.Ok);

            return htmlResult;
        }

        protected IHttpResponse Redirect(string url) =>
            new RedirectResult(url);
    }
}
