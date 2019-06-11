namespace SIS.MvcFramework.ViewEngine
{
    using Identity;
    using Validation;

    public interface IView
    {
        string GetHtml(object model, ModelStateDictionary modelState, Principal user);
    }
}