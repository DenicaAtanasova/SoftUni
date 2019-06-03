namespace SIS.MvcFramework.Security
{
    using Identity;
    using System;

    public class AuthorizeAttribute : Attribute
    {
        private readonly string authority;

        public AuthorizeAttribute(string authority = "authorized")
        {
            this.authority = authority;
        }

        private bool IsLoggedIn(Principal principal) =>
            principal != null;

        public bool IsInAuthority(Principal principal)
        {
            if (!this.IsLoggedIn(principal))
                return this.authority == "anonymous";

            return this.authority == "authorized" || principal.Roles.Contains(this.authority);
        }
    }
}