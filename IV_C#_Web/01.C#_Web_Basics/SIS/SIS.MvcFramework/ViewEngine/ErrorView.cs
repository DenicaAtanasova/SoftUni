namespace SIS.MvcFramework.ViewEngine
{
    using Identity;
    using Validation;

    public class ErrorView : IView
    {
        private readonly string errors;

        public ErrorView(string errors)
        {
            this.errors = errors;
        }

        public string GetHtml(object model, ModelStateDictionary modelState, Principal user)
        {
            return errors;
        }
    }
}