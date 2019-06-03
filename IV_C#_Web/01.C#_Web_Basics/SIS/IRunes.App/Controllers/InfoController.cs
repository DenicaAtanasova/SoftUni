namespace IRunes.App.Controllers
{
    using SIS.HTTP.Requests;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;

    public class InfoController : Controller
    {
        public ActionResult About(IHttpRequest request)
        {
            return this.View();
        }
    }
}