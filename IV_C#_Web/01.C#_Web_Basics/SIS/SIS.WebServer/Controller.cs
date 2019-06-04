namespace SIS.MvcFramework
{
    using HTTP.Requests;
    using Result;
    using SIS.MvcFramework.Extensions;
    using SIS.MvcFramework.Identity;
    using SIS.MvcFramework.ViewEngine;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        private IViewEngine viewEngine = new SisViewEngine();

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
            return this.View<object>(null, view);
        }

        protected ActionResult View<T>(T model, [CallerMemberName] string view = null)
            where T : class
        {
            var controllerName = GetType().Name.Replace("Controller", string.Empty);
            var viewName = view;

            var viewContent = System.IO.File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");
            viewContent = this.viewEngine.GetHtml(viewContent, model, this.User);

            var layoutContent = System.IO.File.ReadAllText("Views/_Layout.html");
            layoutContent = this.viewEngine.GetHtml(layoutContent, model, this.User);
            layoutContent = layoutContent.Replace("@RenderBody()", viewContent);

            var htmlResult = new HtmlResult(layoutContent);

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