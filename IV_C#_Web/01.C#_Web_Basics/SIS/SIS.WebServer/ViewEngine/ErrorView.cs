﻿namespace SIS.MvcFramework.ViewEngine
{
    using Identity;

    public class ErrorView : IView
    {
        private readonly string errors;

        public ErrorView(string errors)
        {
            this.errors = errors;
        }

        public string GetHtml(object model, Principal user)
        {
            return errors;
        }
    }
}