namespace SIS.MvcFramework
{
    using HTTP.Requests;
    using Result;
    using SIS.MvcFramework.Extensions;
    using SIS.MvcFramework.Identity;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected Dictionary<string, object> ViewData;

        public Controller()
        {
            ViewData = new Dictionary<string, object>();
        }

        public Principal User => 
            this.Request.Session.ContainsParameter("principal")
            ? this.Request.Session.GetParameter("principal") as Principal
            : null;

        public IHttpRequest Request { get; set; }

        private string ParseTemplate(string viewContent)
        {
            foreach (var param in ViewData)
            {
                viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
            }

            return viewContent;
        }

        protected bool IsLoggedIn() =>
            this.Request.Session.ContainsParameter("principal");

        protected void SignIn(string id, string username, string email)
        {
            this.Request.Session.AddParameter("principal", new Principal
            {
                Id = id,
                Username = username,
                Email = email
            });
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }

        protected ActionResult View([CallerMemberName] string view = null)
        {
            var controllerName = GetType().Name.Replace("Controller", string.Empty);
            var viewName = view;

            var viewContent = System.IO.File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");

            viewContent = ParseTemplate(viewContent);

            var htmlResult = new HtmlResult(viewContent);

            return htmlResult;
        }

        protected ActionResult Redirect(string url) =>
            new RedirectResult(url);

        protected ActionResult Xml(object obj) =>
            new XmlResult(obj.ToXml());

        protected ActionResult Json(object obj) =>
            new JsonResult(obj.ToJson());

        protected ActionResult File(byte[] fileContent) =>
            new FileResult(fileContent);

        protected ActionResult NotFound(string message = "") =>
            new NotFounfResult(message);
    }
}