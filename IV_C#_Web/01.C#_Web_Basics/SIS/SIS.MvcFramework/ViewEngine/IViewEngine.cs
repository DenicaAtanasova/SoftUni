namespace SIS.MvcFramework.ViewEngine
{
    using Identity;
    using Validation;

    public interface IViewEngine
    {
        string GetHtml<T>(string viewContent, T model, ModelStateDictionary modelState, Principal user);
    }
}