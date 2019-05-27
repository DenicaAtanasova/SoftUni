namespace SIS.HTTP.Cookies
{
    using Contracts;
    using Common;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void AddCookie(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));

            this.cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.cookies[key];
        }

        public bool HasCookie() =>
            this.cookies.Count != 0;

        public IEnumerator<HttpCookie> GetEnumerator() =>
            this.cookies.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        public override string ToString() =>
            string.Join(GlobalConstants.HttpNewLine, this.cookies.Values.Select(cookie => $"Set-Cookie: {cookie}"));
    }
}